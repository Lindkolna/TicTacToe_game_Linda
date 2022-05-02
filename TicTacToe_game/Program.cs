using System;
namespace TicTacToe_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            { 
                Console.Clear();

                currentPlayer = GetNextPlayer(currentPlayer);

                Display(currentPlayer);
                GameBoard(gameMarkers);
                GameCore(gameMarkers, currentPlayer);
                gameStatus = WinnerCheck(gameMarkers);
            } 
            while (gameStatus == 0);

            Console.Clear();
            Display(currentPlayer);
            GameBoard(gameMarkers);

            if (gameStatus == 1)
            {
                Console.WriteLine($"The player {currentPlayer} is the winner!");
            }

            if(gameStatus == 2)
            {
                Console.WriteLine($"There are no winners. Play again!");
            }
        }
        public static int WinnerCheck(char[] gameMarkers)
        {
            if(GameDraw(gameMarkers))
            {
                return 2;
            }
            if(GameWinner(gameMarkers))
            {
                return 1;
            }
            return 0;
        }
        public static bool GameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9';
        }
        public static bool GameWinner(char[]gameMarkers)
        {
            if (AreGameMarkersTheSame(gameMarkers, 0, 1, 2))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 6, 7, 8))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 0, 3, 6))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 1, 4, 7))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 2, 5, 8))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 0, 4, 8))
            {
                return true;
            }
            if (AreGameMarkersTheSame(gameMarkers, 2, 4, 6))
            {
                return true;
            }
            return false;
        }
        public static bool AreGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1] == testGameMarkers[pos2] && testGameMarkers[pos2] == testGameMarkers[pos3];
        }
        private static void GameCore(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;
            do
            {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                   userInput == "1" ||
                    userInput == "2" ||
                    userInput == "3" ||
                    userInput == "4" ||
                    userInput == "5" ||
                    userInput == "6" ||
                    userInput == "7" ||
                    userInput == "8" ||
                    userInput == "9")
                {
                    Console.Clear();
                    int.TryParse(userInput, out var gamePlacementMarker);
                    char currentMarker = gameMarkers[gamePlacementMarker - 1];
                    if (currentMarker == 'X' || currentMarker == 'O')
                    {
                        Console.WriteLine("Placement has already a marker, please choose another placement");
                    }
                    else
                    {
                        gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);
                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value, please choose another placement!");
                }
            } while (notValidMove);
        }
        public static char GetPlayerMarker (int player)
        {
            if(player % 2 == 0)
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
        static void Display(int PlayerNumber)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("\nPlayer 1 plays with 'X'");
            Console.WriteLine("Player 2 plays with 'O'");
            Console.WriteLine();
            Console.WriteLine($"Player {PlayerNumber} in order to move, choose a number from 1-9");
            Console.WriteLine();
        }
        static void GameBoard(char[] gameMarkers)
        {
            Console.WriteLine($"{gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]}");
            Console.WriteLine("--|---|---");
            Console.WriteLine($"{gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]}");
            Console.WriteLine("--|---|---");
            Console.WriteLine($"{gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]}");
            Console.WriteLine("--|---|---");
        }
        static int GetNextPlayer (int player)
        {
            if (player == 1)
            {
                return 2;
            }
            return 1;
        }
    }
}

