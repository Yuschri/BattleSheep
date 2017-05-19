using BattleSheep.Controller;
using System.Windows.Forms;

namespace BattleSheep.GUI
{
    public partial class InputNamaForm : Form
    {

        private InputNamaController controller;

        private Form mainmenu;

        public InputNamaForm(Form mainmenu)
        {
            this.mainmenu = mainmenu;
            this.controller = new InputNamaController(this,this.mainmenu);
            InitializeComponent();
        }

        private void InputDifficulty(object sender, System.EventArgs e)
        {
            this.controller.InputDifficulty();
        }
    }
}
