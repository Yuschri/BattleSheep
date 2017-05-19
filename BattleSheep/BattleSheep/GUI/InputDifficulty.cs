using System;
using BattleSheep.Controller;
using System.Windows.Forms;

namespace BattleSheep.GUI
{
    public partial class InputDifficulty : Form
    {

        private InputDifficultyController controller;

        internal InputDifficulty(Form parent,InputNamaController inputnama)
        {
            this.controller = new InputDifficultyController(this,parent,inputnama);
            InitializeComponent();
        }

        private void Play()
        {

        }

        private void setEasy(object sender, EventArgs e)
        {
            this.controller.setEasy();
        }

        private void setMedium(object sender, EventArgs e)
        {
            this.controller.setMedium();
        }

        private void setHard(object sender, EventArgs e)
        {
            this.controller.setHard();
        }
    }
}
