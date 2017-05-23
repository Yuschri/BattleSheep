using System;
using System.Windows.Forms;
using System.Drawing;

namespace BattleSheep.GUI
{
    public partial class MainForm : Form
    {

        public static Size size = new Size(284,400);

        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(new MainMenu(this));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
