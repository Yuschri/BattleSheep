using System;
using System.Windows.Forms;
using System.Drawing;

namespace BattleSheep.GUI
{
    public partial class MainForm : Form
    {

        public static Size size = new Size(284,400);

        public MainForm()
        {
            InitializeComponent();
            this.Controls.Add(new MainMenu(this));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //PlaySound();
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += new DoWorkEventHandler(this.PlaySound);
            //bw.RunWorkerAsync();
        }

        private void PlaySound()
        {
            System.IO.Stream music = Properties.Resources.Splashing_Around;
            System.Media.SoundPlayer p1 = new System.Media.SoundPlayer(music);
            p1.PlayLooping();
        }
    }
}
