using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Map.Tile;
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

        public bool collision_map(Boat b, List<Chunk> chunks)
        {
            foreach(Chunk c in chunks)
            {
                foreach(List<Tile> lt in c.Tiles)
                {
                    foreach(Tile t in lt)
                    {
                        if(t.Type == TileType.Ground)
                        {
                            if (collision_Tile(b, t))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool collision_Tile(Boat b, Tile t)
        {
            Vector2 rect1 = -b.Get_Position();
            Vector2 rect2 = t.Get_Position();
            if (rect1.X < rect2.X + TextureFinder.SPRITESIZE &&
                   rect1.X + b.Width > rect2.X &&
                   rect1.Y < rect2.Y + TextureFinder.SPRITESIZE &&
                   b.Height + rect1.Y > rect2.Y)
            {
                return true;
            }

            return false;
        }
    }
}
