using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace UntitledPirateGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Drawer DRAWER;
        Texture2D Default;
        Texture2D Background;
        Player player;
        Entity bckgrnd;
        ChunkLoader CL;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            //graphics.PreferredBackBufferWidth = 1920;
            //graphics.PreferredBackBufferHeight = 1080;



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
            this.IsMouseVisible = true;
            DRAWER = new Drawer();
            CL = new ChunkLoader(5000, 10, 10);
            base.Initialize();
            Screen.SetGame(this);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Default = this.Content.Load<Texture2D>("defaultSprite");
            Background = this.Content.Load<Texture2D>("testBackground");
            CL.ChunkMap[0,0].Add(player = new Player(200,16,16,5,5,2,0,true,Default));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            CL.Update();
            Screen.X = (int)player.vars.DrawingVector.X;
            Screen.Y = (int)player.vars.DrawingVector.Y;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            List<Entity> OnScreenEntities = new List<Entity>();
            Chunk[,] Chunks = CL.ChunkMap;
            for(int i = 0; i < Chunks.GetLength(0); i++)
            {
                for(int ii = 0; ii < Chunks.GetLength(1); ii++)
                {
                    if (Chunks[i,ii].OnScreen)
                    {
                        for (int iii = 0; iii < Chunks[i, ii].members.Count;iii++)
                        {
                            Entity Member = Chunks[i, ii].members[iii];
                            if (Member.OnScreen)
                            {
                                OnScreenEntities.Add(Member);
                            }

                        }
                    }
                }
            }
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            if (OnScreenEntities.Count > 0)
            {
                DRAWER.Draw(spriteBatch, OnScreenEntities);
            }
            
            base.Draw(gameTime);
        }
    }
}