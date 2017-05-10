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
            this.Controller = new GameBoardController("Bagas");
            this.Controller.SetGameState(GameBoardController.STATE.PUTSHEEP);
            this.Controller.SetCurrentPlayer(GameBoardController.PLAYER.PLAYER1);
            FControl = Parent;
            InitializeComponent();
            Init();
        }

        private void GeneratePlayerBoard()
        {
            this.playerboard1 = new PlayerBoard(this,this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER1));
            this.playerboard2 = new PlayerBoard(this,this.Controller.GetPlayer(GameBoardController.PLAYER.PLAYER2));

            this.PlayerBoardPanel.Controls.Add(playerboard1);
            this.PlayerBoardPanel.Controls.Add(playerboard2);

            this.Controls.Add(PlayerBoardPanel);
        }

        private void Init()
        {
            this.PlayerBoardPanel.Size = new Size(740, 400);
            this.PlayerBoardPanel.Location = new Point(0,50);
            this.PlayerBoardPanel.ColumnCount = 2;
            this.PlayerBoardPanel.RowCount = 1;
            this.PlayerBoardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.PlayerBoardPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.PlayerBoardPanel.RowStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.GeneratePlayerBoard();
        }

        internal GameBoardController GetController()
        {
            return this.Controller;
        }

    }
}
