using System;
using System.Text.RegularExpressions;
using InteractivePiano;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PianoSimulator;

namespace SpriteRender
{
    class WhiteKeySprite : DrawableGameComponent
    {
        private Game _game;
        private Piano _piano;
        private Texture2D _whiteKeyImage;
        private Texture2D _blackKeyImage;
        private SpriteBatch _spriteBatch;

        public WhiteKeySprite(Game game) : base(game)
        {
            this._game = game;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(sortMode: SpriteSortMode.Texture);
            int xPosition = 0;   
            int imageWidth = _whiteKeyImage.Width;
            string keys = _piano.Keys;
            string sequence = "wbwwbwbwwbwb";
            for (int i = 0; i < keys.Length; i++)
            {
                // if the current char is numeric i.e. is a black key
                if (!Regex.IsMatch(keys[i].ToString(), @"^\d+$"))
                {
                    _spriteBatch.Draw(_whiteKeyImage, new Vector2(xPosition,0), Color.White);  
                    xPosition+= imageWidth + 5;  
                    // creates a gap for the next key to be placed on
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
            _piano = new Piano("q2we4r5ty7u8i9op");
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