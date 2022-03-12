using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Placeable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_AlaCarte.Source.Manager
{
    public class CollisionManager
    {
        public CollisionManager()
        {

        }


        public bool collision_Treasure(Boat b, Treasure t)
        {
            Vector2 rect1 =- b.Get_Position();
            Vector2 rect2 = t.Get_Position();
            if (rect1.X < rect2.X + t.Width &&
                   rect1.X + b.Width > rect2.X &&
                   rect1.Y < rect2.Y + t.Height &&
                   b.Height + rect1.Y > rect2.Y)
            {
                return true;
            }

            return false;
        }
    }
}
