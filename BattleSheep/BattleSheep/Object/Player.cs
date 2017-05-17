using System.Collections.Generic;
using BattleSheep.Controller;

namespace BattleSheep.Object
{
    class Player
    {

        /**
         * Nama Player
         */
        private string Name;

        /**
         * Flag untuk mengecek kemenangan
         */
        private bool Win = false;

        /**
         * Jumlah turn
         */
        private int Turn = 0;

        private GameBoardController.PLAYER PlayerType;

        private bool CPU = false;

        /**
         * Daftar Domba berdasarkan Map
         */
        private char[,] SheepMap = new char[10, 10];

        /**
         * Daftar Serangan terhadap domba player ini
         */
        private char[,] AttackedSheepMap = new char[10, 10];

        /**
         * Daftar Domba
         */
        private List<Sheep> Sheep = new List<Sheep>();

        /**
         * Memberi nama player
         */
        public Player(string Name)
        {
            this.Name = Name;
        }

        /**
         * Mendapatan nama player
         */
        public string GetName()
        {
            return Name;
        }

        /**
         * Mengatur jenis pemain
         */
        public void SetPlayerType(GameBoardController.PLAYER PlayerType)
        {
            this.PlayerType = PlayerType;
        }

        public GameBoardController.PLAYER GetPlayerType()
        {
            return this.PlayerType;
        }

        /**
         * Melihat apakah player dinyatakan menang
         */
        public bool IsWin()
        {
            WinChecking();
            return Win;
        }

        /**
         * Melihat apakah player adalah CPU
         */
        public bool IsCPU()
        {
            return CPU;
        }

        public void SetSheep(List<Sheep> Sheep)
        {
            this.Sheep = Sheep;
        }

        public List<Sheep> GetSheep()
        {
            return this.Sheep;
        }

        public void AddAttacked(int row, int col)
        {
            this.AttackedSheepMap[row, col] = 'O';
        }

        public char[,] GetAttacked()
        {
            return this.AttackedSheepMap;
        }

        public void ResetAttack()
        {
            this.AttackedSheepMap = new char[10, 10];
            for (int i = 0; i < this.Sheep.Count; i++)
            {
                this.Sheep[i].ResetAttack();
            }
        }

        public void AddSheep(Sheep Sheep)
        {
            this.Sheep.Add(Sheep);
        }

        public void SetSheepMap(char[,] SheepMap)
        {
            this.SheepMap = SheepMap;
        }

        public void AddSheepMap(int row, int col)
        {
            this.SheepMap[row, col] = 'X';
        }

        public char[,] GetSheepMap()
        {
            return this.SheepMap;
        }

        public void IsCPU(bool Flag)
        {
            this.CPU = Flag;
        }

        public void SetAsWinner()
        {
            this.Win = true;
        }

        public void SetAsLose()
        {
            this.Win = false;
        }

        public bool IsWinner()
        {
            return this.Win;
        }

        private void WinChecking()
        {

        }

        public int GetTurn()
        {
            return this.Turn;
        }

        public void AddTurn()
        {
            Turn++;
        }

        public void Reset()
        {
            this.Turn = 0;
            this.Sheep = new List<Sheep>();
            this.AttackedSheepMap = new char[10, 10];
            this.SetAsLose();
        }

    }
}
