﻿using System;
using System.Collections.Generic;

namespace BattleSheepConsole.Strategy
{
    class AI
    {

        public enum DIFFICULT
        {
            EASY, MEDIUM, EXPERT
        }

        public enum WAY
        {
            TOP, BOTTOM, LEFT, RIGHT
        }

        public enum STRATEGY
        {
            RANDOM, FROMTOP, FROMBOTTOM, FROMLEFT, FROMRIGHT
        }

        protected Random Rand = new Random();

        protected GameBoardController Board;

        protected int lastAttackSuccessRow = -1;

        protected int lastAttackSuccessCol = -1;

        protected GameBoardController.PLAYER target = GameBoardController.PLAYER.PLAYER2;

        /**
         * Jenis difficult
         * 
         * Easy, Medium, atau Expert
         */
        protected DIFFICULT Difficult;

        /**
         * Strategy yang dipilih
         */
        protected AI Strategy;

        /**
         * Nama dari Strategy yang dipilih
         */
        private string Name;

        /**
         * Daftar panjang domba yang akan di pasang pada GameBoard
         */
        private int[] SheepPlan;

        public AI(GameBoardController Board)
        {
            this.Board = Board;
        }

        public AI(GameBoardController Board, DIFFICULT Difficult)
        {
            this.Board = Board;
            this.Difficult = Difficult;
            if (Difficult == DIFFICULT.EASY)
            {
                RandomAttackAI Strategy = new RandomAttackAI(Board);
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
            else if(Difficult == DIFFICULT.MEDIUM)
            {
                FromBottomAttackAI Strategy = new FromBottomAttackAI(Board);
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
            else
            {
                this.GenerateStrategy();
            }
        }

        public void UseInsteadAI(AI AI)
        {
            if(AI is FromTopAttackAI)
            {
                FromTopAttackAI Strategy = (FromTopAttackAI) AI;
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
            else if (AI is FromBottomAttackAI)
            {
                FromBottomAttackAI Strategy = (FromBottomAttackAI) AI;
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
            else if (AI is FromLeftAttackAI)
            {
                FromLeftAttackAI Strategy = (FromLeftAttackAI) AI;
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
            else if (AI is FromRightAttackAI)
            {
                FromRightAttackAI Strategy = (FromRightAttackAI) AI;
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
            else
            {
                RandomAttackAI Strategy = (RandomAttackAI) AI;
                this.Strategy = Strategy;
                this.Name = Strategy.GetName();
            }
        }

        /**
         * Mulai mengeset kapal
         */
        public void SetAISheep(int[] Sheep)
        {
            this.SheepPlan = Sheep;
            for (int i = 0; i < Sheep.Length; i++)
            {
                SetPixelSheep(Sheep[i]);
            }
        }

        /**
         * Mulai mengeset kapal
         */
        private void SetAISheep()
        {
            SetAISheep(this.SheepPlan);
        }

        /**
         * Meletakkan kapal sesuai panjang yang diinginkan
         */
        private void SetPixelSheep(int length)
        {
            // Melakukan random untuk rotasi kapal
            bool unrotate = (Rand.Next(1, 3) == 1) ? false : true;

            // Menentukan koordinat x dan y
            int RowFrom = (unrotate) ? Rand.Next(1, 11 - length) : Rand.Next(1,11);
            int ColFrom = (unrotate) ? Rand.Next(1, 11) : Rand.Next(1, 11 - length);
            int RowUntil = (unrotate) ? RowFrom + length : RowFrom;
            int ColUntil = (unrotate) ? ColFrom : ColFrom + length;

            // Melakukan pengecekan apakah kapal bisa diletakkan pada
            // posisi x dan y yang sudah ditentukan sebelumnya. Jika
            // tidak tersedia, maka akan mengulang pengacakan posisi
            // Variabel counter berfungsi untuk mencegah adanya
            // infinite loop
            int counter = 1;
            const int limitLoop = 20;
            while(!Board.ConfirmPlayerSheepLocation(
                ColFrom,
                RowFrom,
                ColUntil,
                RowUntil,
                GameBoardController.PLAYER.PLAYER2
                ) && counter <= limitLoop)
            {
                unrotate = (Rand.Next(1, 3) == 1) ? false : true;
                RowFrom = (unrotate) ? Rand.Next(1, 11 - length) : Rand.Next(1, 11);
                ColFrom = (unrotate) ? Rand.Next(1, 11) : Rand.Next(1, 11 - length);
                RowUntil = (unrotate) ? RowFrom + length : RowFrom ;
                ColUntil = (unrotate) ? ColFrom : ColFrom + length;
                counter++;
            }
            // Jika perulangan sudah terlalu banyak, maka
            // AI akan mereset semua kapal
            // dan melakukan pengesetan kapal ulang
            // walaupun sangat jarang perulangannya melebihi batas
            // tapi ya untuk antisipasi
            if (counter == limitLoop + 1)
            {
                resetSheep();
                Console.WriteLine("---Reset----");
                SetAISheep();
            }
            // Jika lokasi yang sudah ditentukan tersedia
            else
            {
                Console.WriteLine("(" + (RowFrom-1) + "," + (ColFrom-1) + ") -> (" + (RowUntil-1) + "," + (ColUntil-1) + ") rotate ->" + unrotate);
                // Meletakkan kapal pada posisi x dan y yang sudah di cek
                Board.SetPlayerSheepLocation(
                    ColFrom,
                    RowFrom,
                    ColUntil,
                    RowUntil,
                    this.target
                    );
            }
                
        }

        /**
         * Mereset semua kapal AI
         */
        public void resetSheep()
        {
            Board.ResetSheep(this.target);
        }

        /**
         * Melakukan serangan secara acak
         */
        protected void SetRandomAttack()
        {
            int col = Rand.Next(0, 10);
            int row = Rand.Next(0, 10);

            // Memastikan blok tersebut belum pernah diserang
            // atau boleh diserang
            while (!Board.AllowAttack(row, col, this.target)           ||
                   Board.IsSuccessAttack(row - 1, col,this.target)     ||
                   Board.IsSuccessAttack(row + 1, col,this.target)     ||
                   Board.IsSuccessAttack(row, col - 1, this.target)    ||
                   Board.IsSuccessAttack(row, col + 1, this.target)    ||
                   Board.IsSuccessAttack(row + 1, col + 1, this.target)||
                   Board.IsSuccessAttack(row - 1, col - 1, this.target)||
                   Board.IsSuccessAttack(row - 1, col + 1, this.target)||
                   Board.IsSuccessAttack(row + 1, col - 1, this.target))
            {
                col = Rand.Next(0, 10);
                row = Rand.Next(0, 10);
            }

            // Menyerang
            Board.SetAttack(row, col, this.target);
            int[] history = new int[2];
            history[0] = row;
            history[1] = col;

            if (Board.IsSuccessAttack(row, col, this.target))
            {
                // Jika diserang adalah lokasi sebuah kapal
                // Maka tandai lokasi tersebut
                if (Board.IsSheepLocation(row, col, this.target))
                {
                    if (!Board.GetSheep(row, col, this.target).isDestroyed())
                    {
                        lastAttackSuccessCol = col;
                        lastAttackSuccessRow = row;
                    }
                }
            }
        }

        /**
         * Melakukan serangan yang terstruktur
         */
        protected void SetStructuredAttack()
        {
            int row = 0;
            int col = 0;

            bool top = true;
            bool bottom = true;
            bool left = true;
            bool right = true;

            bool hasAttacked = false;

            // Menentukan arah yang bisa diserang
            if (lastAttackSuccessRow == 0)
                top = false;
            else if (lastAttackSuccessRow == 9)
                bottom = false;
            if (lastAttackSuccessCol == 0)
                left = false;
            else if (lastAttackSuccessCol == 9)
                right = false;

            // Melihat apakah ada blok yang berhasil diserang disekitar blok secara horizontal dan vertical
            if (Board.IsSuccessAttack(lastAttackSuccessRow - 1, lastAttackSuccessCol, this.target) ||
                Board.IsSuccessAttack(lastAttackSuccessRow + 1, lastAttackSuccessCol, this.target))
            {
                //Console.WriteLine("Hanya atas bawah");
                right = false;
                left = false;
            }
            else if (Board.IsSuccessAttack(lastAttackSuccessRow, lastAttackSuccessCol - 1, this.target) ||
                Board.IsSuccessAttack(lastAttackSuccessRow, lastAttackSuccessCol + 1, this.target))
            {
                //Console.WriteLine("Hanya kiri kanan");
                top = false;
                bottom = false;
            }

            if (top)
            {
                col = lastAttackSuccessCol;
                // Jika bagian atas bisa diserang dan merupakan blok yang hancur
                if (Board.IsSuccessAttack(lastAttackSuccessRow - 1, lastAttackSuccessCol, this.target))
                {
                    row = GetLastRow(lastAttackSuccessRow, col, WAY.TOP);
                    if (row != -1)
                        hasAttacked = true;
                }
                else if (Board.AllowAttack(lastAttackSuccessRow - 1, lastAttackSuccessCol, this.target))
                {
                    row = lastAttackSuccessRow - 1;
                    hasAttacked = true;
                }
            }
            if (bottom && !hasAttacked)
            {
                col = lastAttackSuccessCol;
                if (Board.IsSuccessAttack(lastAttackSuccessRow + 1, lastAttackSuccessCol, this.target))
                {
                    row = GetLastRow(lastAttackSuccessRow, col, WAY.BOTTOM);
                    if (row != -1)
                        hasAttacked = true;
                }
                else if (Board.AllowAttack(lastAttackSuccessRow + 1, lastAttackSuccessCol, this.target))
                {
                    row = lastAttackSuccessRow + 1;
                    hasAttacked = true;
                }
            }
            if (left && !hasAttacked)
            {
                row = lastAttackSuccessRow;
                if (Board.IsSuccessAttack(lastAttackSuccessRow, lastAttackSuccessCol - 1, this.target))
                {
                    col = GetLastCol(row, lastAttackSuccessCol, WAY.LEFT);
                    if (col != -1)
                        hasAttacked = true;
                }
                else if (Board.AllowAttack(lastAttackSuccessRow, lastAttackSuccessCol - 1, this.target))
                {
                    col = lastAttackSuccessCol - 1;
                    hasAttacked = true;
                }
            }
            if (right && !hasAttacked)
            {
                row = lastAttackSuccessRow;
                if (Board.IsSuccessAttack(lastAttackSuccessRow, lastAttackSuccessCol + 1, this.target))
                {
                    col = GetLastCol(row, lastAttackSuccessCol, WAY.RIGHT);
                    if (col != -1)
                    {
                        hasAttacked = true;
                    }
                    else
                    {
                        Console.WriteLine("masuk -1");
                        Console.WriteLine(row + " " + lastAttackSuccessCol);
                    }
                }
                else if (Board.AllowAttack(lastAttackSuccessRow, lastAttackSuccessCol + 1, this.target))
                {
                    col = lastAttackSuccessCol + 1;
                    hasAttacked = true;
                }
            }

            // melakukan serangan
            Board.SetAttack(row, col, this.target);

            // Jika blok yang diserang merupakan sebuah kapal dan
            // kapal tersebut sudah hancur, maka tandai blok serangan
            // terakhir sebagai kosong
            if (Board.IsSheepLocation(row, col, this.target))
            {
                if (Board.GetSheep(row, col, this.target).isDestroyed())
                {
                    //Console.WriteLine("Reset");
                    lastAttackSuccessCol = -1;
                    lastAttackSuccessRow = -1;
                }
                else
                {
                    //Console.WriteLine("Diganti");
                    lastAttackSuccessCol = col;
                    lastAttackSuccessRow = row;
                }
            }
        }

        protected int GetLastRow(int row,int col,WAY way)
        {
            if(way == WAY.TOP)
            {
                while(Board.IsDestroyedBlock(row,col,this.target) && row > 0)
                    row--;
            }
            else if(way == WAY.BOTTOM)
            {
                while(Board.IsDestroyedBlock(row,col,this.target) && row < 9)
                    row++;
            }
            if (!Board.IsDestroyedBlock(row, col, this.target) && Board.AllowAttack(row, col, this.target))
                return row;
            return -1;
        }

        protected int GetLastCol(int row,int col, WAY way)
        {
            Console.WriteLine("Last col : " + row + " " + col);
            if(way == WAY.LEFT)
            {
                while (Board.IsDestroyedBlock(row, col, this.target) && col > 0)
                    col--;
            }
            else if(way == WAY.RIGHT)
            {
                while (Board.IsDestroyedBlock(row, col, this.target) && col < 9)
                    col++;
            }
            Console.WriteLine("Last col after : " + row + " " + col);
            if (!Board.IsDestroyedBlock(row, col, this.target) && Board.AllowAttack(row, col, this.target))
                return col;
            return -1;
        }

        public void SetDifficult(DIFFICULT Difficult)
        {
            this.Difficult = Difficult;
        }

        private void RandomStrategy()
        {

        }

        /**
         * Melakukan
         */
        private void GenerateStrategy()
        {

        }

        public void SetAttack()
        {
            if(this.Strategy is RandomAttackAI)
            {
                RandomAttackAI CPU = (RandomAttackAI)this.Strategy;
                CPU.SetAttack();
            }
            else if(this.Strategy is FromTopAttackAI)
            {
                FromTopAttackAI CPU = (FromTopAttackAI)this.Strategy;
                CPU.SetAttack();
            }
            else if (this.Strategy is FromBottomAttackAI)
            {
                FromBottomAttackAI CPU = (FromBottomAttackAI)this.Strategy;
                CPU.SetAttack();
            }
            else if (this.Strategy is FromLeftAttackAI)
            {
                FromLeftAttackAI CPU = (FromLeftAttackAI)this.Strategy;
                CPU.SetAttack();
            }
            else 
            {
                FromRightAttackAI CPU = (FromRightAttackAI)this.Strategy;
                CPU.SetAttack();
            }
        }

        public string GetStrategy()
        {
            return this.Name;
        }

    }
}