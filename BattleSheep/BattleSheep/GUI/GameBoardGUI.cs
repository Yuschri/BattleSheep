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
            this.playerboard1 = new PlayerBoard(this);
            this.playerboard2 = new PlayerBoard(this);

            this.PlayerBoardPanel.Controls.Add(playerboard1);
            this.PlayerBoardPanel.Controls.Add(playerboard2);

            this.Controls.Add(PlayerBoardPanel);
        }

        private void Init()
        {
            this.PlayerBoardPanel.Size = new Size(740, 370);
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
