using System;

namespace Calculator_for_accountants.classes
{
    class Economic
    {
        public const decimal koefNDFL = 0.18M;
        public const decimal koefVZ = 0.015M;
        public const decimal koefESV = 0.22M;

        private decimal dirty;
        private decimal ndfl;
        private decimal vz;
        private decimal esv;
        private decimal clear;
        private decimal dirtyEsv;

        private bool isRound = true;

        public void SetRound(bool toggle)
        {
            isRound = toggle;
            dirty = Math.Ceiling(dirty);
        }

        public decimal Dirty
        {
            get { return dirty; }
            set { dirty = value; }
        }

        public decimal Ndfl
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

        public decimal Vz
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

        public decimal Esv
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

        public decimal Clear
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

        public decimal DirtyEsv
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
