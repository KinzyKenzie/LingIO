using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LingIO.Framework
{
    class Scene
    {
        protected int WindowWidth { get { return Manager.Game.Window.ClientBounds.Width; } }
        protected int WindowHeight { get { return Manager.Game.Window.ClientBounds.Height; } }

        public bool Initialized { get; private set; }

        public SceneManager Manager { get; }

        protected SpriteBatch spriteBatch;

        //Todo: Move to separate class; LingIO\Framework\Menu.cs
        protected List<TextDraw> textBatch, options;

        protected bool menuWrapping;
        protected int selectedOption;

        public Scene( SceneManager manager ) {

            Initialized = false;
            Manager = manager;

            spriteBatch = new SpriteBatch( Manager.Game.GraphicsDevice );
            textBatch = new List<TextDraw>();
            options = new List<TextDraw>();
        }

        public virtual void Initialize() {
            Initialized = true;
        }

        public virtual void UnloadContent() { }
        public virtual void Update( GameTime gameTime ) { }
        public virtual void Draw( GameTime gameTime ) { }
    }
}
