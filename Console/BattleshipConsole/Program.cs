using System;
using BattleSheepConsole.Strategy;

namespace BattleSheepConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            GameBoardController Board = new GameBoardController("Bagas");
            AI CPU = new AI(Board);
            CPU.UseInsteadAI(new FromRightAttackAI(Board));
            CPU.SetAISheep(new int[] { 2,2,3,3,4,4,5});
            Board.RenderBoard();
            Console.WriteLine("Strategy terpilih : " + CPU.GetStrategy());
            while (!Board.HasWinner())
            {
                Console.ReadKey();
                CPU.SetAttack();
                Board.RenderBoard();
            }
            Board.RenderBoard();
            Console.WriteLine("Selesai dalam turn : " + Board.GetPlayer(GameBoardController.PLAYER.PLAYER2).GetTurn());
            Console.ReadKey();
        }

    }
}
