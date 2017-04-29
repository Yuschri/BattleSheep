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
    public partial class GameBoardGUI : Panel
    {

        private PlayerBoard playerboard1;

        private PlayerBoard playerboard2;

        private void GenerateBButon()
        {
            this.playerboard1 = new PlayerBoard(this);
            this.Controls.Add(playerboard1);
        }

        Control FControl;
        public GameBoardGUI(Control Parent)
        {
            FControl = Parent;
            InitializeComponent();
            GenerateBButon();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
