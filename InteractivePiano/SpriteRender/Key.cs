using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteRender
{
    /// <summary>
    /// Holds the information for creating a single key sprite
    /// </summary>
    public class Key
    {
        private bool _isWhite;
        private string _note;
        private bool _isPressed;
        private Texture2D _texture;
        private Color _color;
        private Vector2 _position;
        private SpriteFont _noteTexture;

        public string Note 
        { 
            get => _note; 
            private set => _note = value; 
        }

        public Key(bool isWhite, Vector2 position, string note)
        {
            _isWhite = isWhite;
            _color = Color.White;
            _position = position;
            _note = note;
            _isPressed = false;
        }
        
        /// <summary>
        /// When a key is pressed, change color of the key
        /// </summary>
        public void Press(){
            this._color = Color.Red;
            this._isPressed = true;
        }
        /// <summary>
        /// When a key is released, change color of the key
        /// </summary>
        public void UnPress(){
            this._color = Color.White;
            this._isPressed = false;
        }
        /// <summary>
        /// Draws the key and draws the Note name only if the key is pressed
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _color);
            if(_isPressed)
            {
                spriteBatch.DrawString(_noteTexture, _note, new Vector2(_position.X, 100), Color.DarkBlue);
            }
        }

        /// <summary>
        /// Preloads the textures and spritefont
        /// </summary>
        /// <param name="manager"></param>
        public void LoadContent(ContentManager manager)
        {
            if (_isWhite)
            {
            _texture = manager.Load<Texture2D>("whiteKey");
            } else 
            {
            _texture = manager.Load<Texture2D>("blackKey");
            }
            _noteTexture = manager.Load<SpriteFont>("KeyNote"); 

        }
    }
}