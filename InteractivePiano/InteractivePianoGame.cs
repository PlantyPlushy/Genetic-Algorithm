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

            // if (Console.KeyAvailable)
            // {
            //     var key = Console.ReadKey(true);
            //     if (key.Key == ConsoleKey.Escape)
            //     {
            //         break;
            //     } 
            //     char userKey = key.KeyChar;
            //     piano.StrikeKey(userKey);
            // }
            // //Plays the audio 
            // for (int i = 0; i < SamplesPerLoop; i++)
            // {
            //     audio.Play(piano.Play());
            // }

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
