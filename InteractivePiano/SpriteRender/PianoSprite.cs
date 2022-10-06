using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PianoSimulator;
using Backend;
using InteractivePiano;

namespace SpriteRender
{
    class PianoSprite : DrawableGameComponent
    {
        private Game _game;
        private string _availableKeys;
        private Key[] _keys;
        private Piano _piano;
        private SpriteBatch _spriteBatch;

        public PianoSprite(Game game, string availableKeys) : base(game)
        {
            this._game = game;
            _availableKeys = availableKeys;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(sortMode: SpriteSortMode.Texture);

            foreach (Key key in _keys)
            {
                key.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _piano = new Piano();

            _keys = new Key[_piano.Keys.Length];
            int xPosition = 0;   
            int imageWidth = 36;
            DetermineKey dk = new DetermineKey(_piano.Keys.Length);
            for (int i = 0; i < _keys.Length; i++)
            {
                // if the current char in the pattern is w i.e. is a white key
                if (dk.IsWhite(i))
                {
                    _keys[i] = new Key(true,new Vector2(xPosition,0));
                    // creates a gap for the next key to be placed on
                    xPosition+= imageWidth + 5;  
                } else 
                {
                    _keys[i] = new Key(false,new Vector2((xPosition - (imageWidth / 2)) , 0));
                }
            }
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            foreach (Key key in _keys)
            {
                key.LoadContent(_game.Content);
            }
            base.LoadContent();
        }
    }
}