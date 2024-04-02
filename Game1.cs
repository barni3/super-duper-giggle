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
        private Texture2D himsprite;
       Vector2  _position;
        Vector2 position;
       private Vector2 dir;
        private int spritewidth = 150;
        private int spriteheight = 133;
        private Vector2 velocity;
        private Texture2D spriteimage;
        private float spriteWidth;

        private Enemy enemy;

        public float speed = 100;

        private int screenWidth = 1920;

        public int ScreenWidth
        {
            get { return screenWidth = 1920; }
            set { screenWidth = value; }
        }
        private int screenHeight = 1080;

        public int ScreenHeight
        {
            get { return screenHeight = 1080; }
            set { screenHeight = value; }
        }
        public float spriteHeight
        {
            get
            {
                float scale = spriteWidth / spriteimage.Width;
                return spriteimage.Height * scale;
            }
        }

        public Rectangle PositionRectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)spriteHeight); }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.velocity = new Vector2(-1.0f, 5.0f);
            this.position = position;




            enemy = new Enemy(this, new Vector2(0, 0));
            
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
            himsprite = Content.Load<Texture2D>("1 IDLE_000");
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
            if (_position.X < -1920)
            {
                _position.X = -1920;
            }
            if (_position.X > 0)
            {
                _position.X = 0;
            }
            if (_position.Y < -1080)
            {
                _position.Y =  - 1080;
            }
            if (_position.Y > 0)
            {
                _position.Y = 0;
            }

            //enemy movement
            position += velocity;

            if (position.Y < 0 || position.Y > (ScreenHeight - spriteHeight))
            {
                velocity.Y *= -1;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, _position, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(knightSprite, new Vector2(960 - spritewidth, 540 - spriteheight), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            _spriteBatch.Draw(himsprite, new Vector2(enemy.position.X, enemy.position.Y), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            _spriteBatch.End();
           
            base.Draw(gameTime);    
        }
    }
}