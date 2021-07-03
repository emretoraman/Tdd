using System;
using System.Linq;

namespace Tdd.TddInAction
{
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
