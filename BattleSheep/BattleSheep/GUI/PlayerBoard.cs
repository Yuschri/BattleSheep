using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using BattleSheep.Controller;
using BattleSheep.Object;

namespace BattleSheep.GUI
{
    class PlayerBoard : TableLayoutPanel
    {

        int[] SheepLengthList = new int[] {2,2,3,4,5 };

        int SheepCounter = 0;

        List<List<Button>> BButton = new List<List<Button>>();

        private Player player;

        private GameBoardGUI gameboard;

        private GameBoardController Controller;

        public PlayerBoard(GameBoardGUI gameboard,Player player)
        {
            this.player = player;
            this.gameboard = gameboard;
            this.Controller = this.gameboard.GetController();
            this.inisialisasi();
            this.GenerateButton();
            this.Controller.SetPlayerSheepLocation(2, 0, 5, 0, GameBoardController.PLAYER.PLAYER1);
            this.RenderBoardGUI(true);
        }

        private void RenderBoardGUI(bool ShowSheep)
        {
            if (ShowSheep)
            {
                for (int i = 0; i < 10; i++)
                {
                    //Console.Write(i + " ");
                    for (int j = 0; j < 10; j++)
                    {
                        //if (j == 0)
                        //{
                        if (this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetSheepMap()[i, j] == 'X')
                        {
                            //render jika domba kena serangan
                            BButton[j][i].Image = global::BattleSheep.Properties.Resources.sheep2;
                        }
                        if (this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetAttacked()[i, j] == 'O')
                            {
                                if (this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetSheepMap()[i, j] == 'X')
                                {
                                    //render jika domba kena serangan
                                    BButton[j][i].Image = global::BattleSheep.Properties.Resources.sheep1;
                                }
                                else
                                {
                                    //BButton[j][i].Image = global::BattleSheep.Properties.Resources.sheep1;
                                    BButton[j][i].BackColor = Color.FromArgb(255, 244, 53);
                                }
                                //Console.Write(this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetAttacked()[i, j] + " | ");
                            }

                            //Console.Write(this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetAttacked()[i, j] + " | ");
                        //}
                    }
                }
            }
        }

        private void GenerateButton()
        {
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
            int length = this.SheepLengthList[this.SheepCounter];
            Button temp = (Button)sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            if (!this.Controller.IsSheepLocation(baris, kolom, GameBoardController.PLAYER.PLAYER1))
            {
                if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom + length - 1, baris, GameBoardController.PLAYER.PLAYER1))
                {
                    for (int i = kolom; i < kolom + length; i++)
                    {
                        BButton[i][baris].Image = null;
                    }
                }
                else if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom - length + 1, baris, GameBoardController.PLAYER.PLAYER1))
                {
                    for (int i = kolom; i > kolom - length; i--)
                    {
                        BButton[i][baris].Image = null;
                    }
                    //BButton[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
                }
                else
                {
                    BButton[kolom][baris].BackColor = Color.FromArgb(225, 90, 90);
                }
            }
            
        }

        private void K_MouseHover(object sender, EventArgs e)
        {
            int length = this.SheepLengthList[this.SheepCounter];
            Button temp = (Button)sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            this.gameboard.TestPlace.Text = baris + "," + kolom;
            //BButton[kolom][baris].Text = "S";
            if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom + length - 1, baris, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = kolom; i < kolom + length; i++)
                {
                    BButton[i][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
                }
            }
            else if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom - length + 1, baris, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = kolom; i > kolom - length; i--)
                {
                    BButton[i][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
                }
                //BButton[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
            }
            else
            {
                BButton[kolom][baris].BackColor = Color.FromArgb(225, 90, 90);
            }
            Console.WriteLine(baris + "," + kolom);
        }

        private void K_Click(object sender, EventArgs e)
        {
            int length = this.SheepLengthList[this.SheepCounter];
            int baris = Convert.ToInt32(((Button)sender).Name[0]);
            int kolom = Convert.ToInt32(((Button)sender).Name[1]);
            this.gameboard.TestPlace.Text = baris + "," + kolom;
            if (this.Controller.ConfirmPlayerSheepLocation(baris, kolom, kolom + length, baris, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = kolom; i < kolom + length; i++)
                {
                    BButton[i][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
                }
                if(this.SheepCounter < 5)
                    this.SheepCounter++;
            }
            else
            {
                BButton[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
            }
        }

    }
}
