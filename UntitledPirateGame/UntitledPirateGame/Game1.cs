using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        List<Chunk> Chunks;
        Texture2D Default;
        

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
            DRAWER = new Drawer();
            Chunks = new List<Chunk>();
            Chunks.Add(new Chunk(0, 0));
            Chunks.Add(new Chunk(100, 0));
            Chunks.Add(new Chunk(0, 100));
            Chunks.Add(new Chunk(100, 100));
            Chunks[0].Add(new Entities(16, 16, 5, 5, 0, 0, true, Default));
            

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
            Default = Content.Load<Texture2D>("defaultSprite");

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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            List<Entities> OnScreenEntities = new List<Entities>();
            for (int i = 0; i < Chunks.Count; i++)
            {
                if (Chunks[i].OnScreen)
                {
                    for (int ii = 0; ii < Chunks[i].members.Count;ii++)
                    {
                        if (Chunks[i].members[ii].OnScreen)
                        {
                            OnScreenEntities.Add(Chunks[i].members[ii]);
                        }
                    }
                }
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            DRAWER.Draw(spriteBatch,OnScreenEntities);
            base.Draw(gameTime);
        }
    }
}