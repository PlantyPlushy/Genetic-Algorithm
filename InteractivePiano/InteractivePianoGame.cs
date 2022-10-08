using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteRender;

namespace InteractivePiano
{
    public class  InteractivePianoGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PianoSprite _pianoSprite;

        public InteractivePianoGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _pianoSprite = new PianoSprite(this, "");
            this.Components.Add(_pianoSprite);
            _graphics.PreferredBackBufferWidth = 1000;  
            _graphics.PreferredBackBufferHeight = 500;   
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _pianoSprite.Draw(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Brown);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
