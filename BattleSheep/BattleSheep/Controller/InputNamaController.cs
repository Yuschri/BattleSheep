using System;
using System.Windows.Forms;
using BattleSheep.GUI;

namespace BattleSheep.Controller
{
    class InputNamaController
    {

        private InputNamaForm inputnama;

        private Form inputdifficulty;

        private Form parent;

        public InputNamaController(InputNamaForm inputnama,Form parent)
        {
            this.inputnama = inputnama;
            this.parent = parent;
        }

        public void InputDifficulty()
        {
            this.inputnama.Close();
            this.inputnama.FormClosed += openInputDifficult;
        }

        private void openInputDifficult(object sender, FormClosedEventArgs e)
        {
            this.inputdifficulty = new InputDifficulty(this.parent,this);
            this.inputdifficulty.ShowDialog(this.parent);
        }

        internal string getNama()
        {
            return this.inputnama.nama.Text;
        }
    }
}
