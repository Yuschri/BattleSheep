using System.Windows.Forms;
using BattleSheep.GUI;
using BattleSheep.Object;
using System.Drawing;
using System;

namespace BattleSheep.Controller
{
    class PlayerBoardController
    {

        private PlayerBoard playerBoard;

        private GameBoardController Controller;

        private int[] SheepLengthList = new int[] { 2, 2, 3, 4, 5 };

        private int SheepCounter = 0;

        //simpan koordinat hover
        //[0] = colfrom, [1] = rowfrom, [2] = coluntil, [3] = rowuntil
        private int[] TempCoord = new int[4];

        private bool rotate = false;

        private Player player;

        public PlayerBoardController(PlayerBoard playerBoard, GameBoardController Controller)
        {
            this.playerBoard = playerBoard;
            this.Controller = Controller;
            this.player = this.playerBoard.GetPlayer();
        }

        public void RenderBoardGUI(bool ShowSheep)
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
                        if (this.Controller.GetPlayer(this.player.GetPlayerType()).GetSheepMap()[i, j] == 'X')
                        {
                            //render domba
                            this.playerBoard.GetBButton()[j][i].Image = global::BattleSheep.Properties.Resources.sheep1;
                        }
                        else
                        {
                            this.playerBoard.GetBButton()[j][i].Image = null;
                        }
                        if (this.Controller.GetPlayer(this.player.GetPlayerType()).GetAttacked()[i, j] == 'O')
                        {
                            if (this.Controller.GetPlayer(this.player.GetPlayerType()).GetSheepMap()[i, j] == 'X')
                            {
                                //render jika domba kena serangan
                                this.playerBoard.GetBButton()[j][i].Image = global::BattleSheep.Properties.Resources.sheep1;
                            }
                            else
                            {
                                //BButton[j][i].Image = global::BattleSheep.Properties.Resources.sheep1;
                                this.playerBoard.GetBButton()[j][i].BackColor = Color.FromArgb(0, 0, 0);
                            }
                            //Console.Write(this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetAttacked()[i, j] + " | ");
                        }

                        //Console.Write(this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1).GetAttacked()[i, j] + " | ");
                        //}
                    }
                }
            }
        }

        public void MouseLeave(Button temp)
        {
            int length = (this.SheepCounter < this.SheepLengthList.Length) ? this.SheepLengthList[this.SheepCounter] : this.SheepLengthList[this.SheepCounter - 1];
            int baris = Convert.ToInt32((temp).Name[0]);
            int kolom = Convert.ToInt32((temp).Name[1]);

            if (TempCoord[0] != -1)
            {
                // jika rotasi
                if (!this.Controller.IsSheepLocation(baris, kolom, GameBoardController.PLAYER.PLAYER1))
                {
                    if (TempCoord[0] == TempCoord[2])
                    {
                        for (int i = TempCoord[1]; i <= TempCoord[3]; i++)
                        {
                            this.playerBoard.GetBButton()[TempCoord[2]][i].Image = null;
                        }
                    }
                    // jika tidak berotasi
                    else if (TempCoord[1] == TempCoord[3])
                    {
                        //Console.WriteLine(TempCoord[0] + " " + TempCoord[1] + " " + TempCoord[2] + " " + TempCoord[3]);
                        for (int i = TempCoord[0]; i <= TempCoord[2]; i++)
                        {
                            this.playerBoard.GetBButton()[i][TempCoord[1]].Image = null;
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
                            this.playerBoard.GetBButton()[kolom][i].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                    else
                    {
                        for (int i = baris; i > baris - length; i--)
                        {
                            this.playerBoard.GetBButton()[kolom][i].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                }
                else
                {
                    if (kolom + length <= 9)
                    {
                        for (int i = kolom; i < kolom + length; i++)
                        {
                            this.playerBoard.GetBButton()[i][baris].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                    else
                    {
                        for (int i = kolom; i > kolom - length; i--)
                        {
                            this.playerBoard.GetBButton()[i][baris].BackColor = Color.FromArgb(230, 230, 240);
                        }
                    }
                }
                //BButton[kolom][baris].BackColor = Color.FromArgb(230, 230, 240);
            }
        }

        public void MouseEnter(Button temp)
        {
            if (this.Controller.GetGameState() == GameBoardController.STATE.PUTSHEEP)
            {
                if (this.Controller.GetCurrentPlayer() == this.player.GetPlayerType())
                {
                    int length = (this.SheepCounter < this.SheepLengthList.Length) ? this.SheepLengthList[this.SheepCounter] : this.SheepLengthList[this.SheepCounter - 1];
                    int baris = Convert.ToInt32((temp).Name[0]);
                    int kolom = Convert.ToInt32((temp).Name[1]);
                    //this.gameboard.TestPlace.Text = baris + "," + kolom;
                    //BButton[kolom][baris].Text = "S";
                    if (rotate)
                    {
                        this.DrawVerticalSheep(kolom, baris, length);
                    }
                    else
                    {
                        this.DrawHorizontalSheep(kolom, baris, length);
                    }
                }
            }
            //Console.WriteLine(baris + "," + kolom);
        }

        public void MouseClick(Button temp)
        {
            if (this.Controller.GetGameState() == GameBoardController.STATE.PUTSHEEP)
            {
                if (this.Controller.GetCurrentPlayer() == this.player.GetPlayerType())
                {
                    int length = this.SheepLengthList[this.SheepCounter];
                    int baris = temp.Name[0];
                    int kolom = temp.Name[1];
                    //this.gameboard.TestPlace.Text = baris + "," + kolom;
                    if (rotate)
                    {
                        this.SetVerticalSheep(kolom, baris, length);
                    }
                    else
                    {
                        this.SetHorizontalSheep(kolom, baris, length);
                    }
                    TempCoord[0] = -1;
                    this.RenderBoardGUI(true);
                }
            }
        }

        public void ResetSheep(object sender, EventArgs args)
        {
            this.Controller.ResetSheep(this.player.GetPlayerType());
            this.RenderBoardGUI(true);
            this.SheepCounter = 0;
        }

        public void RotateSheep(object sender, EventArgs args)
        {
            rotate = !rotate;
        }

        private void DrawVerticalSheep(int kolom, int baris, int length)
        {
            if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom, baris + length - 1, GameBoardController.PLAYER.PLAYER1))
            {
                for (int i = baris; i < baris + length; i++)
                {
                    this.playerBoard.GetBButton()[kolom][i].Image = global::BattleSheep.Properties.Resources.greysheep;
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
                    this.playerBoard.GetBButton()[kolom][i].Image = global::BattleSheep.Properties.Resources.greysheep;
                }
                TempCoord[0] = kolom;
                TempCoord[1] = baris - length + 1;
                TempCoord[2] = kolom;
                TempCoord[3] = baris;
                //this.playerBoard.GetBButton()[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
            }
            else
            {
                if (baris + length <= 9)
                {
                    for (int i = baris; i < baris + length; i++)
                    {
                        this.playerBoard.GetBButton()[kolom][i].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                else
                {
                    for (int i = baris; i > baris - length; i--)
                    {
                        this.playerBoard.GetBButton()[kolom][i].BackColor = Color.FromArgb(225, 90, 90);
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
                    this.playerBoard.GetBButton()[i][baris].Image = global::BattleSheep.Properties.Resources.greysheep;
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
                    this.playerBoard.GetBButton()[i][baris].Image = global::BattleSheep.Properties.Resources.greysheep;
                }
                TempCoord[0] = kolom - length + 1;
                TempCoord[1] = baris;
                TempCoord[2] = kolom;
                TempCoord[3] = baris;
                //this.playerBoard.GetBButton()[kolom][baris].Image = global::BattleSheep.Properties.Resources.sheep1;
            }
            else
            {
                if (kolom + length <= 9)
                {
                    for (int i = kolom; i < kolom + length; i++)
                    {
                        this.playerBoard.GetBButton()[i][baris].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                else
                {
                    for (int i = kolom; i > kolom - length; i--)
                    {
                        this.playerBoard.GetBButton()[i][baris].BackColor = Color.FromArgb(225, 90, 90);
                    }
                }
                TempCoord[0] = -1;
            }
        }

        private void SetVerticalSheep(int kolom, int baris, int length)
        {
            if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom, baris + length - 1, GameBoardController.PLAYER.PLAYER1))
            {
                this.Controller.SetPlayerSheepLocation(kolom, baris, kolom, baris + length, GameBoardController.PLAYER.PLAYER1);
                if (this.SheepCounter < this.SheepLengthList.Length)
                    this.SheepCounter++;
            }
            else if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris - length + 1, kolom, baris, GameBoardController.PLAYER.PLAYER1))
            {
                this.Controller.SetPlayerSheepLocation(kolom, baris - length + 1, kolom, baris + 1, GameBoardController.PLAYER.PLAYER1);
                if (this.SheepCounter < this.SheepLengthList.Length)
                    this.SheepCounter++;
            }
            if (this.SheepCounter == this.SheepLengthList.Length)
            {
                this.Controller.SetGameState(GameBoardController.STATE.PLAYING);
                this.playerBoard.GetRotateButton().Enabled = false;
                this.playerBoard.GetResetButton().Enabled = false;
            }
        }

        private void SetHorizontalSheep(int kolom, int baris, int length)
        {
            if (this.Controller.ConfirmPlayerSheepLocation(kolom, baris, kolom + length - 1, baris, GameBoardController.PLAYER.PLAYER1))
            {
                this.Controller.SetPlayerSheepLocation(kolom, baris, kolom + length, baris, GameBoardController.PLAYER.PLAYER1);
                if (this.SheepCounter < this.SheepLengthList.Length)
                    this.SheepCounter++;
            }
            else if (this.Controller.ConfirmPlayerSheepLocation(kolom - length + 1, baris, kolom, baris, GameBoardController.PLAYER.PLAYER1))
            {
                this.Controller.SetPlayerSheepLocation(kolom - length + 1, baris, kolom + 1, baris, GameBoardController.PLAYER.PLAYER1);
                if (this.SheepCounter < this.SheepLengthList.Length)
                    this.SheepCounter++;
            }
            if (this.SheepCounter == this.SheepLengthList.Length)
            {
                this.Controller.SetGameState(GameBoardController.STATE.PLAYING);
                this.playerBoard.GetRotateButton().Enabled = false;
                this.playerBoard.GetResetButton().Enabled = false;
            }
        }

    }
}
