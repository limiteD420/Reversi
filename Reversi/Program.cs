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
        static int x, y;
        static string[] jatekos = new string[] { "X", "O" };
        static int k = 0;
        static void Main(string[] args)
        {
            startOfTheGame();
            
            do
            {
                writeOut();
                Console.WriteLine("Hova rajzolsz?");
                Console.WriteLine("A(z) " + jatekos[k % 2] + " 1. koordinátája: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("A(z) " + jatekos[k % 2] + " 2. koordinátája: ");
                y = int.Parse(Console.ReadLine());
                                                                
                gameTable[x, y] = jatekos[k % 2];
                putSomething(x, y);
                k++;
                
                Console.Clear();

            } while(!isOver());

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
       
        private static bool Coloring(string [,] matrix, int x, int y, int iranyX, int iranyY)
        {
            int x2 = x + iranyX;
            int y2 = y + iranyY;

            while (x2 >= 0 && x2 < matrix.GetLength(0) - 1 && y2 >= 0 && y2 < matrix.GetLength(1) - 1 && matrix[x2, y2] == jatekos[(k + 1) % 2])
            { 
                x2 += iranyX;
                y2 += iranyY;
            }

            if (matrix[x2, y2] == jatekos[k % 2])
            {
                x2 -= iranyX;
                y2 -= iranyY;

                while (y2 != y || x2 != x)
                {
                    matrix[x2, y2] = jatekos[k % 2];
                    x2 -= iranyX;
                    y2 -= iranyY;
                    
                }
                return true;
            }

            return false;
        }

        private static void putSomething(int x, int y)
        {
            Coloring(gameTable, x, y, 1, 0);
            Coloring(gameTable, x, y, -1, 0);
            Coloring(gameTable, x, y, 1, 1);
            Coloring(gameTable, x, y, -1, -1);
            Coloring(gameTable, x, y, 1, -1);
            Coloring(gameTable, x, y, -1, 1);
            Coloring(gameTable, x, y, 0, 1);
            Coloring(gameTable, x, y, 0, -1);
        }
        private static bool isOver()
        {
                        
            return false;
        }
        //Kell egy függvény, ami azt nézi, hogy az adott játékos tud-e rakni bárhova, vége a játéknak, ha egyik játékos sem tud rakni
    }
    
}
