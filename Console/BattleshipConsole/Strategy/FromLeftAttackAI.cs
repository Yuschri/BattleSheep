
namespace BattleSheepConsole.Strategy
{
    class FromLeftAttackAI : AI, AIAttackLogicInterface
    {

        private byte sRow;

        private byte sCol;

        private bool BackToLeft;

        public FromLeftAttackAI(GameBoard Board) : base(Board)
        {
            base.Board = Board;
        }

        public void SetLogicAttack()
        {

        }

        public void SetAttack()
        {

        }

        public void SetFakeAttack()
        {

        }

        public string GetName()
        {
            return "From Left Attack AI";
        }

    }
}
