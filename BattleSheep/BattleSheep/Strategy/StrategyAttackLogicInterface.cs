
namespace BattleSheep.Strategy
{
    interface StrategyAttackLogicInterface
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
         * Memberi nama pada strategy atau AI
         * 
         * @return string
         */
        string GetName();

    }
}
