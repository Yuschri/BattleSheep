using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleSheep.GUI
{
    class PlayerBoard : TableLayoutPanel
    {

        List<List<Button>> BButton = new List<List<Button>>();

        private GameBoardGUI gameboard;

        public PlayerBoard(GameBoardGUI gameboard)
        {
            this.gameboard = gameboard;
            inisialisasi();
            for (int col = 0; col <= 9; col++)
            {
                BButton.Add(new List<Button>());
                for (int row = 0; row <= 9; row++)
                {
                    Button K = new Button();

                    K.Name = Convert.ToChar(row) + "" + Convert.ToChar(col) + "PButton";
                    K.Dock = DockStyle.Fill;
                    K.Click += K_Click;
                    K.Padding = new Padding(0);
                    K.Margin = new Padding(0);
                    K.FlatStyle = FlatStyle.Flat;
                    K.FlatAppearance.BorderSize = 1;
                    K.FlatAppearance.BorderColor = Color.FromArgb(125, 125, 125);
                    K.BackColor = Color.FromArgb(230, 230, 240);
                    K.TextAlign = ContentAlignment.MiddleCenter;
                    K.MouseHover += K_MouseHover;
                    K.MouseLeave += K_MouseLeave;
                    BButton[col].Add(K);
                    this.Controls.Add(BButton[col][row], col, row);
                }
            }
        }

        private void inisialisasi()
        {
            this.ColumnCount = 10;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "tableLayoutPanel1";
            this.RowCount = 10;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.Size = new System.Drawing.Size(370, 370);
            this.TabIndex = 0;
        }

        private void K_MouseLeave(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            BButton[kolom][baris].Text = "";
            BButton[kolom][baris].Image = null;
        }

        private void K_MouseHover(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            gameboard.TestPlace.Text = baris + "," + kolom;
            //BButton[kolom][baris].Text = "S";
            BButton[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
        }

        private void K_Click(object sender, EventArgs e)
        {
            int baris = Convert.ToInt32(((Button)sender).Name[0]);
            int kolom = Convert.ToInt32(((Button)sender).Name[1]);
            gameboard.TestPlace.Text = baris + "," + kolom;
        }

    }
}
