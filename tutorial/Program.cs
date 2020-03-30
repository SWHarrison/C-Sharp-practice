using System;

namespace tutorial
{
    class Program
    {

        static void printBoard(char[][] board)
        {
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[r].Length; c++)
                {
                    //Console.Write(r);
                    //Console.Write(c);
                    //Console.Write(" ");
                    Console.Write(board[r][c] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool checkRow(char[][] board, int row, char token)
        {
            for (int c = 0; c < board.Length; c++)
            {
                // if board spot is not the player's token
                if (board[row][c] != token)
                {
                    return false;
                }
            }

            return true;
        }

        static bool checkCol(char[][] board, int col, char token)
        {
            for (int r = 0; r < board.Length; r++)
            {
                // if board spot is not the player's token
                if (board[r][col] != token)
                {
                    return false;
                }
            }

            return true;
        }

        static bool checkDiagTopRightToBotLeft(char[][] board, char token)
        {
            for (int i = 0; i < board.Length; i++)
            {
                // if board spot is not the player's token
                if (board[board.Length - i - 1][i] != token)
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkDiagTopLeftToBotRight(char[][] board, char token)
        {
            for (int i = 0; i < board.Length; i++)
            {
                // if board spot is not the player's token
                if (board[i][i] != token)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Enter player 1 name:");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Enter player 2 name:");
            string player2Name = Console.ReadLine();

            int boardSize = 5;
            char player1Token = 'X';
            char player2Token = 'O';

            char[][] board = new char[boardSize][];
            for (int r = 0; r < boardSize; r++)
            {
                board[r] = new char[boardSize];
                for (int c = 0; c < boardSize; c++)
                {
                    board[r][c] = '_';
                }
            }

            bool continueGame = true;
            int moves = 0;
            int player = 1;
            string currentPlayer = player1Name;
            char currentToken = player1Token;

            printBoard(board);

            while (continueGame)
            {
                bool moveIsGood = false;
                int row, col;
                // ensures valid move from player
                do
                {
                    Console.WriteLine(currentPlayer + "'s turn, please enter row:");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(currentPlayer + "'s turn, please enter column:");
                    col = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(currentPlayer + " has entered " + row + "," + col);

                    if (row < 0 || row > board.Length - 1 || col < 0 || col > board.Length - 1 || board[row][col] != '_')
                    {
                        Console.WriteLine("Invalid move, please try again.");
                    }
                    else
                    {
                        moveIsGood = true;
                    }
                }
                while (!moveIsGood);

                board[row][col] = currentToken;
                moves++;
                printBoard(board);

                // if game is over, print message and end program
                if (checkRow(board, row, currentToken) || checkCol(board,col,currentToken) || checkDiagTopLeftToBotRight(board,currentToken) || checkDiagTopRightToBotLeft(board,currentToken))
                {
                    Console.WriteLine(currentPlayer + " has won!");
                    continueGame = false;
                }
                else if (moves == boardSize * boardSize)
                {
                    Console.WriteLine("Tie game!");
                    continueGame = false;
                }
                else
                {
                    if (player == 1)
                    {
                        currentPlayer = player2Name;
                        currentToken = player2Token;
                        player = 2;
                    }
                    else
                    {
                        currentPlayer = player1Name;
                        currentToken = player1Token;
                        player = 1;
                    }
                }
            }
        }
    }
}
