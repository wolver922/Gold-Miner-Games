using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

/*using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;*/
namespace MYGAME
{
    class Play
    {
        
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
        public void setSprite(Sprite S, ContentManager theContentManager, int x,int y, string name, float scale, bool good, int money, int Wight)
        {
            S.Position = new  Vector2(x,y);
            S.LoadContent(theContentManager, name);
            S.Scale = scale;
            S.good = good;
            S.money = money;
            S.Weight = Wight;
            allSprite.Add(S);
        }
        public void LoadContent(ContentManager theContentManager)
        {
            winsong = theContentManager.Load<SoundEffect>("winsong");
            soundEffect = theContentManager.Load<SoundEffect>("繩子射出");
            bloodpos = new Vector2(0, 9);
            life = 0;
            winmap = theContentManager.Load<Texture2D>("WIN");
            blood = theContentManager.Load<Texture2D>("血條");
            textmoney = theContentManager.Load<Texture2D>("金錢量");
            background = theContentManager.Load<Texture2D>("遊戲背景2");
            number = theContentManager.Load<Texture2D>("數字1");
            textnumber = theContentManager.Load<Texture2D>("剩餘時間");
            gameovermap = theContentManager.Load<Texture2D>("game_over");
            player1.LoadContent(theContentManager);
            myarr.LoadContent(theContentManager);

                      //放物件           //放的位置x , y  //檔名//大小//好壞  //錢 //重(0~30)
            
            setSprite(boom1, theContentManager, 980, 620, "未爆彈1", 0.4f, false, -500, 18);
            setSprite(stone2, theContentManager, 300, 500, "石頭", 0.8f, false, 50, 23);
            setSprite(boom2, theContentManager, 0, 120, "未爆彈2", 0.2f, false, -500, 17);
            setSprite(boom3, theContentManager, 200, 220, "未爆彈2", 0.2f, false, -500, 17);
            setSprite(stone, theContentManager, 500, 500, "石頭", 0.8f, false, 50, 23);
            setSprite(stone3, theContentManager, 500, 200, "石頭", 0.5f, false, 50, 20);
            setSprite(stone4, theContentManager, 220, 500, "石頭", 0.6f, false, 50, 22);
            setSprite(stone5, theContentManager, 900, 200, "石頭", 0.3f, false, 50, 19);
            setSprite(stone6, theContentManager, 700, 350, "石頭", 0.3f, false, 50, 19);
            setSprite(stone7, theContentManager, 10, 500, "石頭", 0.8f, false, 50, 23);
            setSprite(gold2, theContentManager, 50, 150, "金礦1", 0.8f, true, 1000, 20);
            setSprite(gold6, theContentManager, 300, 120, "金礦1", 0.1f, true, 150, 15);
            setSprite(gold7, theContentManager, 190, 180, "金礦1", 0.1f, true, 150, 15);
            setSprite(gold8, theContentManager, 670, 250, "金礦1", 0.4f, true, 500, 18);
            setSprite(gold9, theContentManager, 800, 250, "金礦1", 0.7f, true, 1500, 20);
            setSprite(gold3, theContentManager, 750, 500, "金礦1", 0.2f, true, 200, 15);
            setSprite(gold4, theContentManager, 900, 500, "金礦1", 0.3f, true, 400, 18);
            setSprite(gold5, theContentManager, 650, 600, "金礦1", 0.3f, true, 400, 17);
            setSprite(gold1, theContentManager, 240, 600, "good1", 0.1f, true, 1000, 1);
            setSprite(good, theContentManager, 900, 650, "good1", 0.1f, true, 1000, 1);
            setSprite(good2, theContentManager, 600, 600, "good1", 0.1f, true, 1000, 1);
            setSprite(good3, theContentManager, 0, 600, "good1", 0.6f, true, 2000, 15);
        }
        
        public void Update(GameTime theGameTime)
        {
            if (myMoney >= maxmoney)
                win = true;
            this.CTime += theGameTime.ElapsedGameTime.Milliseconds;
            if (this.CTime >= 1000)
            {
                this.CTime = 0;
                time -= 1;
            }
            if (time < 0)
                gameover = true;
            if (liferight)
            {
                countX++;
                if (countX == 90)
                    liferight = false;
            }
            else
            {
                countX--;
                if (countX == -90)
                    liferight = true;
            }
            KeyboardState ks = Keyboard.GetState();
            
            player1.Update(theGameTime);
            myarrState = myarr.Update(theGameTime);
            foreach (Sprite aSprite in allSprite)
            {
                aSprite.Update(theGameTime);
            }
            if (((ks.IsKeyDown(Keys.Down) == true) && (pks.IsKeyDown(Keys.Down) == false)))//箭點發射
            {
                
                myarr.changeStart(true);
            }
            
            switch (myarrState)//(0 = 一般狀態  1 = 發射狀態  2 = 收回狀態 3 = 結束收回)
            {
                case 0:
                    break;
                case 1:
                    if (((ks.IsKeyDown(Keys.Down) == true) && (pks.IsKeyDown(Keys.Down) == false))&&co++ == 0)
                    {
                        soundEffect.Play(1.0f, -1f, 0f);
                    }
                    player1.ChangeState(2);
                    foreach (Sprite aSprite in allSprite)
                    {
                        if (Collision.Intersects(myarr.touchPoint, aSprite))
                        {
                            grate = aSprite.good;
                            getthing = true;
                            count = allSprite.IndexOf(aSprite);
                            myarr.touchout = true;
                        }
                    }
                    break;
                case 2:
                    if (getthing == false)
                    {
                        player1.ChangeState(6);
                        break;
                    }
                    if (grate == false)
                    {
                        allSprite[count].Position = new Vector2(myarr.touchPoint.Position.X - allSprite[count].Size.Width / 2,
                            myarr.touchPoint.Position.Y - allSprite[count].Size.Height / 2);
                        myarr.speed = 20 - allSprite[count].Weight;
                        player1.ChangeState(4);
                    }
                    else
                    {
                        allSprite[count].Position = new Vector2 (myarr.touchPoint.Position.X - allSprite[count].Size.Width/2,
                            myarr.touchPoint.Position.Y - allSprite[count].Size.Height/2);
                        myarr.speed = 20 - allSprite[count].Weight;
                        player1.ChangeState(4);
                    }
                    break;
                case 3:
                    if (getthing == false)
                    {
                        player1.ChangeState(6);
                        co = 0;
                        break;
                    }
                    if (grate == false)
                    {
                        player1.ChangeState(6);
                        addscore(allSprite[count].money);
                        getfinishInitialize();
                        allSprite.Remove(allSprite[count]);
                    }
                    else
                    {
                        player1.ChangeState(5);
                        addscore(allSprite[count].money);
                        getfinishInitialize();
                        allSprite.Remove(allSprite[count]);
                    }
                    break;
            }
        }
        public void getfinishInitialize()
        { 
            myarr.speed = 20;
            grate = false;
            getthing = false;
            co = 0;
        }
        public void addscore(int ascore)
        {
            life = life + (365*ascore /5000);
            myMoney += ascore;
            if (life > 365)
            {
                life = 365;
            }
            else if (life < 0)
            {
                life = 0;
            }
        }
        public virtual void Draw(SpriteBatch theSpriteBatch)
        {
                theSpriteBatch.Draw(background, new Rectangle(0, 0, 1080, 720), new Rectangle(0, 0, 1080, 720), Color.White);
                double angleX = Math.PI * countX / 180.0;
                int X = (int)(Math.Sin(angleX) * 10);
                theSpriteBatch.Draw(textmoney, new Vector2(20, 30 + X / 2), Color.White);
                theSpriteBatch.Draw(blood, new Vector2(0, 9), new Rectangle(0, 11, 365, 11), Color.White);
                theSpriteBatch.Draw(blood, bloodpos, new Rectangle(0, 0, (int)life, 11), Color.White);
                theSpriteBatch.Draw(blood, new Vector2(0, 0), new Rectangle(20, 24, 400, 100), Color.White);
                int x = WIDTH - 50, temp = time;
                theSpriteBatch.Draw(textnumber, new Rectangle(800 - 50, 10 - X, 200, 60), new Rectangle(0, 0, 1110, 460), Color.White);
                while (temp != 0)
                {
                    int current = temp % 10;
                    theSpriteBatch.Draw(number, new Vector2(x, 10), new Rectangle(current * 130, 0, 130, 167), Color.White, 0.0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0);
                    x -= 50;
                    temp = temp / 10;
                }
                myarr.Draw(theSpriteBatch);
                player1.Draw(theSpriteBatch);
                foreach (Sprite aSprite in allSprite)
                {
                    aSprite.Draw(theSpriteBatch);
                }
                if (win == true)
                {
                    theSpriteBatch.Draw(winmap, new Vector2(300, 200), new Rectangle(0, 0, 450, 250), Color.White);
                   // winsong.Play(1f, -0f, 0f);
                }
             if (gameover == true && win == false)
                 theSpriteBatch.Draw(gameovermap, new Vector2(300, 200), new Rectangle(0, 0, 450, 250), Color.White);

        }
    }
}
