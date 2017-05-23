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

        private void CekNama(object sender, System.EventArgs e)
        {
            TextBox nama = (TextBox)sender;
            if (nama.Text != "")
                this.buttonLanjut.Enabled = true;
            else
                this.buttonLanjut.Enabled = false;
        }

        private void CekNama(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && this.nama.Text != "")
                this.controller.InputDifficulty();
        }
    }
}
