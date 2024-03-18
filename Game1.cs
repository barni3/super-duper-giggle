using Microsoft.VisualBasic;
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
       Vector2  _position;
       private Vector2 dir;
        Vector2 position;
        int w;
        int h;
        public float speed = 100;
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
            knightSprite = Content.Load<Texture2D>("1 IDLE_000");
            backgroundSprite = Content.Load<Texture2D>("pixel_art___dungeon_background__loopable__by_albertov_dbpx7j9");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float speed = 500; // pixels per second
            
            


            var dir = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                dir.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                dir.Y -= 1;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                dir.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                dir.X -= 1;

            // skip further processing if no keys are pressed.
            if (dir == Vector2.Zero)
                return;

            // Ensure the vector has unit length
            dir.Normalize();
            // Define a speed variable for how many units to move
            // Should probably also scale the speed with the delta time 
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position += dir * speed * deltaTime;
            // TODO: Add your update logic here
            if (_position.X < -w)
            {
                _position.X = 0;
            }
            if (_position.X > 0)
            {
                _position.X = -w;
            }
            if (_position.Y < -h)
            {
                _position.Y = 0;
            }
            if (_position.Y > 0)
            {
                _position.Y = -h;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, _position, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(knightSprite, new Vector2(w/2 - 150, h/2 - 133), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f); 
            _spriteBatch.End();

            base.Draw(gameTime);    
        }
    }
}