using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleSheep.GUI
{
    public partial class FormWinner : Form
    {

        private Form parent;

        public FormWinner(Form Parent)
        {
            this.parent = Parent;
            InitializeComponent();
        }

        private void PlayAgain(object sender, EventArgs e)
        {

        }

        private void BackToMenu(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Controls.Clear();
            this.parent.Size = new Size(300, 370);
            this.parent.Controls.Add(new MainMenu(this.parent));
        }
    }
}
