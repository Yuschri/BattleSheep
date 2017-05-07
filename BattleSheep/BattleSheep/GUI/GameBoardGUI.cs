using System;
using System.Drawing;
using System.Windows.Forms;
using BattleSheep.Controller;

namespace BattleSheep.GUI
{
    public partial class GameBoardGUI : Panel
    {

        Control FControl;

        /**
         * Daftar Status pada GameBoard
         */
        public enum STATE
        {
            PLAYING, PUTSHEEP
        }

        /**
         * Status dari GameBoard
         */
        public STATE Status;

        /**
         * Panel untuk membuat dua layout Board bagian kana dan kiri
         */
        private TableLayoutPanel PlayerBoardPanel = new TableLayoutPanel();

        /**
         * Player Board untuk player 1
         */
        private PlayerBoard playerboard1;
        private Button reset = new Button();
        private Button rotate = new Button();
        private TableLayoutPanel PanelAtas = new TableLayoutPanel();

        /**
         * Player Board untuk player 2
         */
        private PlayerBoard playerboard2;

        private GameBoardController Controller;

        public GameBoardGUI(Control Parent)
        {
            this.Status = STATE.PUTSHEEP;
            this.Controller = new GameBoardController("Bagas");
            FControl = Parent;
            InitializeComponent();
            Init();
        }

        private void GeneratePlayerBoard()
        {
            this.playerboard1 = new PlayerBoard(this,this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1));
            this.playerboard2 = new PlayerBoard(this,this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1));

            this.PlayerBoardPanel.Controls.Add(playerboard1);
            this.PlayerBoardPanel.Controls.Add(playerboard2);

            this.Controls.Add(PanelAtas);

            this.Controls.Add(PlayerBoardPanel);
        }

        private void Init()
        {
            this.PlayerBoardPanel.Size = new Size(740, 370);
            this.PlayerBoardPanel.Location = new Point(0,50);
            this.PlayerBoardPanel.ColumnCount = 2;
            this.PlayerBoardPanel.RowCount = 1;
            this.PlayerBoardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.PlayerBoardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.PlayerBoardPanel.RowStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.GeneratePanelAtas();
            this.GeneratePlayerBoard();
        }

        private void GeneratePanelAtas()
        {
            this.PanelAtas.Size = new Size(740, 50);
            this.PanelAtas.BackColor = Color.Azure;
            //this.reset.Size = new Size(50, 10);
            this.rotate.Margin = new Padding(12);
            this.rotate.BackColor = Color.FromArgb(230, 230, 240);
            this.rotate.Name = "rotate";
            this.rotate.Text = "Rotate";
            this.rotate.FlatStyle = FlatStyle.Flat;
            this.rotate.MouseClick += Rotate_MouseClick;
            this.PanelAtas.Controls.Add(rotate);

            this.reset.Margin = new Padding(12);
            this.reset.BackColor = Color.FromArgb(230, 230, 240);
            this.reset.Name = "reset";
            this.reset.Text = "Reset";
            this.reset.FlatStyle = FlatStyle.Flat;
            this.reset.MouseClick += Reset_MouseClick;
            this.PanelAtas.Controls.Add(reset);
            
        }

        private void Rotate_MouseClick(object sender, MouseEventArgs e)
        {
            playerboard1.RotateSheep();
        }

        private void Reset_MouseClick(object sender, MouseEventArgs e)
        {
            playerboard1.ResetSheep();
        }

        internal GameBoardController GetController()
        {
            return this.Controller;
        }

    }
}
