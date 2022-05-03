using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Program
    {
        static string[,] gameTable = new string[8, 8];
        static void Main(string[] args)
        {
            startOfTheGame();
            writeOut();
            Console.ReadLine();

        }
        private static void startOfTheGame()
        {
            for (int i = 0; i < gameTable.GetLength(0); i++)
            {
                for (int j = 0; j < gameTable.GetLength(1); j++)
                {
                    gameTable[i, j] = "*";
                }
            }

            gameTable[3, 3] = "X";
            gameTable[4, 4] = "X";
            gameTable[3, 4] = "O";
            gameTable[4, 3] = "O";
        }
        private static void writeOut()
        {
            for (int x = 0; x < gameTable.GetLength(0); x++)
            {
                for (int y = 0; y < gameTable.GetLength(1); y++)
                {
                    Console.Write("{0} ", gameTable[x, y]);
                }
                Console.WriteLine();
            }
        }
        
        private static void putSymbol(int x, int y, string character)
        {
            gameTable[x, y] = character;
        }

        private static bool canPutThere()
        {
            
            return false;
        }
    }
}
