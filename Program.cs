using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Welcome to Tic-Tac-Toe!");

string[] board = ["0", "1", "2", "3", "4", "5", "6", "7", "8"];
bool player = true;
List<int> UsedValues = new List<int>();
int number;

//Pass board for printing
PrintBoard(board);

//Start player alt loop
while (true)
{
    if (player)
    {
        bool isValid = false;
        //Player 1

        Console.WriteLine("Player 1 choose a spot: ");

        while (!isValid)
        {
            string location = Console.ReadLine();

            if (int.TryParse(location, out number) && (number >= 0 && number <= 8) && UsedValues.Contains(number))
            {
                isValid = true; // Entry was a number
                UsedValues.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again: ");
            }
        }

        //UpdateBoard(location, player);



        if (WinCheck(board)) //Expect boolean
                Console.WriteLine("Player 1 wins!");
            player = false;
    }

    

    else
    {
        bool isValid = false;
        //Player 2...
        Console.WriteLine("Player 2 choose a spot: ");
        string location = Console.ReadLine(); //Change to int here, or in support?
        UpdateBoard(location, player);

        WinCheck(board, player ?);
        player = true;
    }
}