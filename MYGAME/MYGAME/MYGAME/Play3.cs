using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MYGAME
{
    class Play3
    {

        Texture2D background;
        Player player1 = new Player();

        Arrow myarr = new Arrow();
        KeyboardState pks;
        bool getthing = false;
        //bool Bad = false;
        bool grate = false;
        Sprite boom = new Sprite();

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

        }
    }
}
