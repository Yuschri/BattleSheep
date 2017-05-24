using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using BattleSheep.Controller;
using BattleSheep.Object;

namespace BattleSheep.GUI
{
    class PlayerBoard : TableLayoutPanel
    {
        
        private List<List<Button>> BButton = new List<List<Button>>();

        private Player player;

        private GameBoardGUI Gameboard;

        private PlayerBoardController Controller;

        private TableLayoutPanel SheepArena = new TableLayoutPanel();

        private TableLayoutPanel TopPanel = new TableLayoutPanel();

        private FlowLayoutPanel TopPanelBawah = new FlowLayoutPanel();

        private Button RotateButton = new Button();

        private Button ResetButton = new Button();

        private Button StartButton = new Button();

        private Label Nama = new Label();

        private Label Diff = new Label();

        public PlayerBoard(GameBoardGUI gameboard,Player player)
        {
            this.Gameboard = gameboard;
            this.player = player;
            this.Controller = new PlayerBoardController(this, this.Gameboard.GetController());
            this.inisialisasi();
            this.GenerateButton();
            if (this.player.GetPlayerType() == GameBoardController.PLAYER.PLAYER1)
                this.Controller.RenderBoardGUI(true);
            else
                this.Controller.RenderBoardGUI(false);
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
                    K.FlatAppearance.BorderColor = Color.FromArgb(75, 75, 75);
                    K.BackColor = Color.FromArgb(145, 239, 91);//FromArgb(230, 230, 240)
                    K.TextAlign = ContentAlignment.MiddleCenter;
                    K.MouseEnter += K_MouseEnter;
                    K.MouseLeave += K_MouseLeave;
                    BButton[col].Add(K);
                    this.SheepArena.Controls.Add(BButton[col][row], col, row);
                }
            }
        }

        private void inisialisasi()
        {
            this.ColumnCount = 1;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowCount = 2;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.Size = new System.Drawing.Size(370, 450);
            this.TabIndex = 0;

            this.SheepArena.ColumnCount = 10;
            for (int i = 1; i <= 10; i++)
            {
                this.SheepArena.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            }
            this.SheepArena.Location = new System.Drawing.Point(12, 12);
            this.SheepArena.Name = "tableLayoutPanel1";
            this.SheepArena.RowCount = 10;
            for (int i = 1; i <= 10; i++)
            {
                this.SheepArena.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            }
            this.SheepArena.Dock = DockStyle.Fill;

            // Top Panel
            this.RotateButton.Margin = new Padding(5);
            this.RotateButton.BackColor = Color.FromArgb(230, 230, 240);
            this.RotateButton.Name = "rotate";
            this.RotateButton.Text = "Rotate";
            this.RotateButton.FlatStyle = FlatStyle.Flat;
            this.RotateButton.MouseClick += this.Controller.RotateSheep;

            this.ResetButton.Margin = new Padding(5);
            this.ResetButton.BackColor = Color.FromArgb(230, 230, 240);
            this.ResetButton.Name = "reset";
            this.ResetButton.Text = "Reset";
            this.ResetButton.FlatStyle = FlatStyle.Flat;
            this.ResetButton.MouseClick += this.Controller.ResetSheep;

            this.StartButton.Margin = new Padding(5);
            this.StartButton.BackColor = Color.FromArgb(230, 230, 240);
            this.StartButton.Name = "start";
            this.StartButton.Text = "Mulai";
            this.StartButton.FlatStyle = FlatStyle.Flat;
            this.StartButton.MouseClick += this.Controller.StartGame;
            this.StartButton.Enabled = false;

            this.Nama.Text = player.GetName();
            this.Nama.Font = new Font("Calibri", 14);
            this.Nama.Dock = DockStyle.Bottom;

            string diff;

            if (Strategy.Strategy.DIFFICULT.EASY==this.Gameboard.GetController().GetDifficult())
            {
                diff = "Easy";
            }
            else if(Strategy.Strategy.DIFFICULT.MEDIUM == this.Gameboard.GetController().GetDifficult())
            {
                diff = "Medium";
            }
            else
            {
                diff = "Hard";
            }

            this.Diff.Text = diff;
            this.Diff.Font = new Font("Calibri", 12);
            this.Diff.Dock = DockStyle.Top;

            this.TopPanel.Dock = DockStyle.Fill;
            this.TopPanel.ColumnCount = 1;
            this.TopPanel.RowCount = 2;
            this.TopPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.TopPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.TopPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // panel bawah untuk TopPanel bagian bawah jadi 2 kolom
            this.TopPanelBawah.FlowDirection = FlowDirection.LeftToRight;
            this.TopPanel.Controls.Add(this.TopPanelBawah,0,1);
            this.TopPanelBawah.Dock = DockStyle.Fill;
            /*
            this.TopPanelBawah.Dock = DockStyle.Fill;
            this.TopPanelBawah.ColumnCount = 3;
            this.TopPanelBawah.RowCount = 1;
            this.TopPanelBawah.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1F));
            this.TopPanelBawah.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1F));
            this.TopPanelBawah.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1F));
            this.TopPanelBawah.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.TopPanelBawah.Padding = new Padding(0);
            this.TopPanel.Controls.Add(TopPanelBawah, 0, 1);
            */

            if (!this.player.IsCPU())
            {
                this.TopPanelBawah.Controls.Add(this.RotateButton);
                this.TopPanelBawah.Controls.Add(this.ResetButton);
                this.TopPanelBawah.Controls.Add(this.StartButton);
                this.TopPanel.Controls.Add(this.Nama, 0, 0);
            }
            else
            {
                this.TopPanel.Controls.Add(this.Nama, 0, 0);
                this.TopPanel.Controls.Add(this.Diff, 1, 0);
            }

            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.SheepArena);
            
        }

        private void K_MouseLeave(object sender, EventArgs e)
        {
            this.Controller.MouseLeave((Button) sender);
        }

        private void K_MouseEnter(object sender, EventArgs e)
        {
            this.Controller.MouseEnter((Button)sender);
        }

        private void K_Click(object sender, EventArgs e)
        {
            this.Controller.MouseClick((Button) sender);
        }

        public Button GetResetButton()
        {
            return this.ResetButton;
        }

        public Button GetRotateButton()
        {
            return this.RotateButton;
        }

        public Button GetStartButton()
        {
            return this.StartButton;
        }

        internal Player GetPlayer()
        {
            return this.player;
        }

        public List<List<Button>> GetBButton()
        {
            return this.BButton;
        }

        public GameBoardGUI GetGameBoard()
        {
            return this.Gameboard;
        }

        public PlayerBoardController GetController()
        {
            return this.Controller;
        }

    }
}
