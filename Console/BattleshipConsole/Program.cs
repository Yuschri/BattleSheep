using System;

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
            CPU.generateStrategy();
            Console.WriteLine(CPU.getStrategy());
            
            while (!Board.hasWinner())
            {
                //Console.ReadKey();
                CPU.setAttack();
                //Board.RenderBoard();
            }
            Board.RenderBoard();
            Console.WriteLine("Selesai dalam turn : " + Board.getTurn(GameBoard.Player2));
            Console.ReadKey();
        }

    }
}
