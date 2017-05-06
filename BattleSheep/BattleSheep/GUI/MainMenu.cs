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

        Control FControl;

        public MainMenu(Control Parent)
        {
            FControl = Parent;
            papan = new GameBoardGUI(FControl);
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            FControl.Controls.RemoveAt(0);
            FControl.Size = new Size(760, 550);
            FControl.Controls.Add(papan);
        }
    }
}
