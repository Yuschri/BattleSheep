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
    public partial class MainMenu : Panel
    {
        public GameBoardGUI papan;

        private Form parent;

        public MainMenu(Form Parent)
        {
            this.parent = Parent;
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            papan = new GameBoardGUI(parent);
            parent.Controls.RemoveAt(0);
            parent.Size = new Size(760, 550);
            parent.Controls.Add(papan);
        }
    }
}
