using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace MYGAME
{
    
        class Collision
        {
            public static bool Intersects(Rectangle a, Rectangle b)
            {
                // check if two Rectangles intersect
                return (a.Right > b.Left && a.Left < b.Right &&
                        a.Bottom > b.Top && a.Top < b.Bottom);
            }
            public static bool Intersects(Sprite a, Sprite b)
            {
                if (Collision.Intersects(a.Bounds, b.Bounds))
                {
                    uint[] bitsA = new uint[a.mSpriteTexture.Width * a.mSpriteTexture.Height];
                    a.mSpriteTexture.GetData<uint>(bitsA);

                    uint[] bitsB = new uint[b.mSpriteTexture.Width * b.mSpriteTexture.Height];
                    b.mSpriteTexture.GetData<uint>(bitsB);

                    int x1 = Math.Max(a.Bounds.X, b.Bounds.X);
                    int x2 = Math.Min(a.Bounds.X + a.Bounds.Width, b.Bounds.X + b.Bounds.Width);

                    int y1 = Math.Max(a.Bounds.Y, b.Bounds.Y);
                    int y2 = Math.Min(a.Bounds.Y + a.Bounds.Height, b.Bounds.Y + b.Bounds.Height);

                    for (int y = y1; y < y2; ++y)
                    {
                        for (int x = x1; x < x2; ++x)
                        {
                            if (((bitsA[(x - a.Bounds.X) + (y - a.Bounds.Y) * a.mSpriteTexture.Width] & 0xFF000000) >> 24) > 20 &&
                                ((bitsB[(x - b.Bounds.X) + (y - b.Bounds.Y) * b.mSpriteTexture.Width] & 0xFF000000) >> 24) > 20)
                                return true;
                        }
                    }
                    return true;
                }
                return false;
            }
        }
    
}
