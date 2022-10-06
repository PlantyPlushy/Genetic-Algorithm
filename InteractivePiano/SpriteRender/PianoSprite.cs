using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PianoSimulator;
using Backend;

namespace SpriteRender
{
    class PianoSprite : DrawableGameComponent
    {
        private Game _game;
        private string _availableKeys;
        private Piano _piano;
        private Texture2D _whiteKeyImage;
        private Texture2D _blackKeyImage;
        private SpriteBatch _spriteBatch;

        public PianoSprite(Game game, string availableKeys) : base(game)
        {
            this._game = game;
            _availableKeys = availableKeys;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(sortMode: SpriteSortMode.Texture);
            int xPosition = 0;   
            int imageWidth = _whiteKeyImage.Width;
            // string keys = _piano.Keys;
            DetermineKey dk = new DetermineKey(_piano.Keys.Length);
            for (int i = 0; i < dk.StringLength; i++)
            {
                // if the current char in the pattern is w i.e. is a white key
                if (dk.IsWhite(i))
                {
                    _spriteBatch.Draw(_whiteKeyImage, new Vector2(xPosition,0), Color.White);
                    // creates a gap for the next key to be placed on
                    xPosition+= imageWidth + 5;  
                } else 
                {
                    _spriteBatch.Draw(_blackKeyImage, new Vector2((xPosition - (imageWidth / 2)) , 0), Color.White);  
                }          
                    
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            _piano = new Piano();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _whiteKeyImage = _game.Content.Load<Texture2D>("whiteKey");
            _blackKeyImage = _game.Content.Load<Texture2D>("blackKey");
            base.LoadContent();
        }
    }
}