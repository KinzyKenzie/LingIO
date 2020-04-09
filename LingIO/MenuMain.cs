using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LingIO.Framework;

namespace LingIO
{
    class MenuMain : Scene
    {
        int WindowWidth { get { return Manager.Game.Window.ClientBounds.Width; } }
        int WindowHeight { get { return Manager.Game.Window.ClientBounds.Height; } }

        SpriteFont fontSmall, fontLarge;

        List<TextDraw> textBatch, options;
        bool menuWrapping = true;
        int selectedOption = 0;

        public MenuMain( SceneManager manager ) : base( manager ) {

            textBatch = new List<TextDraw>();
            options = new List<TextDraw>();
        }

        public override void Initialize() {

            fontSmall = Manager.Game.Content.Load<SpriteFont>( "Std12" );
            fontLarge = Manager.Game.Content.Load<SpriteFont>( "Std42" );

            textBatch.Add( new TextDraw( fontSmall, "Welcome to", new Vector2( WindowWidth * 0.428f, WindowHeight * 0.125f ), Color.White ) );
            textBatch.Add( new TextDraw( fontLarge, "Ling.IO", new Vector2( WindowWidth * 0.5f, WindowHeight * 0.2125f ), Color.White ) );

            textBatch.Add( new TextDraw( fontSmall, "An English Game using a Dutch dictionary because I hate you",
                                         new Vector2( WindowWidth * 0.5f, WindowHeight * 0.4f ), Color.White ) );

            //Todo: Add actual menuing functionality. Another class?
            options.Add( new TextDraw( fontSmall, "New Game", new Vector2( WindowWidth * 0.5f, WindowHeight * 0.575f ), Color.White ) );
            options.Add( new TextDraw( fontSmall, "Options", new Vector2( WindowWidth * 0.5f, WindowHeight * 0.7f ), Color.White ) );
            options.Add( new TextDraw( fontSmall, "Quit Game", new Vector2( WindowWidth * 0.5f, WindowHeight * 0.825f ), Color.White ) );

            base.Initialize();
        }

        public override void Update( GameTime gameTime ) {

            if( Manager.InputHelper.IsKeyPressed( Keys.W ) || Manager.InputHelper.IsKeyPressed( Keys.Up ) ) {

                selectedOption -= 1;

                if( selectedOption < 0 ) {

                    if( menuWrapping ) selectedOption = options.Count - 1;
                    else selectedOption = 0;
                }
            }

            if( Manager.InputHelper.IsKeyPressed( Keys.S ) || Manager.InputHelper.IsKeyPressed( Keys.Down ) ) {

                selectedOption += 1;

                if( selectedOption >= options.Count ) {

                    if( menuWrapping ) selectedOption = 0;
                    else selectedOption -= 1;
                }
            }

            base.Update( gameTime );
        }

        public override void Draw( GameTime gameTime ) {

            spriteBatch.Begin();

            foreach( TextDraw td in textBatch ) {
                td.Draw( spriteBatch );
            }

            for( int i = 0; i < options.Count; i++ ) {

                if( i == selectedOption )
                    options[i].DrawOffcolour( spriteBatch, Color.Red );
                else
                    options[i].Draw( spriteBatch );
            }

            spriteBatch.End();

            base.Draw( gameTime );
        }
    }
}
