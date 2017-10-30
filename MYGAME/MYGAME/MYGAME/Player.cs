using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace MYGAME
{
    class Player
    {
        int HEIGHT = 130;
        int WIDTH = 130;
        int SOURCEHEIGHT = 70;
        int SOURCEWIDTH = 66;
        int PLAYER_START_POSITION_X = 440 + 52;  //540 - WIDTH + 30 +2;
        int PLAYER_START_POSITION_Y = -9;  //100 - HEIGHT + 30 -9;
        Texture2D myPlayer;
                  //一般狀態1   發呆2.3     發射4      沒托東西4      托東西5.8    拿到成功6.7   沒拿到或拿到爛的9
        enum State { common = 0, Daze = 1, Launch = 2, RevokeNull=3, RevokeThing=4, GetFinish=5, GetLost=6 }
        State mystate = State.common;
        int ory = 0;
        int orx = 1;
        int count = 0;
        public void LoadContent(ContentManager theContentManager)
        {
            myPlayer = theContentManager.Load<Texture2D>("主角圖");
        }
        public void ChangeState(int intState)
        {
            switch (intState)
            {
                case 0:
                    mystate = State.common;
                    break;
                case 1:
                    mystate = State.Daze;
                    break;
                case 2:
                    mystate = State.Launch;
                    break;
                case 3:
                    mystate = State.RevokeNull;
                    break;
                case 4:
                    mystate = State.RevokeThing;
                    break;
                case 5:
                    mystate = State.GetFinish;
                    break;
                case 6:
                    mystate = State.GetLost;
                    break;
            }
        }
        public void Update(GameTime theGameTime)
        {

            
            switch (mystate)
            {
                case State.common:
                    if (count++ > 100)
                    {
                        this.ChangeState(1);
                        count = 0;
                    }
                    break;
                case State.Daze:
                    if (count++ > 30)
                    {
                        orx = 0;
                        if (count > 60)
                            orx = 1;
                        if (count > 90)
                        {
                            count = 0;
                            this.ChangeState(0);
                        }
                    }
                    /*if (count++ > 30)
                    {
                        if (orx++ == 2)
                            orx = 1;
                        count = 0;
                    }*/
                    break;
                case State.GetFinish:
                    if (count++ > 30)
                    {
                        orx = 0;
                        if (count > 60)
                            orx = 1;
                        if (count > 90)
                        {
                            count = 0;
                            this.ChangeState(0);
                        }
                    }
                    break;
                case State.GetLost:
                    if (count++ > 30)
                    {
                        count = 0;
                        this.ChangeState(0);
                    }
                    break;
                case State.Launch:
                    break;
                case State.RevokeNull:
                    break;
                case State.RevokeThing:
                    if (count++ > 30)
                    {
                        if (orx++ == 1)
                        {
                            orx = 0;
                        }
                        count = 0;
                    }
                    break;
            }
        }
        public virtual void Draw(SpriteBatch theSpriteBatch)
        {
            switch (mystate)
            {
                case State.common:
                    HEIGHT = 130;
                    WIDTH = 130;
                    SOURCEHEIGHT = 70;
                    SOURCEWIDTH = 66;
                    PLAYER_START_POSITION_X = 440 + 52;
                    PLAYER_START_POSITION_Y = -9;
                    theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT), new Rectangle(0, 0, SOURCEWIDTH, SOURCEWIDTH), Color.White);
                    break;
                case State.Daze:
                    HEIGHT = 130;
                    WIDTH = 130;
                    SOURCEHEIGHT = 70;
                    SOURCEWIDTH = 66;
                    PLAYER_START_POSITION_X = 495 + 20;
                    PLAYER_START_POSITION_Y = -4;
                    theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                        new Rectangle((orx+1) * SOURCEWIDTH, ory * SOURCEHEIGHT, SOURCEWIDTH, SOURCEHEIGHT), Color.White);
                    break;
                case State.GetFinish:
                    HEIGHT = 110;
                    WIDTH = 110;
                    SOURCEHEIGHT = 111;
                    SOURCEWIDTH = 60;
                    PLAYER_START_POSITION_X = 505;
                    PLAYER_START_POSITION_Y = 8;
                    theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                        new Rectangle(80 +orx*80, 64, 56, SOURCEWIDTH), Color.White);
                    break;
                case State.GetLost:
                    HEIGHT = 130;
                    WIDTH = 130;
                    SOURCEHEIGHT = 70;
                    SOURCEWIDTH = 66;
                    PLAYER_START_POSITION_X = 517;
                    PLAYER_START_POSITION_Y = 12;
                    theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                        new Rectangle(154, 136, SOURCEWIDTH, SOURCEWIDTH), Color.White);
                    break;
                case State.Launch:
                    HEIGHT = 130;
                    WIDTH = 130;
                    SOURCEHEIGHT = 70;
                    SOURCEWIDTH = 66;
                    PLAYER_START_POSITION_X = 519;
                    PLAYER_START_POSITION_Y = -6;
                    theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                        new Rectangle(192, 0, SOURCEWIDTH, SOURCEWIDTH), Color.White);
                    break;
                case State.RevokeNull:
                    HEIGHT = 130;
                    WIDTH = 130;
                    SOURCEHEIGHT = 70;
                    SOURCEWIDTH = 66;
                    PLAYER_START_POSITION_X = 519;
                    PLAYER_START_POSITION_Y = -6;
                    theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                        new Rectangle(192,0, SOURCEWIDTH, SOURCEWIDTH), Color.White);
                    break;
                case State.RevokeThing:

                    if (orx == 0)
                    {
                        HEIGHT = 120;
                        WIDTH = 120;
                        SOURCEHEIGHT = 111;
                        SOURCEWIDTH = 66;
                        PLAYER_START_POSITION_X = 526;
                        PLAYER_START_POSITION_Y = 17;
                        theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                            new Rectangle(90, 135, SOURCEWIDTH, SOURCEWIDTH), Color.White);
                    }
                    else
                    {
                        HEIGHT = 120;
                        WIDTH = 160;
                        SOURCEHEIGHT = 111;
                        SOURCEWIDTH = 66;
                        PLAYER_START_POSITION_X = 497;
                        PLAYER_START_POSITION_Y = 17;
                        theSpriteBatch.Draw(myPlayer, new Rectangle(PLAYER_START_POSITION_X, PLAYER_START_POSITION_Y, WIDTH, HEIGHT),
                        new Rectangle(0, 68, SOURCEWIDTH + 20, SOURCEWIDTH), Color.White);
                    }
                    break;
            }
            
        }

    }
}
