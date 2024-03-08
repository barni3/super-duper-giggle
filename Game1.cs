using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Versioning;

namespace TheStrongest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D knightSprite;
        Texture2D backgroundSprite;
        double xpos = 0, ypos = 0;
        int w;
        int h;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.PreferredBackBufferWidth = w;
            _graphics.PreferredBackBufferHeight = h;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            knightSprite = Content.Load<Texture2D>("k9vd_11lt_230630");
            backgroundSprite = Content.Load<Texture2D>("pixel_art___dungeon_background__loopable__by_albertov_dbpx7j9");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                ypos -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                ypos += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                xpos -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                xpos += 3;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.W) && (Keyboard.GetState().IsKeyDown(Keys.D))  {
                xpos += 4.24264068712;
                ypos += 4.24264068712;
            }
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Rectangle(0, 0, 1920, 1080), Color.White);
            _spriteBatch.Draw(knightSprite, new Rectangle(xpos, ypos, 200, 200), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}