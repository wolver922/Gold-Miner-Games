using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MYGAME
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;
        enum GS { Menu, Play, Help, Quit, Over };
        Texture2D mark;
        Texture2D background;
        GS gamestate = GS.Menu;
        SpriteFont font1;
   
        bool liferight = true;
        int countX = 0;
        
        int CurrentSelect = 0;
        KeyboardState pks;
        Play play1;
        int CTime = 0;
        int time = 5;
        int Volume = 100;
        SoundEffect soundEffect;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            play1 = new Play();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            soundEffect = Content.Load<SoundEffect>("進入遊戲音效");
            // TODO: use this.Content to load your game content here
            song = Content.Load<Song>("From_Russia_With_Love(遊戲音樂)");
            MediaPlayer.Play(song);
            mark = Content.Load<Texture2D>("採金礦標題");
            background = Content.Load<Texture2D>("背景圖");
            font1 = Content.Load<SpriteFont>("123");
            play1.LoadContent(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            //MediaPlayer.Play(song);
            this.CTime += gameTime.ElapsedGameTime.Milliseconds;
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            KeyboardState ks = Keyboard.GetState();
            // TODO: Add your update logic here
            /*if ((ks.IsKeyUp(Keys.F1) == true) && (pks.IsKeyDown(Keys.F1) == true))
            {
                Volume += 10;
                if (Volume > 100)
                    Volume = 100;
            }
            if ((ks.IsKeyUp(Keys.F2) == true) && (pks.IsKeyDown(Keys.F2) == true))
            {
                Volume -= 10;
                if (Volume < 0)
                    Volume = 0;
            }*/
            MediaPlayer.Volume = (float)(40 / 100.0);
            switch (gamestate)
            {
                case GS.Menu:
                    
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
                    if (((ks.IsKeyDown(Keys.Up) == true) && (pks.IsKeyDown(Keys.Up) == false)))
                        if (CurrentSelect > 0)
                            CurrentSelect--;
                    if (((ks.IsKeyDown(Keys.Down) == true) && (pks.IsKeyDown(Keys.Down) == false)))
                        if (CurrentSelect < 2)
                            CurrentSelect++;
                    if ( ((ks.IsKeyDown(Keys.Enter) == true) && (pks.IsKeyDown(Keys.Enter) == false)))
                     switch (CurrentSelect)
                        {
                           case 0:
                              gamestate = GS.Play;
                             // soundEffect.Play(0.3f, 0.2f, 0f);
                               break;
                           case 1:
                              gamestate = GS.Help;
                              break;
                           case 2:
                              gamestate = GS.Quit;
                              break;
                        }
                    break;
                case GS.Play:

                    if ((ks.IsKeyDown(Keys.Escape) == true) && (pks.IsKeyDown(Keys.Escape) == false))
                    {
                        gamestate = GS.Menu;
                    }
                    play1.Update(gameTime);
                    if (play1.gameover == true || play1.win == true)
                    {
                        if (this.CTime >= 1000)
                        {
                            this.CTime = 0;
                            time -= 1;
                        }
                        if (time < 0)
                        gamestate = GS.Over;
                    }

                    break;
                case GS.Help:
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
                    if ((ks.IsKeyDown(Keys.Escape) == true) && (pks.IsKeyDown(Keys.Escape) == false))
                    {
                        gamestate = GS.Menu;
                    }
                    break;
                     case GS.Over:
                    play1 = null;
                    //play1 = new Play();
                    if ((ks.IsKeyDown(Keys.Escape) == true) && (pks.IsKeyDown(Keys.Escape) == false))
                    {
                         gamestate = GS.Menu;
                    }
                         break;
                case GS.Quit:
                    this.Exit();
                    break;
               
                    
            }
            pks = ks;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
           
            switch (gamestate)
            {
                case GS.Menu:
                     spriteBatch.Begin();
                     double angleX = Math.PI * countX / 180.0;
                     int X = (int)(Math.Sin(angleX) * 10);
                    spriteBatch.Draw(background, new Rectangle(0, 0, 1080, 720), new Rectangle(X, 20, 1080, 720), Color.White);
                     spriteBatch.Draw(mark, new Rectangle(0,0,600,300), Color.White);
                        if (CurrentSelect == 0)
                            spriteBatch.DrawString(font1, "開始遊戲", new Vector2(350-5 , 400-2), Color.Yellow, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);
                        else
                            spriteBatch.DrawString(font1, "開始遊戲", new Vector2(350, 400), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.5f);

                        if (CurrentSelect == 1)
                            spriteBatch.DrawString(font1, "遊戲說明", new Vector2(350-5, 450-2), Color.Yellow, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);
                        else
                            spriteBatch.DrawString(font1, "遊戲說明", new Vector2(350, 450), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.5f);
                        if (CurrentSelect == 2)
                            spriteBatch.DrawString(font1, "離開遊戲", new Vector2(350-5, 500-2), Color.Yellow, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 0.5f);
                        else
                            spriteBatch.DrawString(font1, "離開遊戲", new Vector2(350, 500), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.5f);

                        spriteBatch.End();
                    break;
                case GS.Play:
                    spriteBatch.Begin();
                    play1.Draw(this.spriteBatch);
                    spriteBatch.End();
                    break;
                case GS.Help:
                    spriteBatch.Begin();
                    double angleX1 = Math.PI * countX / 180.0;
                     int X1 = (int)(Math.Sin(angleX1) * 10);
                    spriteBatch.Draw(background, new Rectangle(0, 0, 1080, 720), new Rectangle(X1, 20, 1080, 720), Color.White);
                    spriteBatch.Draw(mark, new Rectangle(0, 0, 400, 200), Color.White);
                    spriteBatch.DrawString(font1, "遊戲規則:\r\n\r\n必須在100秒內賺到一定金額的錢，小心那些拖延時間笨重的大石頭\r\n，還有戰後遺留下來的未爆彈，不小心勾到未爆彈會扣你的金錢。\r\n\r\n遊戲方法:\r\n\r\n利用擺盪的繩子把金礦拉起，按方向鍵(↓)拋出繩索，(ESC)鍵返回。", new Vector2(0, 200), Color.BurlyWood, 0, new Vector2(0, 0), 3f, SpriteEffects.None, 0.5f);
                    spriteBatch.End();
                    break;
                case GS.Over:
                    
                     graphics.GraphicsDevice.Clear(Color.Red);
                     spriteBatch.Begin();
                     spriteBatch.Draw(mark, new Rectangle(0, 0, 600, 300), Color.White);
                     spriteBatch.DrawString(font1, "在來一次吧~", new Vector2(500, 500), Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0.5f);
                     spriteBatch.End();
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
