using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteRender
{
    public class Key
    {
        private bool _isWhite;
        private string _note;
        private Texture2D _texture;
        private Color _color;
        private Vector2 _position;

        public string Note 
        { 
            get => _note; 
            private set => _note = value; 
        }

        public Key(bool isWhite, Vector2 position)
        {
            _isWhite = isWhite;
            _color = Color.White;
            _position = position;
        }
        
        // When a key is pressed, change color of the key
        public void Press(){
            this._color = Color.Red;
        }
        public void UnPress(){
            this._color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _color);
        }


        public void LoadContent(ContentManager manager)
        {
            if (_isWhite)
            {
            _texture = manager.Load<Texture2D>("whiteKey");
            } else 
            {
            _texture = manager.Load<Texture2D>("blackKey");

            }
        }
        public override string ToString()
        {
            return $"{_color}";
        }
    }
}