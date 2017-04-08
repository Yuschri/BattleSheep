using System;
using BattleSheepConsole.Strategy;

namespace BattleSheepConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            GameBoard Board = new GameBoard();
            AI CPU = new AI(Board,AI.DIFFICULT.MEDIUM);
            CPU.SetAISheep(new int[] { 2,2,3,3,4,4,5});
            Board.RenderBoard();
            Console.WriteLine("Strategy terpilih : " + CPU.GetStrategy());
            while (!Board.HasWinner())
            {
                //Console.ReadKey();
                CPU.SetRealAttack();
                //Board.RenderBoard();
            }
            Board.RenderBoard();
            Console.WriteLine("Selesai dalam turn : " + Board.GetTurn(GameBoard.Player2));
            Console.ReadKey();
        }

    }
}
