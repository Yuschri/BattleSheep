using BattleSheep.Controller;
using System.Collections.Generic;
using System;

namespace BattleSheep.Strategy
{
    class RandomAttackStrategy : Strategy, StrategyAttackLogicInterface
    {

        private List<int[]> BoardNumber = new List<int[]>();

        public RandomAttackStrategy(GameBoardController Board) : base(Board)
        {
            // Generate BoardNumber
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    BoardNumber.Add(new int[] {i,j });
                }
            }
        }

        /**
         * Mengatur logika penyerangan dari tiap AI 
         */
        public void SetLogicAttack() {
            Random Random = new Random();
            int RandomNumber = Random.Next(0,BoardNumber.Count);
            int row = BoardNumber[RandomNumber][0];
            int col = BoardNumber[RandomNumber][1];
            BoardNumber.RemoveAt(RandomNumber);
            Board.SetAttack(row,col,base.target);
        }

        /**
         * Melakukan serangan tergantung dari tiap AI
         */
        public void SetAttack() {
            this.SetLogicAttack();
        }

        /**
         * Memberi nama pada strategy atau AI
         * 
         * @return string
         */
        public string GetName() {
            return "Random Attack Strategy";
        }

    }
}
