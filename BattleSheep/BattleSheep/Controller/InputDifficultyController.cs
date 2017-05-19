using System.Drawing;
using System.Windows.Forms;
using BattleSheep.GUI;

namespace BattleSheep.Controller
{
    class InputDifficultyController
    {
        private Strategy.Strategy.DIFFICULT difficult;

        private GameBoardGUI board;

        private Form parent;

        private Form inputdifficulty;

        private InputNamaController inputnama;

        public InputDifficultyController(Form inputdifficulty, Form parent,InputNamaController inputnama)
        {
            this.parent = parent;
            this.inputdifficulty = inputdifficulty;
            this.inputnama = inputnama;
        }

        public void Play()
        {
            this.inputdifficulty.Close();
            board = new GameBoardGUI(parent,this.inputnama.getNama(),this.difficult);
            parent.Controls.RemoveAt(0);
            parent.Size = new Size(760, 550);
            parent.Controls.Add(board);
        }

        public void setEasy()
        {
            this.difficult = Strategy.Strategy.DIFFICULT.EASY;
            this.Play();
        }

        public void setMedium()
        {
            this.difficult = Strategy.Strategy.DIFFICULT.MEDIUM;
            this.Play();
        }

        public void setHard()
        {
            this.difficult = Strategy.Strategy.DIFFICULT.HARD;
            this.Play();
        }

    }
}
