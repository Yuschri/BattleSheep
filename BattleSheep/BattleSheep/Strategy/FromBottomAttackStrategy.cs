﻿
using BattleSheep.Controller;

namespace BattleSheep.Strategy
{
    class FromBottomAttackStrategy : Strategy, StrategyAttackLogicInterface
    {

        private byte sRow = 9;

        private byte sCol = 0;

        private bool BackToBottom = false;

        public FromBottomAttackStrategy(GameBoardController Board) : base(Board)
        {
            base.Board = Board;
        }

        public void SetLogicAttack()
        {
            int counter = 0, limit = 20;
            while ((!Board.AllowAttack(sRow, sCol, base.target) ||
                   Board.IsSuccessAttack(sRow - 1, sCol, base.target) ||
                   Board.IsSuccessAttack(sRow + 1, sCol, base.target) ||
                   Board.IsSuccessAttack(sRow, sCol - 1, base.target) ||
                   Board.IsSuccessAttack(sRow, sCol + 1, base.target) ||
                   Board.IsSuccessAttack(sRow + 1, sCol + 1, base.target) ||
                   Board.IsSuccessAttack(sRow - 1, sCol - 1, base.target) ||
                   Board.IsSuccessAttack(sRow - 1, sCol + 1, base.target) ||
                   Board.IsSuccessAttack(sRow + 1, sCol - 1, base.target)) &&
                   counter < limit)
            {
                counter++;
                sCol += 2;
                if (sCol > 9)
                {
                    sRow--;
                    sCol = (byte)((BackToBottom) ? ((sCol == 10) ? 0 : 1) : ((sCol == 10) ? 1 : 0));
                }
                if (sRow < 0)
                {
                    sRow = 9;
                    sCol = 1;
                    BackToBottom = true;
                }

                //Console.WriteLine("Row : " + sRow + " Col : " + sCol);
            }

            if (counter == 20)
            {
                base.SetRandomAttack();
            }
            else
            {
                Board.SetAttack(sRow, sCol, this.target);
                int row = sRow;
                int col = sCol;
                if (Board.IsSuccessAttack(row, col, this.target))
                {
                    // Jika diserang adalah lokasi sebuah kapal
                    // Maka tandai lokasi tersebut
                    if (Board.IsSheepLocation(row, col, this.target))
                    {
                        if (!Board.GetSheep(row, col, this.target).IsDestroyed())
                        {
                            lastAttackSuccessCol = col;
                            lastAttackSuccessRow = row;
                        }
                    }
                }
            }
        }

        public new void SetAttack()
        {
            // Jika sebelumnya melakukan serangan pada sebuah blok dan
            // blok tersebut adalah domba, juga bukan bagian terakhir sebuah domba
            if (base.lastAttackSuccessCol != -1 && base.lastAttackSuccessRow != -1)
            {
                // Melakukan serangan yang terorganisir
                base.SetStructuredAttack();
            }
            // Jika pernah menghancurkan sebuah domba atau belum pernah
            // maka melakukan pengacakan untuk menyerang sebuah blok
            else
            {
                this.SetLogicAttack();
            }
        }

        public void SetFakeAttack()
        {

        }

        public string GetName()
        {
            return "From Bottom Attack AI";
        }

    }
}
