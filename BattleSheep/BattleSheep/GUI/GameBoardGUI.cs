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
        List<List<Button>> BButton = new List<List<Button>>();
        private void GenerateBButon()
        {
            for(int col = 0; col <= 9; col++)
            {
                BButton.Add(new List<Button>());
                for(int row = 0; row<=9; row++)
                {
                    Button K = new Button();
                    
                    K.Name = Convert.ToChar(row) + "" + Convert.ToChar(col) + "PButton";
                    K.Dock = DockStyle.Fill;
                    K.Click += K_Click;
                    K.MouseHover += K_MouseHover;
                    K.MouseLeave += K_MouseLeave;
                    BButton[col].Add(K);
                    tableLayoutPanel1.Controls.Add(BButton[col][row],col,row);
                }
            }

        }

        private void K_MouseLeave(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            BButton[kolom][baris + 1].Text = "";
        }

        private void K_MouseHover(object sender, EventArgs e)
        {
            Button temp = (Button) sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            TestPlace.Text = baris + "," + kolom;
            BButton[kolom][baris + 1].Text = "S";
        }

        private void K_Click(object sender, EventArgs e)
        {
            int baris = Convert.ToInt32(((Button)sender).Name[0]);
            int kolom = Convert.ToInt32(((Button)sender).Name[1]);
            TestPlace.Text = baris+","+kolom;
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
