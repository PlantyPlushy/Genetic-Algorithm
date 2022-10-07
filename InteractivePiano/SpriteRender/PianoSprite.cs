using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PianoSimulator;
using Backend;
using InteractivePiano;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Threading.Tasks;

namespace SpriteRender
{
    class PianoSprite : DrawableGameComponent
    {
        private Game _game;
        private string _availableKeys;
        private Key[] _keys;
        private Piano _piano;
        private SpriteBatch _spriteBatch;
        private Keys[] beforeKeys;

        public PianoSprite(Game game, string availableKeys) : base(game)
        {
            this._game = game;
            if (availableKeys == "")
            {
                _piano = new Piano();
                _availableKeys = _piano.Keys;
            } else {
                _piano = new Piano(_availableKeys);
                _availableKeys = availableKeys;
            }
            beforeKeys = new Keys[0];
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
            Keys[] currentKeys = Keyboard.GetState().GetPressedKeys();

            foreach (var pressed in currentKeys.Except(beforeKeys))
            {
                char pressedKeyChar = pressed.ToString().ToLower()[0];
                int indexOfLetter = _availableKeys.IndexOf(pressedKeyChar);
                System.Console.WriteLine(pressed);
                try
                {
                    _piano.StrikeKey(pressedKeyChar);
	
	                _keys[indexOfLetter].Press();
	
                }
                catch (System.Exception)
                {
                    // Do nothing
                }
            }

            foreach (var released in beforeKeys.Except(currentKeys))
            {
                char releasedKeyChar = released.ToString().ToLower()[0];
                int indexOfLetter = _availableKeys.IndexOf(releasedKeyChar);
                try
                {
                _keys[indexOfLetter].UnPress();
                }
                catch (System.Exception)
                {
                    // Do nothing
                }
            }
            beforeKeys = currentKeys;

            Task.Run(() => {
                for (int a = 0; a < 44100*gameTime.ElapsedGameTime.TotalSeconds; a++)
                {
                    Audio.Instance.Play(_piano.Play());
                }    
            });

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