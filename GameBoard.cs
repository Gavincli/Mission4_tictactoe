using System;
using System.Collections.Generic;
using System.Text;

namespace Mission4_tictactoe
{
    public class GameBoard
    {
        // Method to print the board in a nice format
        public static void PrintBoard(string[] board)
        {
            Console.WriteLine("\n");
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine("\n");
        }

        // Method to update the board with player's move
        public static void UpdateBoard(string[] board, int location, bool player)
        {
            // player = true means Player 1 (X), player = false means Player 2 (O)
            string marker = player ? "X" : "O";
            board[location] = marker;
        }

        // Method to check for a winner
        // Returns: 0 = no winner yet, 1 = Player 1 wins, 2 = Player 2 wins, 3 = tie
        public static int WinCheck(string[] board)
        {
            // Define all winning combinations (rows, columns, diagonals)
            int[][] winPatterns = new int[][]
            {
            new int[] {0, 1, 2}, // Top row
            new int[] {3, 4, 5}, // Middle row
            new int[] {6, 7, 8}, // Bottom row
            new int[] {0, 3, 6}, // Left column
            new int[] {1, 4, 7}, // Middle column
            new int[] {2, 5, 8}, // Right column
            new int[] {0, 4, 8}, // Diagonal top-left to bottom-right
            new int[] {2, 4, 6}  // Diagonal top-right to bottom-left
            };

            // Check each winning pattern
            foreach (int[] pattern in winPatterns)
            {
                // Check if all three positions in this pattern are the same
                if (board[pattern[0]] == board[pattern[1]] &&
                    board[pattern[1]] == board[pattern[2]])
                {
                    // Determine which player won
                    if (board[pattern[0]] == "X")
                        return 1; // Player 1 wins
                    else if (board[pattern[0]] == "O")
                        return 2; // Player 2 wins
                }
            }

            // Check for a tie (all spots filled, no winner)
            bool boardFull = true;
            foreach (string spot in board)
            {
                if (spot != "X" && spot != "O")
                {
                    boardFull = false;
                    break;
                }
            }

            if (boardFull)
                return 3; // Tie game

            return 0; // No winner yet, game continues
        }
    }
}
