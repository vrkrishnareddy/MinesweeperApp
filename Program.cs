using System;

class Program
{
    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to Minesweeper!\n");
            Console.Write("Enter the size of the grid (e.g. 4 for a 4x4 grid): ");
            int size = int.Parse(Console.ReadLine());
            int maxMines = (int)(size * size * 0.35);

            int mines;
            do
            {
                Console.Write($"Enter the number of mines (max {maxMines}): ");
                mines = int.Parse(Console.ReadLine());
            } while (mines > maxMines);

            IGameService game = new GameService();
            game.Initialize(size, mines);

            while (!game.IsGameOver && !game.IsGameWon)
            {
                Console.WriteLine("\n" + game.GetBoardDisplay());
                Console.Write("Select a square to reveal (e.g. A1): ");
                string input = Console.ReadLine();

                game.Reveal(input);
                if (game.IsGameOver)
                {
                    Console.WriteLine("\nOh no, you detonated a mine! Game over.");
                }
                else if (game.IsGameWon)
                {
                    Console.WriteLine("\n" + game.GetBoardDisplay());
                    Console.WriteLine("Congratulations, you have won the game!");
                }
            }

            Console.WriteLine("Press any key to play again...");
            Console.ReadKey();
        } while (true);
    }
}