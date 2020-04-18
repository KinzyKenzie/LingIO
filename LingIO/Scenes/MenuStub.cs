using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LingIO.Framework;

namespace LingIO.Scenes
{
    class MenuStub : Scene
    {
        SpriteFont fontSmall;

        public MenuStub( SceneManager manager ) : base( manager ) {
            menuWrapping = false;
            selectedOption = 0;
        }

        public override void Initialize() {

            fontSmall = Manager.Game.Content.Load<SpriteFont>( "Std12" );

            textBatch.Add( new TextDraw( fontSmall, "Well this place sure is empty, huh.", new Vector2( WindowWidth * 0.5f, WindowHeight * 0.4f ), Color.White ) );
            options.Add( new TextDraw( fontSmall, "Return", new Vector2( WindowWidth * 0.5f, WindowHeight * 0.7f ), Color.White ) );

            base.Initialize();
        }

        public override void UnloadContent() {

            //Todo: Figure out whether this is safe to do or not
            Manager.Game.Content.Unload();

            base.UnloadContent();
        }

        public override void Update( GameTime gameTime ) {

            if( Manager.InputHelper.IsKeyPressed( Keys.Enter ) )
                InteractMenu();

            base.Update( gameTime );
        }

        public override void Draw( GameTime gameTime ) {

            spriteBatch.Begin();

            foreach( TextDraw td in textBatch )
                td.Draw( spriteBatch );

            for( int i = 0; i < options.Count; i++ ) {
                if( i == selectedOption )
                    options[i].DrawOffcolour( spriteBatch, Color.Red );
                else
                    options[i].Draw( spriteBatch );
            }

            spriteBatch.End();

            base.Draw( gameTime );
        }

        private void InteractMenu() {
            Manager.ReturnToLastScene();
        }
    }
}
