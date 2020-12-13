using System;

namespace TicTacToe
{
    public class Field
    {
        //private const int width
        private State[,] items = new State[3, 3];
        private State currentState = State.Cross;

        public State CurrentState => currentState;

        public GameState MakeTurn(int row, int column)
        {
            if (row < 0 || row >= 3)
                return GameState.Invalid;
            if (column < 0 || column >= 3)
                return GameState.Invalid;

            if (items[row, column] != State.None)
                return GameState.Invalid;

            items[row, column] = currentState;

            if (CheckHorizontalVerticalWin(row, true) ||
                CheckHorizontalVerticalWin(column, false) ||
                CheckDiagonal(true) ||
                CheckDiagonal(false))
                    return GameState.Win;

            if (CheckFill())
                return GameState.Draw;
            
            currentState = currentState == State.Cross ? State.Zero : State.Cross;
            
            return GameState.Continue;
        }

        private bool CheckHorizontalVerticalWin(int pos, bool row)
        {
            bool win = true;
            for (int pos2 = 0; pos2 < 3; pos2++)
                if ((row ? items[pos, pos2] : items[pos2, pos]) != currentState)
                {
                    win = false;
                    break;
                }

            return win;
        }

        private bool CheckDiagonal(bool direct)
        {
            bool win = true;
            for (int pos = 0; pos < 3; pos++)
                if (items[pos, direct ? pos : 2 - pos] != currentState)
                {
                    win = false;
                    break;
                }

            return win;
        }

        private bool CheckFill()
        {
            for (int row = 0; row < 3; row++)
                for (int column = 0; column < 3; column++)
                    if (items[row, column] == State.None)
                        return false;

            return true;
        }

        public void Print()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Console.Write(items[row, column].GetStateChar());
                }

                Console.WriteLine();
            }
        }
    }
}