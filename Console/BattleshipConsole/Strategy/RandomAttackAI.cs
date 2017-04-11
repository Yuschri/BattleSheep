
namespace BattleSheepConsole.Strategy
{
    class RandomAttackAI : AI, AIAttackLogicInterface
    {

        public RandomAttackAI(GameBoardController Board) : base(Board)
        {
            base.Board = Board;
        }

        /**
         * Implementasi dari interface AIAttackLogic
         * Melakukan penyerangan berdasarkan serangan terakhir
         * 
         * @return void
         */
        public void SetLogicAttack()
        {
            base.SetStructuredAttack();
        }

        /**
         * Melakukan serangan
         * 
         * @return void
         */
        public void SetAttack()
        {
            // Jika sebelumnya melakukan serangan pada sebuah blok dan
            // blok tersebut adalah kapal, juga bukan bagian terakhir sebuah kapal
            if (base.lastAttackSuccessCol != -1 && base.lastAttackSuccessRow != -1)
            {
                // Melakukan serangan yang terorganisir
                this.SetLogicAttack();
            }
            // Jika pernah menghancurkan sebuah kapal atau belum pernah
            // maka melakukan pengacakan untuk menyerang sebuah blok
            else
            {
                base.SetRandomAttack();
            }
        }

        /**
         * Melakukan serangan palsu, digunakan
         * untuk difficulty expert
         * 
         * @return void
         */
        public void SetFakeAttack()
        {

        }

        /**
         * Nama dari AI
         * 
         * @return string
         */
        public string GetName()
        {
            return "Random Attack AI";
        }

    }
}
