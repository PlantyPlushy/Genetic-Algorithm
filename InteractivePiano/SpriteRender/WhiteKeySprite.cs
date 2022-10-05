using System;
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

        public WhiteKeySprite(Game game) : base(game)
        {
            this._game = game;
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
            _whiteKeyImage = _game.Content.Load<Texture2D>("whiteKey");
            base.LoadContent();
        }
    }
}