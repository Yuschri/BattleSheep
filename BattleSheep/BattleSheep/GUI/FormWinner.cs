using System;
using System.Windows.Forms;

namespace BattleSheep.GUI
{
    public partial class FormWinner : Form
    {

        private Form parent;

        private GameBoardGUI gameboard;

        public FormWinner(GameBoardGUI gameboard)
        {
            this.parent = gameboard.GetParent();
            this.gameboard = gameboard;
            InitializeComponent();
        }

        private void PlayAgain(object sender, EventArgs e)
        {
            this.gameboard.GetController().ResetGame();
            this.gameboard.GetController().SetGameState(Controller.GameBoardController.STATE.PUTSHEEP);
            this.gameboard.GetPlayerBoardController(Controller.GameBoardController.PLAYER.PLAYER1).RenderBoardGUI(true);
            this.gameboard.GetPlayerBoardController(Controller.GameBoardController.PLAYER.PLAYER2).RenderBoardGUI(false);
            this.gameboard.GetPlayerBoardController(Controller.GameBoardController.PLAYER.PLAYER1).ResetGame();
            this.gameboard.status.Text = "Taruh Domba";
            this.Close();
        }

        private void BackToMenu(object sender, EventArgs e)
        {
            this.Close();
            this.parent.Controls.Clear();
            this.parent.Size = MainForm.size;
            this.parent.Controls.Add(new MainMenu(this.parent));
        }

        public void setInfo(string info)
        {
            this.menang.Text = info;
        }

    }
}
