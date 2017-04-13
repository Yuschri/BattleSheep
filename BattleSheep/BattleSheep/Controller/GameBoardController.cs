﻿using System;
using System.Collections.Generic;
using System.Linq;
using BattleSheep.Object;

namespace BattleSheepConsole
{
    class GameBoardController
    {

        public enum PLAYER
        {
            PLAYER1, PLAYER2
        }

        private Player Player1;

        private Player Player2;

        /**
         * Melakukan inisialisasi GameBoard dengan syrata memasukkan
         * nama kedua player
         */
        public GameBoardController(string Player1Name, string Player2Name)
        {
            Player1 = new Player(Player1Name);
            Player2 = new Player(Player2Name);
        }

        /**
         * Jika player 2 adalah CPU, maka cukup menggunakan konstruktor
         * dengan satu parameter
         */
        public GameBoardController(string Player1Name)
        {
            Player1 = new Player(Player1Name);
            Player2 = new Player("CPU");
            Player2.IsCPU(true);
        }

        /**
         * Rendering board
         */
        public void RenderBoard()
        {
            // Cetak baris atas
            Console.Write("  ");
            for (int j = 0; j < 10; j++)
                Console.Write("  " + j + " ");
            Console.WriteLine();
            for (int i = 0; i <= 42; i++)
            {
                Console.Write('_');
            }
            Console.WriteLine();
            // Cetak Isi
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0)
                        Console.Write("| ");
                    if (Player2.GetAttacked()[i, j] == 'O')
                    {
                        if (Player2.GetSheepMap()[i, j] == 'X')
                            Console.Write("H | ");
                        else
                            Console.Write(Player2.GetAttacked()[i, j] + " | ");
                    }
                    else
                        Console.Write(Player2.GetAttacked()[i, j] + " | ");
                }
                Console.WriteLine();
                for (int k = 0; k <= 40; k++)
                {
                    Console.Write('_');
                }
                Console.WriteLine();
            }
        }

        /**
         * Mereset Semua kapal
         */
        public void ResetSheep(PLAYER Player)
        {
            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;
            Pl.SetSheepMap(new char[10, 10]);
            Pl.SetSheep(new List<Sheep>());
        }

        /**
         * Meletakkan kapal player pada map
         */
        public void SetPlayerSheepLocation(
            int ColFrom,
            int RowFrom,
            int ColUntil,
            int RowUntil,
            PLAYER Player)
        {
            ColFrom--;
            RowFrom--;
            ColUntil--;
            RowUntil--;

            Sheep Domba = new Sheep();
            Domba.SetLocation(RowFrom, ColFrom, RowUntil, ColUntil);

            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;

            Pl.AddSheep(Domba);
            // Jika berotasi
            if (RowUntil != RowFrom)
            {
                for (int row = RowFrom; row < RowUntil; row++)
                    Pl.AddSheepMap(row, ColFrom);
            }
            // Jika tidak berotasi
            else
            {
                for (int col = ColFrom; col < ColUntil; col++)
                    Pl.AddSheepMap(RowFrom, col);
            }
        }

        /**
         * Memastikan agar posisi kapal menepati ruang kosong pada map
         * dan tidak menempel dengan kapal lain
         */
        public bool ConfirmPlayerSheepLocation(
            int ColFrom,
            int RowFrom,
            int ColUntil,
            int RowUntil,
            PLAYER Player
            )
        {
            ColFrom--;
            RowFrom--;
            ColUntil--;
            RowUntil--;

            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;

            // Jika berotasi
            if (RowUntil != RowFrom)
            {
                for (int row = RowFrom; row < RowUntil; row++)
                {

                    if (Pl.GetSheepMap()[row, ColFrom] == 'X' ||
                        !CheckDiagonalSheep(row, ColFrom, Player) ||
                        !CheckHorticalSheep(row, ColFrom, Player))
                        return false;
                }
            }
            // Jika tidak berotasi
            else
            {
                for (int col = ColFrom; col < ColUntil; col++)
                {
                    if (Pl.GetSheepMap()[RowFrom, col] == 'X' ||
                        !CheckDiagonalSheep(RowFrom, col, Player) ||
                        !CheckHorticalSheep(RowFrom, col, Player))
                        return false;
                }
            }
            return true;
        }

        /**
         * Memastikan agar blok yang dpilih memiliki jarak antar kapal lain
         * secara horizontal dan vertical
         */
        private bool CheckHorticalSheep(int row, int col, PLAYER Player)
        {
            bool top = false;
            bool bottom = false;
            bool right = false;
            bool left = false;

            bottom = (row >= 0 && row < 9) ? true : false;
            top = (row > 0 && row <= 9) ? true : false;
            right = (col >= 0 && col < 9) ? true : false;
            left = (col > 0 && col <= 9) ? true : false;

            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;

            if ((top && Pl.GetSheepMap()[row - 1, col] == 'X') ||
                (bottom && Pl.GetSheepMap()[row + 1, col] == 'X') ||
                (left && Pl.GetSheepMap()[row, col - 1] == 'X') ||
                (right && Pl.GetSheepMap()[row, col + 1] == 'X'))
                return false;
            return true;
        }

        /**
         * Memastikan terdapat kapal yang tidak bersebelahan dengan
         * kapal lain secara diagonal
         */
        private bool CheckDiagonalSheep(int row, int col, PLAYER Player)
        {
            bool topRight = false;
            bool topLeft = false;
            bool bottomRight = false;
            bool bottomLeft = false;

            bottomLeft = (row < 9 && col > 0) ? true : false;
            bottomRight = (row < 9 && col < 9) ? true : false;
            topLeft = (row > 0 && col > 0) ? true : false;
            topRight = (row > 0 && col < 9) ? true : false;

            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;

            if ((topLeft && Pl.GetSheepMap()[row - 1, col - 1] == 'X') ||
                (topRight && Pl.GetSheepMap()[row - 1, col + 1] == 'X') ||
                (bottomLeft && Pl.GetSheepMap()[row + 1, col - 1] == 'X') ||
                (bottomRight && Pl.GetSheepMap()[row + 1, col + 1] == 'X'))
                return false;
            return true;
        }

        /**
         * Melakukan serangan pada sebuah blok ke pemain lain
         */
        public void SetAttack(int row, int col, PLAYER AttackFor)
        {

            Player Pl = (AttackFor == PLAYER.PLAYER1) ? Player1 : Player2;

            //Console.WriteLine(row + " " + col);
            Pl.GetAttacked()[row, col] = 'O';
            //Player2Turn++;
            if (Pl.GetSheepMap()[row, col] == 'X')
            {
                Sheep Domba = this.GetSheep(row, col, PLAYER.PLAYER2);
                Domba.SetAttack();
            }
            if (!IsSuccessAttack(row, col, PLAYER.PLAYER2))
                Player2.AddTurn();
            //Console.WriteLine("Turn : " + Player2Turn);
        }

        public void ResetAttack(PLAYER PlayerBoard)
        {
            Player Pl = (PlayerBoard == PLAYER.PLAYER1) ? Player1 : Player2;
            Pl.ResetAttack();
        }

        /**
         * Memastikan sebuah blok dapat diserang atau tidak
         */
        public bool AllowAttack(int row, int col, PLAYER AttackFor)
        {
            return (row > 9 || row < 0 || col > 9 || col < 0) ? false : !HasAttacked(row, col, AttackFor);
        }

        /**
         * Memastikan sebuah blok pernah diserang sebelumnya atau tidak
         */
        private bool HasAttacked(int row, int col, PLAYER AttackFor)
        {
            Player Pl = (AttackFor == PLAYER.PLAYER1) ? Player1 : Player2;
            return (Pl.GetAttacked()[row, col] == 'O');
        }

        /**
         * Mengecek apakah sudah ada pemenang
         */
        public bool HasWinner()
        {
            // Jika jumlah putaran player kurang dari 12 putaran
            // artinya, tidak mungkin dalam jumlah putaran tersebut
            // ada pemain yang bisa menang. IMPOSSIBLE !!
            if (Player2.GetTurn() < 12)
                return false;
            else
            {
                // Mengecek jumlah kapal yang hancur pada player 2
                int Player2DestroyedSheep = 0;
                for (int i = 0; i < Player2.GetSheep().Count(); i++)
                {
                    if (Player2.GetSheep()[i].IsDestroyed())
                        Player2DestroyedSheep++;
                }
                if (Player2DestroyedSheep == Player2.GetSheep().Count())
                {
                    Player2.SetAsWinner();
                    return true;
                }
            }
            return false;
        }

        public bool IsSuccessAttack(int row, int col, PLAYER Player)
        {

            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;

            if (row > 9 || row < 0 || col > 9 || col < 0)
                return false;
            else
            {
                if (Pl.GetAttacked()[row, col] == 'O' && Pl.GetSheepMap()[row, col] == 'X')
                    return true;
            }
            return false;
        }

        /**
         * Memastikan apakah sebuah blok merupakan sebuah kapal
         */
        public bool IsSheepLocation(int row, int col, PLAYER Player)
        {
            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;
            return (Pl.GetSheepMap()[row, col] == 'X');
        }

        public bool IsDestroyedBlock(int row, int col, PLAYER Player)
        {
            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;
            return (Pl.GetAttacked()[row, col] == 'O' && Pl.GetSheepMap()[row, col] == 'X');
        }

        /**
         * Memastikan siapa pememang permainan
         */
        public Player GetWinner()
        {
            return (Player1.IsWinner()) ? Player1 : (Player2.IsWinner()) ? Player2 : null;
        }

        public Sheep GetSheep(int row, int col, PLAYER Player)
        {
            Sheep sheep = new Sheep();

            Player Pl = (Player == PLAYER.PLAYER1) ? Player1 : Player2;

            for (int i = 0; i < Pl.GetSheep().Count; i++)
            {
                if (Pl.GetSheep()[i].IsSheepLocation(row, col))
                    return Pl.GetSheep()[i];
            }
            return sheep;
        }

        public Player GetPlayer(PLAYER Player)
        {
            return (Player == PLAYER.PLAYER1) ? Player1 : Player2;
        }

    }

}
