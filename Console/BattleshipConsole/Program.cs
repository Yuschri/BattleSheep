using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSheepConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            GameBoard Board = new GameBoard();
            AI CPU = new AI(Board);
            CPU.setAISheep();
            Board.RenderBoard();
            int turn = 0;
            while (!Board.hasWinner())
            {
                //Console.ReadKey();
                CPU.setAttack();
                //Board.RenderBoard();
                turn++;
            }
            Board.RenderBoard();
            Console.WriteLine("Selesai dalam turn : " + turn);
            Console.ReadKey();
        }

    }
}
