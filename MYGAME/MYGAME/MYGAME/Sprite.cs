using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MYGAME
{
    class Sprite
    {
        //類別之座標
        public Vector2 Position = new Vector2(0, 0);

        //類別圖檔
        public Texture2D mSpriteTexture;

        //類別名稱
        public string AssetName;
        //價格
        public int money = 0;
        //重量
        public int Weight = 0;

        //改變後大小
        public Rectangle Size;
        public Rectangle Bounds;
        //The Rectangular area from the original image that 
        //defines the Sprite. 
        public bool good = false;
        Rectangle mSource;
        public Rectangle Source
        {
            get { return mSource; }
            set
            {
                mSource = value;
                Size = new Rectangle(0, 0, (int)(mSource.Width * Scale), (int)(mSource.Height * Scale));
            }
        }


        //The amount to increase/decrease the size of the original sprite. When
        //modified throught he property, the Size of the sprite is recalculated
        //with the new scale applied.
        //儲存圖檔現在大小
        private float mScale = 1.0f;
        public float Scale
        {
            //取得Scale時回傳mScale值
            get { return mScale; }
            //設定Scale時
            set
            {
                mScale = value;
                //Recalculate the Size of the Sprite with the new scale
                Size = new Rectangle(0, 0, (int)(Source.Width * Scale), (int)(Source.Height * Scale));
                Bounds = new Rectangle((int)Position.X, (int)Position.Y, Size.Width, Size.Height);
            }
        }

        //讀檔成員函數:取得Content、名稱即可建立新物件
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            //載入圖片
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            //載入名稱
            AssetName = theAssetName;
            //讀入一開始圖片大小
            Source = new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height);
            //讀入改變圖片大小後大小
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Size.Width, Size.Height);
        }

        //更新遊戲:取得GameTime、每次移動距離、目前位置 
        public void Update(GameTime theGameTime)//, Vector2 theSpeed, Vector2 theDirection)
        {
            //更新位置
            //Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Size.Width, Size.Height);
        }

        //畫圖:取得SpriteBatch 畫上物件
        public virtual void Draw(SpriteBatch theSpriteBatch)
        {
            //輸入圖檔 位置 Source 顏色 ...
            theSpriteBatch.Draw(mSpriteTexture, Position, Source,
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
           
           // theSpriteBatch.Draw(

        }

    }
}
