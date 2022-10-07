using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PianoSimulator;
using Backend;
using InteractivePiano;
using Microsoft.Xna.Framework.Input;

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
            if (_availableKeys == "")
            {
                _piano = new Piano();
            } else {
                _piano = new Piano(_availableKeys);
                _availableKeys = _piano.Keys;
            }

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
              
            Keys[] pressedKey = Keyboard.GetState().GetPressedKeys();
            for (int i = 0; i < pressedKey.Length; i++)
            {
                _piano.StrikeKey(pressedKey[i].ToString().ToLower()[0]);
                for (int a = 0; a < 44100*gameTime.ElapsedGameTime.TotalSeconds; a++)
                {
                    Audio.Instance.Play(_piano.Play());
                }
                    // System.Console.WriteLine(pressedKey[i].ToString());
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                _piano.StrikeKey('q');
            }
            for (int i = 0; i < 44100*gameTime.ElapsedGameTime.TotalSeconds; i++)
            {
                Audio.Instance.Play(_piano.Play());
            }
            // char userKey = key.KeyChar;
            // _piano.StrikeKey(userKey);
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