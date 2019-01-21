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
        List<Chunk> Chunks;
        Texture2D Default;
        Player player;

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

            Chunks[0].Add(new Entities(16, 16, 60, 60, 0, 0, true, Default));
            Chunks[0].Add(player = new Player(8, 16, 16, 45, 45, 0, 0, true, Default));
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
                    //Debug.Write("Chunk is on screen");
                    for (int ii = 0; ii < Chunks[i].members.Count;ii++)
                    {
                        if (Chunks[i].members[ii].OnScreen)
                        {
                            //Debug.Write("Entity is on screen");
                            OnScreenEntities.Add(Chunks[i].members[ii]);
                        }
                    }
                }
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Debug.WriteLine("# of On screen ents {0}",OnScreenEntities.Count);
            // TODO: Add your drawing code here
            if (OnScreenEntities.Count > 0)
            {
                DRAWER.Draw(spriteBatch, OnScreenEntities);
            }
            
            base.Draw(gameTime);
        }
    }
}