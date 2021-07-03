using System;
using System.Linq;
using Tdd.TddInAction;
using Xunit;

namespace Tdd.Tests.TddInAction
{
    public class TicTacToeTests
    {
        [Fact]
        public void TicTacToe_Constructs()
        {
            var ticTacToe = new TicTacToe();

            Assert.Equal(0, ticTacToe.MovesCount);
            Assert.Equal(State.Unset, ticTacToe.GetState(1));
        }

        [Fact]
        public void MakeMove_WithValidIndex_IncrementsMovesCount()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.MakeMove(1);

            Assert.Equal(1, ticTacToe.MovesCount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void MakeMove_WithInvalidIndex_ThrowsException(int index)
        {
            var ticTacToe = new TicTacToe();

            Assert.Throws<ArgumentOutOfRangeException>(() => ticTacToe.MakeMove(index));
        }

        [Fact]
        public void MakeMove_WithDifferentIndex_SetsState()
        {
            var ticTacToe = new TicTacToe();
            var indexes = new[] { 1, 2, 3, 4 };
            MakeMoves(ticTacToe, indexes);

            var i = 0;
            Assert.True(indexes.All(index => (i++ % 2 == 0 ? State.Cross : State.Zero) == ticTacToe.GetState(index)));
        }

        [Fact]
        public void MakeMove_WithSameIndex_ThrowsException()
        {
            var ticTacToe = new TicTacToe();
            ticTacToe.MakeMove(1);

            Assert.Throws<InvalidOperationException>(() => ticTacToe.MakeMove(1));
        }

        [Fact]
        public void MakeMove_WhenFinished_ThrowsException()
        {
            var ticTacToe = new TicTacToe();
            MakeMoves(ticTacToe, 1, 4, 2, 5, 3);

            Assert.Throws<InvalidOperationException>(() => ticTacToe.MakeMove(6));
        }

        [Theory]
        [InlineData(Winner.Unfinished, 1, 2, 3)]
        [InlineData(Winner.Cross, 1, 4, 2, 5, 3)]
        [InlineData(Winner.Zero, 1, 2, 3, 5, 4, 8)]
        [InlineData(Winner.Draw, 1, 4, 2, 5, 6, 3, 7, 8, 9)]
        public void GetWinner_GetsWinner(Winner expected, params int[] indexes)
        {
            var ticTacToe = new TicTacToe();
            MakeMoves(ticTacToe, indexes);

            Assert.Equal(expected, ticTacToe.GetWinner());
        }

        private static void MakeMoves(TicTacToe ticTacToe, params int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                ticTacToe.MakeMove(indexes[i]);
            }
        }
    }
}
