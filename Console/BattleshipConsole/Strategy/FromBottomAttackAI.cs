
namespace BattleSheepConsole.Strategy
{
    class FromBottomAttackAI : AI, AIAttackLogicInterface
    {

        private byte sRow;

        private byte sCol;

        private bool BackToBottom;

        public FromBottomAttackAI(GameBoard Board) : base(Board)
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
                    sRow--;
                    if (BackToBottom)
                        sCol = 0;
                    else
                        sCol = 1;
                }
                else if (sCol == 11)
                {
                    sRow--;
                    if (BackToBottom)
                        sCol = 1;
                    else
                        sCol = 0;
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
