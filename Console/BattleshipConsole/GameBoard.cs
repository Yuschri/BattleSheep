using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSheepConsole
{
    class GameBoard
    {

        private int Player1Turn = 0;

        private int Player2Turn = 0;

        public static byte Player1 = 1;

        public static byte Player2 = 2;

        /**
         * Nilai yang mewakili pemenang dalam permainan
         * bernilai -1 jika belum ada pemenang
         */
        private int Winner = -1;

        /**
         * Daftar kapal yang dimiliki oleh Player1
         */
        private List<Sheep> Player1Sheep = new List<Sheep>();

        /**
         * Daftar kapal yang dimiliki oleh Player2
         */
        private List<Sheep> Player2Sheep = new List<Sheep>();

        /**
         * Letak kapal dari Player 1
         */
        private char[,] Player1SheepMap = new char[10, 10];

        /**
         * Letak kapal dari Player 2
         */
        private char[,] Player2SheepMap = new char[10, 10];

        /**
         * Letak serangan untuk Player 1
         */
        private char[,] Player1Attacked = new char[10, 10];

        /**
         * Letak serangan untuk Player 2
         */
        private char[,] Player2Attacked = new char[10, 10];

        /**
         * Rendering board
         */
        public void RenderBoard()
        {
            //Player2Ship[0, 2] = 'B';
            // Cetak baris atas
            Console.Write("  ");
            for (int j = 0; j < 10; j++)
                Console.Write("  " + j + " ");
            Console.WriteLine();
            for (int i = 0;i <= 42; i++)
            {
                Console.Write('_');
            }
            Console.WriteLine();
            // Cetak Isi
            for(int i = 0;i < 10; i++)
            {
                Console.Write(i + " ");
                for (int j = 0;j < 10; j++)
                {
                    if (j == 0)
                        Console.Write("| ");
                    if (Player2Attacked[i, j] == 'O')
                    {
                        if (Player2SheepMap[i, j] == 'X')
                            Console.Write("H | ");
                        else
                            Console.Write(Player2Attacked[i, j] + " | ");
                    }
                    else
                        Console.Write("  | ");
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
        public void resetSheep(int Player)
        {
            if (Player == GameBoard.Player1)
            {
                this.Player1SheepMap = new char[10, 10];
                this.Player1Sheep = new List<Sheep>();
            }
            else
            {
                this.Player2SheepMap = new char[10, 10];
                this.Player2Sheep = new List<Sheep>();
            }
        }

        /**
         * Meletakkan kapal player pada map
         */
        public void SetPlayerSheepLocation(
            int ColFrom,
            int RowFrom,
            int ColUntil,
            int RowUntil,
            byte Player)
        {
            ColFrom--;
            RowFrom--;
            ColUntil--;
            RowUntil--;

            Sheep kapal = new Sheep();
            kapal.setLocation(RowFrom, ColFrom, RowUntil, ColUntil);

            if (Player == GameBoard.Player2)
            {
                Player2Sheep.Add(kapal);
                // Jika berotasi
                if (RowUntil != RowFrom)
                {
                    for (int row = RowFrom; row < RowUntil; row++)
                        Player2SheepMap[row, ColFrom] = 'X';
                }
                // Jika tidak berotasi
                else
                {
                    for (int col = ColFrom; col < ColUntil; col++)
                        Player2SheepMap[RowFrom, col] = 'X';
                }
            }
            else
            {
                Player1Sheep.Add(kapal);
                // Jika berotasi
                if (RowUntil != RowFrom)
                {
                    for (int row = RowFrom; row < RowUntil; row++)
                        Player1SheepMap[row, ColFrom] = 'X';
                }
                // Jika tidak berotasi
                else
                {
                    for (int col = ColFrom; col < ColUntil; col++)
                        Player1SheepMap[RowFrom, col] = 'X';
                }
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
            byte Player
            )
        {
            ColFrom--;
            RowFrom--;
            ColUntil--;
            RowUntil--;
            
            if(Player == GameBoard.Player2)
            {
                // Jika berotasi
                if (RowUntil != RowFrom)
                {
                    for (int row = RowFrom; row < RowUntil; row++)
                    {

                        if (Player2SheepMap[row, ColFrom] == 'X'         ||
                            !checkDiagonalSheep(row, ColFrom, Player)    ||
                            !checkHorticalSheep(row, ColFrom, Player))
                            return false;
                    }
                }
                // Jika tidak berotasi
                else
                {
                    for (int col = ColFrom ; col < ColUntil; col++)
                    {
                        if (Player2SheepMap[RowFrom, col] == 'X'         ||
                            !checkDiagonalSheep(RowFrom, col, Player)    ||
                            !checkHorticalSheep(RowFrom, col, Player))
                            return false;
                    }
                }
            }
            return true;
        }

        /**
         * Memastikan agar blok yang dpilih memiliki jarak antar kapal lain
         * secara horizontal dan vertical
         */
        private bool checkHorticalSheep(int row, int col, int player)
        {
            bool top = false;
            bool bottom = false;
            bool right = false;
            bool left = false;

            bottom = (row >= 0 && row < 9) ? true : false;
            top = (row > 0 && row <= 9) ? true : false;
            right = (col >= 0 && col < 9) ? true : false;
            left = (col > 0 && col <= 9) ? true : false;

            if (player == GameBoard.Player2)
            {
                if ((top    && Player2SheepMap[row - 1, col] == 'X') ||
                    (bottom && Player2SheepMap[row + 1, col] == 'X') ||
                    (left   && Player2SheepMap[row, col - 1] == 'X') ||
                    (right  && Player2SheepMap[row, col + 1] == 'X'))
                    return false;
            }
            return true;
        }

        /**
         * Memastikan terdapat kapal yang tidak bersebelahan dengan
         * kapal lain secara diagonal
         */
        private bool checkDiagonalSheep(int row, int col, int player)
        {
            bool topRight = false;
            bool topLeft = false;
            bool bottomRight = false;
            bool bottomLeft = false;

            bottomLeft = (row < 9 && col > 0) ? true : false;
            bottomRight = (row < 9 && col < 9 ) ? true : false;
            topLeft = (row > 0 && col > 0) ? true : false;
            topRight = (row > 0 && col < 9) ? true : false;

            if (player == GameBoard.Player2)
            {
                if ((topLeft        && Player2SheepMap[row - 1, col - 1] == 'X') ||
                    (topRight       && Player2SheepMap[row - 1, col + 1] == 'X') ||
                    (bottomLeft     && Player2SheepMap[row + 1, col - 1] == 'X') ||
                    (bottomRight    && Player2SheepMap[row + 1, col + 1] == 'X'))
                    return false;
            }
            return true;
        }

        /**
         * Melakukan serangan pada sebuah blok ke pemain lain
         */
        public void setAttack(int row,int col, Byte AttackFor)
        {
            if (AttackFor == GameBoard.Player1)
            {
                Player1Attacked[row, col] = 'O';
                //Player1Turn++;
            }
            else
            {
                Console.WriteLine(row + " " + col);
                Player2Attacked[row, col] = 'O';
                //Player2Turn++;
                if (Player2SheepMap[row, col] == 'X')
                {
                    Sheep ship = this.getSheep(row, col, GameBoard.Player2);
                    ship.setAttack();
                    Console.WriteLine("Panjang kapal : " + ship.getLength());
                    Console.WriteLine("Telah terserang : " + ship.getAttackedLength());
                    Console.WriteLine(ship.getPosition());
                }
                if(!isSuccessAttack(row,col,GameBoard.Player2))
                   Player2Turn++;
            }
        }

        /**
         * Memastikan sebuah blok dapat diserang atau tidak
         */
        public bool allowAttack(int row, int col, byte AttackFor)
        {
            if (row > 9 || row < 0 || col > 9 || col < 0)
                return false;
            return !hasAttacked(row, col, AttackFor);
        }
        
        /**
         * Memastikan sebuah blok pernah diserang sebelumnya atau tidak
         */
        private bool hasAttacked(int row, int col,byte AttackFor)
        {
            if(AttackFor == GameBoard.Player2)
            {
                if (Player2Attacked[row, col] == 'O')
                    return true;
            }
            return false;
        }

        /**
         * Mengecek apakah sudah ada pemenang
         */
        public bool hasWinner()
        {
            // Jika jumlah putaran player kurang dari 12 putaran
            // artinya, tidak mungkin dalam jumlah putaran tersebut
            // ada pemain yang bisa menang. IMPOSSIBLE !!
            if (Player2Turn < 12)
                return false;
            else
            {
                // Mengecek jumlah kapal yang hancur pada player 1
                /*
                int Player1DestroyedSheep = 0;
                for(int i = 0; i < Player1Sheep.Count(); i++)
                {
                    if (Player1Sheep[i].isDestroyed())
                        Player1DestroyedSheep++;
                }
                if (Player1DestroyedSheep == Player1Sheep.Count())
                {
                    Winner = GameBoard.Player1;
                    return true;
                }
                */
                // Mengecek jumlah kapal yang hancur pada player 2
                int Player2DestroyedSheep = 0;
                for (int i = 0; i < Player2Sheep.Count(); i++)
                {
                    if (Player2Sheep[i].isDestroyed())
                        Player2DestroyedSheep++;
                }
                if (Player2DestroyedSheep == Player2Sheep.Count())
                {
                    Winner = GameBoard.Player2;
                    return true;
                }
            }
            return false;
        }

        public bool isSuccessAttack(int row, int col, byte Player)
        {
            if (row > 9 || row < 0 || col > 9 || col < 0)
                return false;
            else
            {
                if (Player == GameBoard.Player2)
                {
                    if (Player2Attacked[row, col] == 'O' && Player2SheepMap[row, col] == 'X')
                        return true;
                }
            }
            return false;
        }

        /**
         * Memastikan apakah sebuah blok merupakan sebuah kapal
         */
        public bool isShipLocation(int row, int col, int Player)
        {
            if(Player == GameBoard.Player1)
            {
                if (Player1SheepMap[row, col] == 'X')
                    return true;
            }
            else
            {
                if (Player2SheepMap[row, col] == 'X')
                    return true;
            }
            return false;
        }

        public bool isDestroyedBlock(int row, int col, byte Player)
        {
            if(Player == GameBoard.Player1)
            {
                if (Player1Attacked[row, col] == 'O' && Player1SheepMap[row,col] == 'X')
                    return true;
            }
            else
            {
                if (Player2Attacked[row, col] == 'O' && Player2SheepMap[row,col] == 'X')
                    return true;
            }
            return false;
        }

        /**
         * Memastikan siapa pememang permainan
         */
        public int getWinner()
        {
            return Winner;
        }

        public Sheep getSheep(int row,int col,byte Player)
        {
            Sheep sheep = new Sheep();
            if (Player == GameBoard.Player1)
            {
                for(int i = 0; i < Player1Sheep.Count; i++)
                {
                    if (Player1Sheep[i].isSheepLocation(row, col))
                        return Player1Sheep[i];
                }
            }
            else
            {
                for (int i = 0; i < Player2Sheep.Count; i++)
                {
                    if (Player2Sheep[i].isSheepLocation(row, col))
                        return Player2Sheep[i];
                }
            }
            return sheep;
        }

    }

}
