﻿using System;
using System.Linq;
using Xunit;

namespace Tdd
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

        private void MakeMoves(TicTacToe ticTacToe, params int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                ticTacToe.MakeMove(indexes[i]);
            }
        }
    }

    public class TicTacToe
    {
        private readonly static int[][] _lines = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 },
            new[] { 1, 4, 7 },
            new[] { 2, 5, 8 },
            new[] { 3, 6, 9 },
            new[] { 1, 5, 9 },
            new[] { 3, 5, 7 }
        };

        private readonly State[] _states;

        public int MovesCount { get; private set; }

        public TicTacToe()
        {
            _states = Enumerable.Repeat(State.Unset, 9).ToArray();
        }

        public void MakeMove(int index)
        {
            if (index < 1 || index > 9) throw new ArgumentOutOfRangeException(nameof(index));

            if (GetState(index) != State.Unset) throw new InvalidOperationException();

            if (GetWinner() != Winner.Unfinished) throw new InvalidOperationException();

            _states[index - 1] = MovesCount % 2 == 0 ? State.Cross : State.Zero;

            MovesCount++;
        }

        public State GetState(int index)
        {
            return _states[index - 1];
        }

        public Winner GetWinner()
        {
            foreach (var line in _lines)
            {
                var firstState = GetState(line[0]);
                if (firstState != State.Unset && firstState == GetState(line[1]) && firstState == GetState(line[2]))
                {
                    return firstState == State.Cross ? Winner.Cross : Winner.Zero;
                }
            }

            return MovesCount == 9 ? Winner.Draw : Winner.Unfinished;
        }
    }

    public enum State
    {
        Cross,
        Zero,
        Unset
    }

    public enum Winner
    {
        Cross,
        Zero,
        Draw,
        Unfinished
    }
}
