using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InteractivePiano
{
    public class Key : DrawableGameComponent
    {
        private Game _game;
        private SpriteBatch _spriteBatch;
        private Texture2D _whiteKeyImage;
        private Texture2D _blackKeyImage;
        public Key(Game game) : base(game)
        {
            _game = game;
        }
        
        // When a key is pressed, change color of the key
        public void Press(){

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
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