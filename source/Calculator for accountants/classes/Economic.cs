using System;

namespace Calculator_for_accountants.classes
{
    class Economic
    {
        public const double koefNDFL = 0.18;
        public const double koefVZ = 0.015;
        public const double koefESV = 0.22;

        private double dirty;
        private double ndfl;
        private double vz;
        private double esv;
        private double clear;
        private double dirtyEsv;

        private bool isRound = true;

        public void SetRound(bool toggle)
        {
            isRound = toggle;
            dirty = Math.Ceiling(dirty);
        }

        public double Dirty
        {
            get { return dirty; }
            set { dirty = value; }
        }

        public double Ndfl
        {
            get { return ndfl; }
            set
            {
                ndfl = value;
                dirty = value / koefNDFL;

                if (isRound)
                    dirty = Math.Ceiling(dirty);
            }
        }

        public double Vz
        {
            get { return vz; }
            set
            {
                vz = value;
                dirty = value / koefVZ;

                if (isRound)
                    dirty = Math.Ceiling(dirty);
            }
        }

        public double Esv
        {
            get { return esv; }
            set
            {
                esv = value;
                dirty = value / koefESV;

                if (isRound)
                    dirty = Math.Ceiling(dirty);
            }
        }

        public double Clear
        {
            get { return clear; }
            set
            {
                clear = value;
                dirty = value / (1 - (koefNDFL + koefVZ));

                if (isRound)
                    dirty = Math.Ceiling(dirty);
            }
        }

        public double DirtyEsv
        {
            get { return dirtyEsv; }
            set { dirtyEsv = value; }
        }

        public void Calculate()
        {
            ndfl = dirty * koefNDFL;
            vz = dirty * koefVZ;
            esv = dirty * koefESV;
            clear = dirty - (dirty * koefNDFL) - (dirty * koefVZ);
            dirtyEsv = dirty + (dirty * koefESV);
        }
    }
}
