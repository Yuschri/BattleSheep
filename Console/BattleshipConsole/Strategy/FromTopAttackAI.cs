﻿
namespace BattleSheepConsole.Strategy
{
    class FromTopAttackAI : AI, AIAttackLogicInterface
    {

        private byte sRow = 0;

        private byte sCol = 0;

        private bool BackToTop = false;

        public FromTopAttackAI(GameBoard Board) : base(Board)
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
                if (sCol == 10)
                {
                    sRow++;
                    if (BackToTop)
                        sCol = 0;
                    else
                        sCol = 1;
                }
                else if (sCol == 11)
                {
                    sRow++;
                    if (BackToTop)
                        sCol = 1;
                    else
                        sCol = 0;
                }
                if (sRow > 9)
                {
                    sRow = 0;
                    sCol = 1;
                    BackToTop = true;
                }
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
                    if (Board.IsShipLocation(row, col, this.target))
                    {
                        if (!Board.GetSheep(row, col, this.target).isDestroyed())
                        {
                            lastAttackSuccessCol = col;
                            lastAttackSuccessRow = row;
                        }
                    }
                }
            }
        }

        public void SetAttack()
        {
            //System.Console.WriteLine(sRow + " " + sCol);
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
            return "From Top Attack AI";
        }
    }
}
