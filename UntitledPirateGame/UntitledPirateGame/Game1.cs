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
        Canvas CANVAS;
        List<Chunk> Chunks;
        Texture2D Default;
        Texture2D Background;
        Player player;
        Entity bckgrnd;
        SpriteFont font;

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
            Chunks = new List<Chunk>();
            Chunks.Add(new Chunk(0, 0, 4096));
            
            
            
            

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
            DRAWER = new Drawer(spriteBatch);
            CANVAS = new Canvas();
            Default = this.Content.Load<Texture2D>("defaultSprite");
            Background = this.Content.Load<Texture2D>("testBackground");
            font = Content.Load<SpriteFont>("font");

            Chunks[0].Add(bckgrnd = new Entity(4096, 4096, 2048, 2048, 0, 0, true, Background));
            Chunks[0].Add(player = new Player(500, 16, 16, 0, 0, 1, 0, true, Default));

            //Canvas Start
            UIPanel panel = new UIPanel(new Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 50, 50), null, 0);
            panel.AddComponent(new UIButton(new OnClickDelegate(player.ResetPos), new OnHoverDelegate(Hover), "Test Button", new Rectangle(120, 120, 20, 20), null, 0, font, Color.Black, Color.Aquamarine, TextAlign.Center));
            CANVAS.AddComponent(panel);
            //Canvas End
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
            Screen.X = (int)player.vars.DrawingVector.X;
            Screen.Y = (int)player.vars.DrawingVector.Y;
            CANVAS.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            List<Entity> OnScreenEntities = new List<Entity>();
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
            int px = 0;
            int py = 0;
            bool pos = false;
            int bx = 0;
            int by = 0;
            bool cos = false;
            bool bos = false;

            if (bckgrnd != null)
            {
                bx = bckgrnd.vars.CollisionRectangle.X;
                by = bckgrnd.vars.CollisionRectangle.Y;
                bos = bckgrnd.OnScreen;
            }
            if (player != null)
            {
                px = (int)player.vars.DrawingVector.X;
                py = (int)player.vars.DrawingVector.Y;
                pos = player.OnScreen;
            }
            if (Chunks[0] != null)
            {
                cos = Chunks[0].OnScreen;
            }

            Debug.WriteLine(
                
                "Player ({2},{3})\n" +
                "Background ({4},{5})\n" +
                "Player On Screen {6}\n" +
                "Background On Screen {7}\n" +
                "Chunk on screen{8}\n" +
                "Screen ({0},{1})\n" +
                "Pointer({9},{10}", Screen.X, Screen.Y,
                px, py,
                bx, by,
                pos, bos,
                cos,
                Pointer.Position.X, Pointer.Position.Y

                
                );
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            if (OnScreenEntities.Count > 0)
            {
                DRAWER.Draw(OnScreenEntities, CANVAS.GetUIComponents());
            }
            
            base.Draw(gameTime);
        }

        public void Hover()
        {
            System.Console.WriteLine("Hover");
        }
    }
}