
namespace BattleSheepConsole.Strategy
{
    class FromRightAttackAI : AI, AIAttackLogicInterface
    {

        private byte sRow;

        private byte sCol;

        private bool BackToRight;

        public FromRightAttackAI(GameBoard Board) : base(Board)
        {
            base.Board = Board;
        }

        public void SetLogicAttack()
        {

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
            return "From Right Attack AI";
        }

    }
}
