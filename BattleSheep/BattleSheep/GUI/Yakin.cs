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
    public partial class Yakin : Form
    {

        private MainForm parent;

        public Yakin(MainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void BackToMenu(object sender, EventArgs e)
        {
            this.Close();
            this.FormClosed += BactToMenuProcess;
        }

        private void BactToMenuProcess(object sender, FormClosedEventArgs e)
        {
            this.parent.Controls.RemoveAt(0);
            MainMenu menu = new MainMenu(this.parent);
            this.parent.Size = MainForm.size;
            this.parent.Controls.Add(menu);
        }

        private void KeepPlay(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
