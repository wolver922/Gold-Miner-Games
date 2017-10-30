using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace MYGAME
{
    class Play2
    {
/*
        Texture2D background;
        Texture2D number;
        Texture2D textnumber;
        Texture2D blood;
        Texture2D textmoney;
        Vector2 bloodpos;
        Texture2D winmap;
        Texture2D gameovermap;
        double life;
        //玩家金錢
        int myMoney = 0;

        int WIDTH = 1080;

        Player player1 = new Player();
        int CTime = 0;
        int time = 100;
        Arrow myarr = new Arrow();
        KeyboardState pks;

        Sprite boom1 = new Sprite();
        Sprite boom2 = new Sprite();
        Sprite boom3 = new Sprite();
        Sprite stone = new Sprite();
        Sprite stone2 = new Sprite();
        Sprite stone3 = new Sprite();
        Sprite stone4 = new Sprite();
        Sprite stone5 = new Sprite();
        Sprite stone6 = new Sprite();
        Sprite stone7 = new Sprite();
        Sprite gold1 = new Sprite();
        Sprite gold3 = new Sprite();
        Sprite gold4 = new Sprite();
        Sprite gold5 = new Sprite();
        Sprite gold6 = new Sprite();
        Sprite gold7 = new Sprite();
        Sprite gold8 = new Sprite();
        Sprite gold9 = new Sprite();
        Sprite gold2 = new Sprite();
        Sprite good = new Sprite();
        Sprite good2 = new Sprite();
        Sprite good3 = new Sprite();
        int myarrState = 0;
        List<Sprite> allSprite = new List<Sprite>();
        bool getthing = false;
        bool grate = false;
        int count = 0;
        public bool gameover = false;
        public bool win = false;
        public bool brack = false;
        bool liferight = true;
        int countX = 0;
        //設置關卡滿分
        int maxmoney = 5000;
        SoundEffect soundEffect;
        SoundEffect winsong;
        int co = 0;
        public void setSprite(Sprite S, ContentManager theContentManager, int x, int y, string name, float scale, bool good, int money, int Wight)
        {
            S.Position = new Vector2(x, y);
            S.LoadContent(theContentManager, name);
            S.Scale = scale;
            S.good = good;
            S.money = money;
            S.Weight = Wight;
            allSprite.Add(S);
        }
        public void LoadContent(ContentManager theContentManager)
        {
            background = theContentManager.Load<Texture2D>("遊戲背景");
            player1.LoadContent(theContentManager);
            myarr.LoadContent(theContentManager);
            boom.LoadContent(theContentManager, "");
        }
        public void Update(GameTime theGameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            player1.Update(theGameTime);
            myarr.Update(theGameTime);
            if (((ks.IsKeyDown(Keys.Down) == true) && (pks.IsKeyDown(Keys.Down) == false)))//箭點與圖碰撞偵測
            {
                myarr.changeStart(true);
                player1.ChangeState(2);
                //Collision(箭點.Sprite與每張物品圖.Sprite)
                //return getthing . grate 設置player1.ChangeState(?);

            }

        }
        public virtual void Draw(SpriteBatch theSpriteBatch)
        {

            theSpriteBatch.Draw(background, new Rectangle(0, 0, 1080, 720), new Rectangle(0, 0, 1080, 720), Color.White);
            myarr.Draw(theSpriteBatch);
            player1.Draw(theSpriteBatch);

        }*/
    }
}
