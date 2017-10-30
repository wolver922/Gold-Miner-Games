using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
namespace MYGAME
{
    class Arrow
    {
        //原點
        int OriginX = 540;
        int OriginY = 100;
        //終點
        int EndX = 540;
        int EndY = 140;
        //線長度
        int Originlong = 40; //40
       
        //觸擊點
        public Sprite touchPoint = new Sprite();
        Texture2D pixel;
        bool liferight = true;
       
        int countX = 0;
       
        bool mystart = false;
        int HEIGHT = 720;
        int WIDTH = 1080;
        public bool touchout = false;
        public int speed = 20;
        int sp = 0;
        int mystate = 0;//(0 = 一般狀態  1 = 發射狀態  2 = 收回狀態 3 = 結束收回)
        bool getthing = false;
       
        public void LoadContent(ContentManager theContentManager)
        {

            
            
            touchPoint.LoadContent(theContentManager, "pixel");
            pixel = theContentManager.Load<Texture2D>("pixel");
        }
        public void changeStart(bool x)
        {
            mystart = x;
        }
        public int Update(GameTime theGameTime)
        {
            //
            touchPoint.Update(theGameTime);
            double slopeX = Math.PI * countX / 180.0;
            if (mystart == false)
            {
                
                if (liferight)
                {
                    countX++;
                    if (countX == 90)//0
                        liferight = false;
                }
                else
                {
                    countX--;
                    if (countX == -90)//180
                        liferight = true;
                }
                //求得變化斜率
                slopeX = Math.PI * countX / 180.0;
               
                //求得變化斜率
                int X = OriginX + (int)(Math.Sin(slopeX) * Originlong);
                int Y = OriginY + (int)(Math.Cos(slopeX) * Originlong);
                // arrlongX =  (int)(Math.Sin(slopeX) * 10);
                //arrlongY =  (int)(Math.Cos(slopeX) * 10);
                // interceptB = OriginY - Math.Sin(slope) * OriginX;
                //將原點帶入變化方程式y = mx+b
                EndX = X;
                EndY = Y;
                /* if (EndX == 0)
                     EndY = OriginY + Originlong;
                 EndY = OriginY + Originlong;//(int)(Math.Sin(slope) * EndX + interceptB);*/
                //EndX = (int)Math.Sin(slope);
                //int X = (int)(Math.Sin(slope) * 10);
                touchPoint.Position = new Vector2(EndX, EndY);
                mystate = 0;
            }
            else
            {
                
                //speed = 12;//***
                if (touchout == false)
                    if (EndX > WIDTH || EndY > HEIGHT || EndX < 0)
                    {
                        touchout = true;
                        sp = 0;
                    }
                    else
                    {
                        //int slong = 0; 
                        /*for (int sp = 0; sp < speed; sp++)
                            Originlong++;*/
                        

                            Originlong += speed;
                        int X = OriginX + (int)(Math.Sin(slopeX) * Originlong);
                        int Y = OriginY + (int)(Math.Cos(slopeX) * Originlong);
                        EndX = X;
                        EndY = Y;
                        mystate = 1;
                    }
                else
                {
                    /*for (int sp = 0; sp < speed; sp++)
                        Originlong++;*/
                    if (speed <= 0)
                    {
                        if (sp-- < speed)
                        {
                            Originlong--;
                            sp = 0;
                        }
                    }
                    else
                        Originlong -= speed;
                    
                    int X = OriginX + (int)(Math.Sin(slopeX) * Originlong);
                    int Y = OriginY + (int)(Math.Cos(slopeX) * Originlong);
                    EndX = X;
                    EndY = Y;
                    mystate = 2;
                    if (Originlong<=1)
                    {
                        mystart = false;
                        touchout = false;
                        Originlong = 40;
                        mystate = 3;
                    }
                    
                }
                touchPoint.Position = new Vector2(EndX, EndY);
            }
            return mystate;
        }
        public virtual void Draw(SpriteBatch theSpriteBatch)
        {
            
            //int arroY = 150;
            //直線
            DrawLine(theSpriteBatch, OriginX, OriginY, EndX, EndY, Color.Black);
            DrawLine(theSpriteBatch, (OriginX - 1), OriginY, (EndX - 1), EndY, Color.Black);
            DrawLine(theSpriteBatch, (OriginX + 1), OriginY, (EndX + 1), EndY, Color.Black);
            touchPoint.Draw(theSpriteBatch);
            //int arrlong = 10;
            //箭頭
            
            /*DrawLine(theSpriteBatch, (EndX - 1), EndY, (EndX - 1) - arrlongX, EndY - arrlongY, Color.Black);
            DrawLine(theSpriteBatch, (EndX - 1), EndY + 1, (EndX - 1) - arrlongX, EndY - arrlongY, Color.Black);
            DrawLine(theSpriteBatch, (EndX - 1), EndY + 2, (EndX - 1) - arrlongX, EndY - arrlongY, Color.Black);
            DrawLine(theSpriteBatch, (EndX - 1), EndY + 3, (EndX - 1) - arrlongX, EndY - arrlongY, Color.Black);*/
          /*  DrawLine(theSpriteBatch, (EndX +1), EndY, (EndX + 1) + arrlongX, EndY - arrlongY, Color.Black);
            DrawLine(theSpriteBatch, (EndX +1), EndY + 1, (EndX + 1) + arrlongX, EndY - arrlongY, Color.Black);
            DrawLine(theSpriteBatch, (EndX +1), EndY + 2, (EndX + 1) + arrlongX, EndY - arrlongY, Color.Black);
            DrawLine(theSpriteBatch, (EndX +1), EndY + 3, (EndX + 1) + arrlongX, EndY - arrlongY, Color.Black);*/
        }
        protected void DrawLine(SpriteBatch sprite, int x0, int y0, int x1, int y1, Color color)
        {
            bool steep = (Math.Abs(y1 - y0) > Math.Abs(x1 - x0));
            if (steep)
            {
                int temp;
                temp = x0;
                x0 = y0;
                y0 = temp;
                temp = x1;
                x1 = y1;
                y1 = temp;
            }
            if (x0 > x1)
            {
                int temp;
                temp = x0;
                x0 = x1;
                x1 = temp;
                temp = y0;
                y0 = y1;
                y1 = temp;
            }
            int deltax = x1 - x0;
            int deltay = Math.Abs(y1 - y0);
            int error = deltax / 2;
            int ystep;
            int y = y0;
            if (y0 < y1)
                ystep = 1;
            else
                ystep = -1;
            for (int x = (int)x0; x <= x1; x++)
            {
                if (steep)
                    sprite.Draw(pixel, new Vector2(y, x), color);
                else
                    sprite.Draw(pixel, new Vector2(x, y), color);
                error = error - deltay;
                if (error < 0)
                {
                    y = y + ystep;
                    error = error + deltax;
                }
            }
        }
    }
}
