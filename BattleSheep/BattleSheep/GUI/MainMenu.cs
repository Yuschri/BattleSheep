using System;
using BattleSheep.Controller;
using System.Windows.Forms;

namespace BattleSheep.GUI
{
    public partial class MainMenu : Panel
    {

        private Form parent;

        private MainMenuController controller;

        public MainMenu(Form Parent)
        {
            this.parent = Parent;
            this.controller = new MainMenuController(this.parent);
            InitializeComponent();
        }

        private void play_Click(object sender, EventArgs e)
        {
            this.controller.Play();
        }

        public Form GetParent()
        {
            return this.parent;
        }
    }
}
