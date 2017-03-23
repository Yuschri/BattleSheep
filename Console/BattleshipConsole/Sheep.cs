using System.Collections.Generic;

namespace BattleSheepConsole
{

    /**
     * Class untuk mendefiniskan sebuah kapal
     */
    class Sheep
    {

        public int ColFrom;

        public int RowFrom;

        public int ColUntil;

        public int RowUntil;

        public int length;

        private bool destroyed = false;

        private int lengthAttacked = 0;

        public bool isDestroyed()
        {
            setSheepDestroyed();
            return destroyed;
        }

        public void setSheepDestroyed()
        {
            if (lengthAttacked == length)
                destroyed = true;
        }

        public void setAttack()
        {
            lengthAttacked++;
        }

        private void setLength()
        {
            if (RowFrom == RowUntil)
                length = ColUntil - ColFrom;
            else
                length = RowUntil - RowFrom;
        }

        public int getLength()
        {
            return length;
        }

        public bool isSheepLocation(int row, int col)
        {
            if(RowFrom == RowUntil)
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

        public void setLocation(int RowFrom, int ColFrom,int RowUntil, int ColUntil)
        {
            this.RowFrom = RowFrom;
            this.ColFrom = ColFrom;
            this.RowUntil = RowUntil;
            this.ColUntil = ColUntil;
            this.setLength();
        }

        public string getPosition()
        {
            return "(" + RowFrom +  "," + ColFrom + ") -> (" + RowUntil + "," + ColUntil + ")";
        }

        public int getAttackedLength()
        {
            return lengthAttacked;
        }

        public void resetAttack()
        {
            lengthAttacked = 0;
            destroyed = false;
        }

    }
}
