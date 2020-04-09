using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LingIO.Framework;

namespace LingIO
{
    public class LingIO : Game
    {
        GraphicsDeviceManager graphics;
        SceneManager sceneManager;

        SpriteBatch spriteBatch;

        Texture2D pixel;

        public LingIO() {
            graphics = new GraphicsDeviceManager( this );
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {

            sceneManager = new SceneManager( this );
            sceneManager.RequestSceneChange( typeof( MenuMain ) );

            base.Initialize();
        }

        protected override void LoadContent() {

            spriteBatch = new SpriteBatch( GraphicsDevice );
            pixel = Content.Load<Texture2D>( "Pixel" );
        }

        protected override void UnloadContent() { }

        protected override void Update( GameTime gameTime ) {

            sceneManager.Update( gameTime );

            base.Update( gameTime );
        }

        protected override void Draw( GameTime gameTime ) {

            GraphicsDevice.Clear( Color.Black );

            // DrawHelperLines( spriteBatch );
            sceneManager.Draw( gameTime );

            base.Draw( gameTime );
        }

        private void DrawHelperLines( SpriteBatch spriteBatch ) {

            spriteBatch.Begin();

            spriteBatch.Draw( pixel, new Rectangle( (int) ( graphics.PreferredBackBufferWidth * 0.2f ), 0, 1, graphics.PreferredBackBufferHeight ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( (int) ( graphics.PreferredBackBufferWidth * 0.4f ), 0, 1, graphics.PreferredBackBufferHeight ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( (int) ( graphics.PreferredBackBufferWidth * 0.5f ), 0, 1, graphics.PreferredBackBufferHeight ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( (int) ( graphics.PreferredBackBufferWidth * 0.6f ), 0, 1, graphics.PreferredBackBufferHeight ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( (int) ( graphics.PreferredBackBufferWidth * 0.8f ), 0, 1, graphics.PreferredBackBufferHeight ), Color.White );

            spriteBatch.Draw( pixel, new Rectangle( 0, (int) ( graphics.PreferredBackBufferHeight * 0.2f ), graphics.PreferredBackBufferWidth, 1 ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( 0, (int) ( graphics.PreferredBackBufferHeight * 0.4f ), graphics.PreferredBackBufferWidth, 1 ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( 0, (int) ( graphics.PreferredBackBufferHeight * 0.5f ), graphics.PreferredBackBufferWidth, 1 ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( 0, (int) ( graphics.PreferredBackBufferHeight * 0.6f ), graphics.PreferredBackBufferWidth, 1 ), Color.White );
            spriteBatch.Draw( pixel, new Rectangle( 0, (int) ( graphics.PreferredBackBufferHeight * 0.8f ), graphics.PreferredBackBufferWidth, 1 ), Color.White );

            spriteBatch.End();
        }
    }
}
