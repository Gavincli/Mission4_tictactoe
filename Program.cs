using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Collections.Generic;
using Mission4_tictactoe;

Console.WriteLine("Welcome to Tic-Tac-Toe!");

string[] board = ["0", "1", "2", "3", "4", "5", "6", "7", "8"];
bool player = true;
List<int> UsedValues = new List<int>();

//Pass board for printing
GameBoard.PrintBoard(board);

//Start player alt loop
while (true)
{
    if (player)
    {
        bool isValid = false;
        int number = 0;
        //Player 1

        Console.WriteLine("Player 1 choose a spot: ");

        while (!isValid)
        {
            string location = Console.ReadLine();

            if (int.TryParse(location, out number) && (number >= 0 && number <= 8) && !UsedValues.Contains(number))
            {
                isValid = true;
                UsedValues.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again: ");
            }
        }

        GameBoard.UpdateBoard(board, number, player);
        GameBoard.PrintBoard(board);



        int result = GameBoard.WinCheck(board);
        if (result == 1)
        {
            Console.WriteLine("Player 1 wins!");
            break;
        }
        else if (result == 3)
        {
            Console.WriteLine("It's a tie!");
            break;
        }

        player = false;
    }

    

    else
    {
        bool isValid = false;
        int number = 0;
        //Player 2
        Console.WriteLine("Player 2 choose a spot: ");
        while (!isValid)
        {
            string location = Console.ReadLine();
            if (int.TryParse(location, out number) && (number >= 0 && number <= 8) && !UsedValues.Contains(number))
            {
                isValid = true;
                UsedValues.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again: ");
            }
        }

        GameBoard.UpdateBoard(board, number, player);
        GameBoard.PrintBoard(board);

        int result = GameBoard.WinCheck(board);
        if (result == 2)
        {
            Console.WriteLine("Player 2 wins!");
            break;
        }
        else if (result == 3)
        {
            Console.WriteLine("It's a tie!");
            break;
        }

        player = true;
    }
}