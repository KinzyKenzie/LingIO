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

        private List<Scene> children, deletionRequests;
        private Scene lastScene;

        public SceneManager( Game game ) {

            Game = game;

            InputHelper = new InputHelper();

            children = new List<Scene>();
            deletionRequests = new List<Scene>();

        }

        public void Update( GameTime gameTime ) {

            InputHelper.Update();

            if( ActiveScene.Initialized ) {

                ActiveScene.Update( gameTime );
                ProcessDeletionRequests();

            } else ActiveScene.Initialize();

        }

        public void Draw( GameTime gameTime ) {
            if( ActiveScene.Initialized ) ActiveScene.Draw( gameTime );
        }

        public bool RequestSceneChange( Type type ) {

            Scene request;

            if( type == typeof( Scenes.MenuMain ) ) {

                request = new Scenes.MenuMain( this );

                TransitionScene( request );

                return true;

            } else if( type == typeof( Scenes.MenuStub ) ) {

                request = new Scenes.MenuStub( this );

                TransitionScene( request );

                return true;
            }

            Console.WriteLine( "Failed to create new Scene. Request: \"" + type.ToString() + "\"." );
            return false;
        }

        public bool ReturnToLastScene() {

            if( lastScene == null ) {
                Console.WriteLine( "Failed to return to last scene because none was found!" );
                return false;
            }

            Scene toWipe = ActiveScene;

            ActiveScene = lastScene;
            lastScene = null;

            if( children.Contains( toWipe ) ) {

                deletionRequests.Add( toWipe );

            }

            return true;
        }

        private void TransitionScene( Scene destination ) {

            children.Add( destination );

            lastScene = ActiveScene;
            ActiveScene = destination;
        }

        private void ProcessDeletionRequests() {

            if( deletionRequests.Count < 1 ) return;

            int deleteAtIndex = -1;
            bool[] processed = new bool[deletionRequests.Count];

            for( int i = 0; i < deletionRequests.Count; i++ ) {

                deleteAtIndex = children.IndexOf( deletionRequests[i] );

                if( deleteAtIndex >= 0 ) {

                    children.RemoveAt( deleteAtIndex );
                    processed[i] = true;

                } else processed[i] = false;

            }

            for( int i = 0; i < processed.Length; i++ )
                if( processed[i] ) deletionRequests.RemoveAt( i );

            if( deletionRequests.Count > 0 )
                Console.WriteLine( "Not all scene deletion requests were able to be processed! (" + deletionRequests.Count + " remain(s))" );

        }
    }
}
