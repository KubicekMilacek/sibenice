using System;

namespace Piskvorky
{
    class Program
    {
        static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            int turn = 0;
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                PrintBoard();

                Console.WriteLine($"Hráč {currentPlayer}, zadej číslo pole:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
                {
                    if (MakeMove(position))
                    {
                        turn++;
                        if (CheckWin())
                        {
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine($"Hráč {currentPlayer} vyhrál!");
                            gameRunning = false;
                        }
                        else if (turn == 9)
                        {
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("Remíza!");
                            gameRunning = false;
                        }
                        else
                        {
                            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                        }
                    }
                    else
                    {
                        Console.WriteLine("Pole je již obsazené, zkus jiné.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Neplatný vstup, zadej číslo od 1 do 9.");
                    Console.ReadKey();
                }
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"| {board[i, 0]} | {board[i, 1]} | {board[i, 2]} |");
                Console.WriteLine("-------------");
            }
        }

        static bool MakeMove(int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;

            if (board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = currentPlayer;
                return true;
            }
            return false;
        }

        static bool CheckWin()
        {
            // Kontrola řádků, sloupců a diagonál
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    return true;
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    return true;
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true;

            return false;
        }
    }
}