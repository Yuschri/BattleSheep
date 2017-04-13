
namespace BattleSheepConsole.Strategy
{
    interface AIAttackLogicInterface
    {

        /**
         * Mengatur logika penyerangan dari tiap AI 
         */
        void SetLogicAttack();

        /**
         * Melakukan serangan tergantung dari tiap AI
         */
        void SetAttack();

        /**
         * Melakukan serangan palsu
         */
        void SetFakeAttack();

        /**
         * Memberi nama pada strategy atau AI
         * 
         * @return string
         */
        string GetName();

    }
}
