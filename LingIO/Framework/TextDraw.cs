using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LingIO.Framework
{
    class TextDraw
    {
        private SpriteFont font;
        private String text;
        private Vector2 position;
        private Color color;

        public TextDraw( SpriteFont font, String text, Vector2 position, Color color ) {

            this.font = font;
            this.text = text;

            Vector2 offset = font.MeasureString( text );
            this.position = position - ( offset / 2 );
            this.position.X = (int) Math.Round( this.position.X );
            this.position.Y = (int) Math.Round( this.position.Y );

            this.color = color;
        }

        public void Draw( SpriteBatch sb ) {
            sb.DrawString( font, text, position, color );
        }

        public void DrawOffcolour( SpriteBatch sb, Color col ) {
            sb.DrawString( font, text, position, col );
        }
    }
}
