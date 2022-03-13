using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Data
{
    public class Coordonnees
    {
        public int X;
        public int Y;

        public Coordonnees(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }
    }
}
