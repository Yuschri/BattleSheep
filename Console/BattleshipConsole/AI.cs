using System;
using System.Collections.Generic;

namespace BattleSheepConsole
{
    class AI
    {

        private Random rand = new Random();

        private GameBoard Board;

        private int lastAttackSuccessRow = -1;

        private int lastAttackSuccessCol = -1;

        private byte target = GameBoard.Player2;

        private static byte TOP = 1;

        private static byte BOTTOM = 2;

        private static byte LEFT = 3;

        private static byte RIGHT = 4;

        // Untuk Structured Random Attack

        private static int sRow = 0;

        private static int sCol = 0;

        private static bool backToTop = false;

        // Strategy

        private static int StrategyOne = 1;

        private static int StrategyTwo = 2;

        private static int DefaultStrategy;

        // Strategy Random yang dicatat

        private List<int[,]> RandomHistory = new List<int[,]>();

        public AI(GameBoard Board)
        {
            this.Board = Board;
        }

        /**
         * Mulai mengeset kapal
         */
        public void setAISheep()
        {
            setPixelSheep(1);
            setPixelSheep(1);
            setPixelSheep(1);
            setPixelSheep(1);
            setPixelSheep(2);
            setPixelSheep(2);
            setPixelSheep(2);
            setPixelSheep(3);
            setPixelSheep(3);
            setPixelSheep(4);
        }

        /**
         * Meletakkan kapal sesuai panjang yang diinginkan
         */
        private void setPixelSheep(int length)
        {
            // Melakukan random untuk rotasi kapal
            bool unrotate = (rand.Next(1, 3) == 1) ? false : true;

            // Menentukan koordinat x dan y
            int RowFrom = (unrotate) ? rand.Next(1, 11 - length) : rand.Next(1,11);
            int ColFrom = (unrotate) ? rand.Next(1, 11) : rand.Next(1, 11 - length);
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
                GameBoard.Player2
                ) && counter <= limitLoop)
            {
                unrotate = (rand.Next(1, 3) == 1) ? false : true;
                RowFrom = (unrotate) ? rand.Next(1, 11 - length) : rand.Next(1, 11);
                ColFrom = (unrotate) ? rand.Next(1, 11) : rand.Next(1, 11 - length);
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
                setAISheep();
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
            Board.resetSheep(this.target);
        }

        /**
         * Melakukan serangan
         */
        private void setAttack(int Strategy)
        {
            // Jika sebelumnya melakukan serangan pada sebuah blok dan
            // blok tersebut adalah kapal, juga bukan bagian terakhir sebuah kapal
            if (lastAttackSuccessCol != -1 && lastAttackSuccessRow != -1)
            {
                // Melakukan serangan yang terorganisir
                setOrganizingAttack();
            }
            // Jika pernah menghancurkan sebuah kapal atau belum pernah
            // maka melakukan pengacakan untuk menyerang sebuah blok
            else
            {
                if(Strategy == AI.StrategyOne)
                    setRandomAttack();
                else
                    setStructuredAttack();
            }
        }

        public void setAttack()
        {
            if (DefaultStrategy == AI.StrategyOne)
                setAttack(AI.StrategyOne);
            else
                setAttack(AI.StrategyTwo);
        }

        public void generateStrategy()
        {
            int stg1 = getStrategyOneTurn();
            int stg2 = getStrategyTwoTurn();
            if(stg1 < stg2)
            {
                DefaultStrategy = AI.StrategyOne;
            }
            else
            {
                DefaultStrategy = AI.StrategyTwo;
            }
            Board.resetTurn(GameBoard.Player2);
            Board.resetAttack(GameBoard.Player2);
            Board.resetWinner();
            Console.WriteLine("Strategy 1 : " + stg1 + " Strategy 2 : " + stg2);
        }

        public void setOrganizingAttack()
        {
            int row = 0;
            int col = 0;

            bool top = true;
            bool bottom = true;
            bool left = true;
            bool right = true;

            bool hasAttacked = false;
            byte priority = 0;

            // Menentukan arah yang bisa diserang
            if (lastAttackSuccessRow == 0)
                top = false;
            else if (lastAttackSuccessRow == 9)
                bottom = false;
            if(lastAttackSuccessCol == 0)
                left = false;
            else if (lastAttackSuccessCol == 9)
                right = false;

            // Melihat apakah ada blok yang berhasil diserang disekitar blok secara horizontal dan vertical
            if(Board.isSuccessAttack(lastAttackSuccessRow - 1, lastAttackSuccessCol, this.target) ||
                Board.isSuccessAttack(lastAttackSuccessRow + 1,lastAttackSuccessCol,this.target))
            {
                //Console.WriteLine("Hanya atas bawah");
                right = false;
                left = false;
            }
            else if(Board.isSuccessAttack(lastAttackSuccessRow,lastAttackSuccessCol - 1,this.target) ||
                Board.isSuccessAttack(lastAttackSuccessRow,lastAttackSuccessCol + 1, this.target))
            {
                //Console.WriteLine("Hanya kiri kanan");
                top = false;
                bottom = false;
            }
            

                if (top)
            {
                col = lastAttackSuccessCol;
                // Jika bagian atas bisa diserang dan merupakan blok yang hancur
                if (Board.isSuccessAttack(lastAttackSuccessRow - 1, lastAttackSuccessCol, this.target))
                {
                    row = getLastRow(lastAttackSuccessRow, col, AI.TOP);
                    if (row != -1)
                        hasAttacked = true;
                }
                else if (Board.allowAttack(lastAttackSuccessRow - 1, lastAttackSuccessCol, this.target))
                {
                    row = lastAttackSuccessRow - 1;
                    hasAttacked = true;
                }
            }
            if(bottom && !hasAttacked)
            {
                col = lastAttackSuccessCol;
                if (Board.isSuccessAttack(lastAttackSuccessRow + 1, lastAttackSuccessCol, this.target))
                {
                    row = getLastRow(lastAttackSuccessRow, col, AI.BOTTOM);
                    if (row != -1)
                        hasAttacked = true;
                }
                else if (Board.allowAttack(lastAttackSuccessRow + 1, lastAttackSuccessCol, this.target))
                {
                     row = lastAttackSuccessRow + 1;
                    hasAttacked = true;
                }
            }
            if(left && !hasAttacked)
            {
                row = lastAttackSuccessRow;
                if (Board.isSuccessAttack(lastAttackSuccessRow, lastAttackSuccessCol - 1, this.target))
                {
                    col = getLastCol(row, lastAttackSuccessCol, AI.LEFT);
                    if (col != -1)
                        hasAttacked = true;
                }
                else if (Board.allowAttack(lastAttackSuccessRow, lastAttackSuccessCol - 1, this.target))
                {
                    col = lastAttackSuccessCol - 1;
                    hasAttacked = true;
                }
            }
            if(right && !hasAttacked)
            {
                row = lastAttackSuccessRow;
                if (Board.isSuccessAttack(lastAttackSuccessRow, lastAttackSuccessCol + 1, this.target))
                {
                    col = getLastCol(row, lastAttackSuccessCol, AI.RIGHT);
                    if (col != -1)
                    {
                        hasAttacked = true;
                    }
                    else
                    {
                        //Console.WriteLine("masuk -1");
                        //Console.WriteLine(row + " " + lastAttackSuccessCol);
                    }
                }
                else if (Board.allowAttack(lastAttackSuccessRow, lastAttackSuccessCol + 1, this.target))
                {
                    col = lastAttackSuccessCol + 1;
                    hasAttacked = true;
                }
            }
                
            // melakukan serangan
            Board.setAttack(row, col, this.target);

            // Jika blok yang diserang merupakan sebuah kapal dan
            // kapal tersebut sudah hancur, maka tandai blok serangan
            // terakhir sebagai kosong
            if (Board.isShipLocation(row, col, this.target))
            {
                if (Board.getSheep(row, col, this.target).isDestroyed())
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

        private void setRandomAttack()
        {
            int col = rand.Next(0, 10);
            int row = rand.Next(0, 10);

            // Memastikan blok tersebut belum pernah diserang
            // atau boleh diserang
            while (!Board.allowAttack(row, col, this.target)           ||
                   Board.isSuccessAttack(row - 1, col,this.target)     ||
                   Board.isSuccessAttack(row + 1, col,this.target)     ||
                   Board.isSuccessAttack(row, col - 1, this.target)    ||
                   Board.isSuccessAttack(row, col + 1, this.target)    ||
                   Board.isSuccessAttack(row + 1, col + 1, this.target)||
                   Board.isSuccessAttack(row - 1, col - 1, this.target)||
                   Board.isSuccessAttack(row - 1, col + 1, this.target)||
                   Board.isSuccessAttack(row + 1, col - 1, this.target))
            {
                col = rand.Next(0, 10);
                row = rand.Next(0, 10);
            }

            // Menyerang
            Board.setAttack(row, col, this.target);

            if (Board.isSuccessAttack(row, col, this.target))
            {
                // Jika diserang adalah lokasi sebuah kapal
                // Maka tandai lokasi tersebut
                if (Board.isShipLocation(row, col, this.target))
                {
                    if (!Board.getSheep(row, col, this.target).isDestroyed())
                    {
                        lastAttackSuccessCol = col;
                        lastAttackSuccessRow = row;
                    }
                }
            }
        }

        private void setStructuredAttack()
        {
            int counter = 0,limit = 20;
            while ((!Board.allowAttack(sRow, sCol, this.target) ||
                   Board.isSuccessAttack(sRow - 1, sCol, this.target) ||
                   Board.isSuccessAttack(sRow + 1, sCol, this.target) ||
                   Board.isSuccessAttack(sRow, sCol - 1, this.target) ||
                   Board.isSuccessAttack(sRow, sCol + 1, this.target) ||
                   Board.isSuccessAttack(sRow + 1, sCol + 1, this.target) ||
                   Board.isSuccessAttack(sRow - 1, sCol - 1, this.target) ||
                   Board.isSuccessAttack(sRow - 1, sCol + 1, this.target) ||
                   Board.isSuccessAttack(sRow + 1, sCol - 1, this.target))  &&
                   counter < limit)
            {
                counter++;
                sCol += 2;
                if(sCol == 10)
                {
                    sRow++;
                    if (backToTop)
                        sCol = 0;
                    else
                        sCol = 1;
                }
                else if(sCol == 11)
                {
                    sRow++;
                    if (backToTop)
                        sCol = 1;
                    else
                        sCol = 0;
                }
                if(sRow > 9)
                {
                    sRow = 0;
                    sCol = 1;
                    backToTop = true;
                }
                //Console.WriteLine("Row : " + sRow + " Col : " + sCol);
            }

            if (counter == 20)
                setRandomAttack();

            else
            {
                Board.setAttack(sRow, sCol, this.target);
                int row = sRow;
                int col = sCol;
                if (Board.isSuccessAttack(row, col, this.target))
                {
                    // Jika diserang adalah lokasi sebuah kapal
                    // Maka tandai lokasi tersebut
                    if (Board.isShipLocation(row, col, this.target))
                    {
                        if (!Board.getSheep(row, col, this.target).isDestroyed())
                        {
                            lastAttackSuccessCol = col;
                            lastAttackSuccessRow = row;
                        }
                    }
                }
            }
        }

        private int getLastRow(int row,int col,byte way)
        {
            if(way == AI.TOP)
            {
                while(Board.isDestroyedBlock(row,col,this.target) && row > 0)
                    row--;
            }
            else if(way == AI.BOTTOM)
            {
                while(Board.isDestroyedBlock(row,col,this.target) && row < 9)
                    row++;
            }
            if (!Board.isDestroyedBlock(row, col, this.target) && Board.allowAttack(row, col, this.target))
                return row;
            return -1;
        }

        private int getLastCol(int row,int col, byte way)
        {
            if(way == AI.LEFT)
            {
                while (Board.isDestroyedBlock(row, col, this.target) && col > 0)
                    col--;
            }
            else if(way == AI.RIGHT)
            {
                while (Board.isDestroyedBlock(row, col, this.target) && col < 9)
                    col++;
            }
            if (!Board.isDestroyedBlock(row, col, this.target) && Board.allowAttack(row, col, this.target))
                return col;
            return -1;
        }

        private int getStrategyOneTurn()
        {
            Board.resetTurn(GameBoard.Player2);
            Board.resetAttack(GameBoard.Player2);
            Board.resetWinner();
            while (!Board.hasWinner())
                setAttack(AI.StrategyOne);
            lastAttackSuccessCol = -1;
            lastAttackSuccessRow = -1;
            return Board.getTurn(GameBoard.Player2);
        }

        private int getStrategyTwoTurn()
        {
            Board.resetTurn(GameBoard.Player2);
            Board.resetAttack(GameBoard.Player2);
            Board.resetWinner();
            while (!Board.hasWinner())
                setAttack(AI.StrategyTwo);
            sRow = 0;
            sCol = 0;
            backToTop = false;
            lastAttackSuccessRow = -1;
            lastAttackSuccessCol = -1;
            return Board.getTurn(GameBoard.Player2);
        }

        public int getStrategy()
        {
            return DefaultStrategy;
        }

    }
}
