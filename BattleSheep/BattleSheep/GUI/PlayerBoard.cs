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

        bool rotate = false;

        List<List<Button>> BButton = new List<List<Button>>();

        private Player player;

        private GameBoardGUI gameboard;

        private GameBoardController Controller;

        //simpan koordinat hover
        //[0] = colfrom, [1] = rowfrom, [2] = coluntil, [3] = rowuntil
        private int[] TempCoord = new int[4];

        public PlayerBoard(GameBoardGUI gameboard,Player player)
        {
            this.player = player;
            this.gameboard = gameboard;
            this.Controller = this.gameboard.GetController();
            this.inisialisasi();
            this.GenerateButton();
            this.Controller.SetPlayerSheepLocation(3, 0, 6, 0, GameBoardController.PLAYER.PLAYER1);
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
                            //render domba
                            BButton[j][i].Image = global::BattleSheep.Properties.Resources.sheep1;
                        }
                        else
                        {
                            BButton[j][i].Image = null;
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
                                    BButton[j][i].BackColor = Color.FromArgb(0, 0, 0);
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
                    K.MouseClick += K_Click;
                    K.Padding = new Padding(0);
                    K.Margin = new Padding(0);
                    K.FlatStyle = FlatStyle.Flat;
                    K.FlatAppearance.BorderSize = 1;
                    K.FlatAppearance.BorderColor = Color.FromArgb(125, 125, 125);
                    K.BackColor = Color.FromArgb(230, 230, 240);
                    K.TextAlign = ContentAlignment.MiddleCenter;
                    K.MouseEnter += K_MouseEnter;
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

            if (TempCoord[0]!=-1)
            {
                // jika rotasi
                if (!this.Controller.IsSheepLocation(baris,kolom, GameBoardController.PLAYER.PLAYER1))
                {
                    if (TempCoord[0] == TempCoord[2])
                    {
                        for (int i = TempCoord[1]; i <= TempCoord[3]; i++)
                        {
                            BButton[TempCoord[2]][i].Image = null;
                        }
                    }
                    // jika tidak berotasi
                    else if (TempCoord[1] == TempCoord[3])
                    {
                        //Console.WriteLine(TempCoord[0] + " " + TempCoord[1] + " " + TempCoord[2] + " " + TempCoord[3]);
                        for (int i = TempCoord[0]; i <= TempCoord[2]; i++)
                        {
                            BButton[i][TempCoord[1]].Image = null;
                        }
                    }
                }
            }
            else
            {
                if (rotate)
                {
                    if (baris + length <= 9)
                    {
                        for (int i = baris; i < baris + length; i++)
                        {
                            BButton[kolom][i].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                    else
                    {
                        for (int i = baris; i > baris - length; i--)
                        {
                            BButton[kolom][i].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                }
                else
                {
                    if (kolom + length <= 9)
                    {
                        for (int i = kolom; i < kolom + length; i++)
                        {
                            BButton[i][baris].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                    else
                    {
                        for (int i = kolom; i > kolom - length; i--)
                        {
                            BButton[i][baris].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                }
                //BButton[kolom][baris].BackColor = Color.FromArgb(230, 230, 240);
            }
        }

        private void K_MouseEnter(object sender, EventArgs e)
        {
            int length = this.SheepLengthList[this.SheepCounter];
            Button temp = (Button)sender;
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);
            this.gameboard.TestPlace.Text = baris + "," + kolom;
            //BButton[kolom][baris].Text = "S";
            if (rotate)
            {
                this.DrawVerticalSheep(kolom, baris, length);
            }
            else
            {
                this.DrawHorizontalSheep(kolom, baris, length);
            }
            //Console.WriteLine(baris + "," + kolom);
        }

        private void K_Click(object sender, EventArgs e)
        {
            int length = this.SheepLengthList[this.SheepCounter];
            int baris = Convert.ToInt32(((Button)sender).Name[0]);
            int kolom = Convert.ToInt32(((Button)sender).Name[1]);
            this.gameboard.TestPlace.Text = baris + "," + kolom;
            if (rotate)
            {
                if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom, baris + length - 1, GameBoardController.PLAYER.PLAYER1))
                {
                    this.Controller.SetPlayerSheepLocation(kolom, baris, kolom, baris + length, GameBoardController.PLAYER.PLAYER1);
                    if (this.SheepCounter < 4)
                        this.SheepCounter++;
                }
                else if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris - length + 1, kolom, baris, GameBoardController.PLAYER.PLAYER1))
                {
                    this.Controller.SetPlayerSheepLocation(kolom, baris - length + 1, kolom, baris + 1, GameBoardController.PLAYER.PLAYER1);
                    if (this.SheepCounter < 4)
                        this.SheepCounter++;
                }
            }
            else
            {
                if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom + length - 1, baris, GameBoardController.PLAYER.PLAYER1))
                {
                    this.Controller.SetPlayerSheepLocation(kolom, baris, kolom + length, baris, GameBoardController.PLAYER.PLAYER1);
                    if (this.SheepCounter < 4)
                        this.SheepCounter++;
                }
                else if (this.Controller.ConfirmPlayerSheepLocation(kolom - length + 1, baris, kolom, baris, GameBoardController.PLAYER.PLAYER1))
                {
                    this.Controller.SetPlayerSheepLocation(kolom - length + 1, baris, kolom + 1, baris, GameBoardController.PLAYER.PLAYER1);
                    if (this.SheepCounter < 4)
                        this.SheepCounter++;
                }
            }
            TempCoord[0] = -1;
            this.RenderBoardGUI(true);
        }

        public void ResetSheep()
        {
            this.Controller.ResetSheep(GameBoardController.PLAYER.PLAYER1);
            this.RenderBoardGUI(true);
            this.SheepCounter = 0;
        }

        public void RotateSheep()
        {
            rotate = !rotate;
        }

        private void DrawVerticalSheep(int kolom, int baris, int length)
        {
            if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom, baris + length - 1, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = baris; i < baris + length; i++)
                {
                    BButton[kolom][i].Image = global::BattleSheep.Properties.Resources.greysheep;
                }
                TempCoord[0] = kolom;
                TempCoord[1] = baris;
                TempCoord[2] = kolom;
                TempCoord[3] = baris + length - 1;
            }
            else if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris - length + 1, kolom, baris, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = baris; i > baris - length; i--)
                {
                    BButton[kolom][i].Image = global::BattleSheep.Properties.Resources.greysheep;
                }
                TempCoord[0] = kolom;
                TempCoord[1] = baris - length + 1;
                TempCoord[2] = kolom;
                TempCoord[3] = baris;
                //BButton[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
            }
            else
            {
                if (baris + length <= 9)
                {
                    for (int i = baris; i < baris + length; i++)
                    {
                        BButton[kolom][i].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                else
                {
                    for (int i = baris; i > baris - length; i--)
                    {
                        BButton[kolom][i].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                TempCoord[0] = -1;
            }
        }

        private void DrawHorizontalSheep(int kolom, int baris, int length)
        {
            if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom + length - 1, baris, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = kolom; i < kolom + length; i++)
                {
                    BButton[i][baris].Image = global::BattleSheep.Properties.Resources.greysheep;
                }
                TempCoord[0] = kolom;
                TempCoord[1] = baris;
                TempCoord[2] = kolom + length - 1;
                TempCoord[3] = baris;
            }
            else if (this.Controller.ConfirmPlayerSheepLocation(kolom - length + 1, baris, kolom, baris, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = kolom; i > kolom - length; i--)
                {
                    BButton[i][baris].Image = global::BattleSheep.Properties.Resources.greysheep;
                }
                TempCoord[0] = kolom - length + 1;
                TempCoord[1] = baris;
                TempCoord[2] = kolom;
                TempCoord[3] = baris;
                //BButton[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
            }
            else
            {
                if (kolom + length <= 9)
                {
                    for (int i = kolom; i < kolom + length; i++)
                    {
                        BButton[i][baris].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                else
                {
                    for (int i = kolom; i > kolom - length; i--)
                    {
                        BButton[i][baris].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                TempCoord[0] = -1;
            }
        }

    }
}
