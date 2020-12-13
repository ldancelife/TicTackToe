using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field();
            
            GameState gameState = GameState.Continue;
            while (true)
            {
                int row = -1, column = -1;
                field.Print();

                switch (gameState)
                {
                    case GameState.Win:
                        Console.WriteLine($"Player {(field.CurrentState == State.Cross ? 'x' : 'o')} is winner");
                        return;
                    case GameState.Draw:
                        Console.WriteLine($"Fuck you, it's draw");
                        return;
                    case GameState.Invalid:
                        Console.WriteLine($"Incorrect position {row}, {column}");
                        break;
                    case GameState.Continue:
                        Console.WriteLine($"Enter turn position of {field.CurrentState.GetStateChar()}");
                        break;
                }

                var input = Console.ReadLine();
                var parts = input.Split();
                if (parts.Length != 2)
                {
                    Console.WriteLine("Enter two numbers: row and column");
                    continue;
                }

                if (!int.TryParse(parts[0], out row) || !int.TryParse(parts[1], out column))
                {
                    Console.WriteLine("incorrect row or column");
                    continue;
                }
                
                gameState = field.MakeTurn(row, column);
            }
        }
    }
}