using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LingIO.Framework
{
    class Scene
    {
        public bool Initialized { get; private set; }

        public SceneManager Manager { get; }

        protected SpriteBatch spriteBatch;

        public Scene( SceneManager manager ) {
            Initialized = false;
            Manager = manager;

            spriteBatch = new SpriteBatch( Manager.Game.GraphicsDevice );
        }

        public virtual void Initialize() {
            Initialized = true;
        }

        public virtual void Update( GameTime gameTime ) { }
        public virtual void Draw( GameTime gameTime ) { }
    }
}
