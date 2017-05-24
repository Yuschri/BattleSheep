using System.Windows.Forms;
using BattleSheep.GUI;
using System.Drawing;
using System.Media;

namespace BattleSheep.Controller
{
    class MainMenuController
    {

        private Form parent;

        private Form inputname;

        public MainMenuController(Form parent)
        {
            this.parent = parent;
        }

        public void Play()
        {
            inputname = new InputNamaForm(this.parent);
            inputname.ShowDialog();
        }
    }
}
