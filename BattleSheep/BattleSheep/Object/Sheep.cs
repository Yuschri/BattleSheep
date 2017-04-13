using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSheep.Object
{
    /**
     * Class untuk mendefiniskan sebuah kapal
     */
    public class Sheep
    {

        public int ColFrom;

        public int RowFrom;

        public int ColUntil;

        public int RowUntil;

        public int length;

        private bool destroyed = false;

        private int lengthAttacked = 0;

        public bool IsDestroyed()
        {
            SetSheepDestroyed();
            return destroyed;
        }

        public void SetSheepDestroyed()
        {
            if (lengthAttacked == length)
                destroyed = true;
        }

        public void SetAttack()
        {
            lengthAttacked++;
        }

        private void SetLength()
        {
            if (RowFrom == RowUntil)
                length = ColUntil - ColFrom;
            else
                length = RowUntil - RowFrom;
        }

        public int GetLength()
        {
            return length;
        }

        public bool IsSheepLocation(int row, int col)
        {
            if (RowFrom == RowUntil)
            {
                if (row == RowFrom && col >= ColFrom && col <= ColUntil)
                    return true;
            }
            else
            {
                if (col == ColFrom && row >= RowFrom && row <= RowUntil)
                    return true;
            }
            return false;
        }

        public void SetLocation(int RowFrom, int ColFrom, int RowUntil, int ColUntil)
        {
            this.RowFrom = RowFrom;
            this.ColFrom = ColFrom;
            this.RowUntil = RowUntil;
            this.ColUntil = ColUntil;
            this.SetLength();
        }

        public string getPosition()
        {
            return "(" + RowFrom + "," + ColFrom + ") -> (" + RowUntil + "," + ColUntil + ")";
        }

        public int GetAttackedLength()
        {
            return lengthAttacked;
        }

        public void ResetAttack()
        {
            lengthAttacked = 0;
            destroyed = false;
        }

    }
}
