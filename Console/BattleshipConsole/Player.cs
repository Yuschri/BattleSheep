using System;
using System.Collections.Generic;

namespace BattleSheepConsole
{
    class Player
    {

        private string Name;

        private bool Win = false;

        private int Turn;

        private bool CPU = false;

        private List<Sheep> Sheep = new List<Sheep>();

        public Player(string Name)
        {
            this.Name = Name;
        }

        public string GetName()
        {
            return Name;
        }

        public bool IsWin()
        {
            WinChecking();
            return Win;
        }

        public bool IsCPU()
        {
            return CPU;
        }

        public void SetSheep(List<Sheep> Sheep)
        {
            this.Sheep = Sheep;
        }

        public void AddSheep(Sheep Sheep)
        {
            this.Sheep.Add(Sheep);
        }

        public void IsCPU(bool Flag)
        {
            this.CPU = Flag;
        }

        private void WinChecking()
        {

        }

    }
}
