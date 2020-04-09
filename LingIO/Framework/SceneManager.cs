using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LingIO.Framework
{
    class SceneManager
    {
        public Game Game { get; private set; }
        public InputHelper InputHelper { get; private set; }
        public Scene ActiveScene { get; private set; }

        private List<Scene> children;

        public SceneManager( Game game ) {

            Game = game;

            InputHelper = new InputHelper();
            children = new List<Scene>();
        }

        public void Update( GameTime gameTime ) {

            InputHelper.Update();

            if( ActiveScene.Initialized ) ActiveScene.Update( gameTime );
            else ActiveScene.Initialize();
        }

        public void Draw( GameTime gameTime ) {
            if( ActiveScene.Initialized ) ActiveScene.Draw( gameTime );
        }

        // public void Add( Scene scene ) {
        // 
        //     children.Add( scene );
        //     if( children.Count == 1 ) { ActiveScene = scene; }
        // }

        public bool RequestSceneChange( Type type ) {

            Scene request;

            if( type == typeof( MenuMain ) ) {

                request = new MenuMain( this );

                children.Add( request );
                ActiveScene = request;

                return true;
            }

            Console.WriteLine( "Failed to create new Scene. Request: \"" + type.ToString() + "\"." );
            return false;
        }
    }
}
