using GameJam_AlaCarte.Source.Boats;
using GameJam_AlaCarte.Source.Data;
using GameJam_AlaCarte.Source.Map.Tile;
using GameJam_AlaCarte.Source.Placeable;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool collision_map(Vector2 pos, List<Chunk> chunks)
        {
            foreach (Chunk c in chunks)
            {
                foreach (List<Tile> lt in c.Tiles)
                {
                    foreach(Tile t in lt)
                    {
                        if (t.Type == TileType.Sand)
                        {
                            if (collision_Tile(pos, t))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool collision_Tile(Vector2 pos, Tile t)
        {
            Vector2 rect1 = pos;
            Vector2 rect2 = t.Get_Position();

            rect1.X *= -1;
            rect1.Y *= -1;

            rect2.X *= TextureFinder.SPRITESIZE;
            rect2.Y *= TextureFinder.SPRITESIZE;

            if (rect1.X < rect2.X + TextureFinder.SPRITESIZE &&
                   rect1.X + TextureFinder.SPRITESIZE > rect2.X &&
                   rect1.Y < rect2.Y + TextureFinder.SPRITESIZE &&
                   TextureFinder.SPRITESIZE + rect1.Y > rect2.Y)
            {
                return true;
            }


            return false;
        }

        public bool collision_bord(Vector2 pos)
        {
            Vector2 rect1 = pos;

            rect1.X *= -1;
            rect1.Y *= -1;

            if (rect1.X < 0 || rect1.X > ((8 * 16 * 16) - TextureFinder.SPRITESIZE - 1)
                || rect1.Y < 0 || rect1.Y > ((8 * 16 * 16) - TextureFinder.SPRITESIZE - 1))
                return true;
            return false;
        }
    }
}
