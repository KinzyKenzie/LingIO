using System;
using Microsoft.Xna.Framework.Input;

namespace LingIO.Framework
{
    class InputHelper
    {
        KeyboardState kbs;

        private int keyboardSize;
        private bool[] keyPressed;
        private bool[] oldKeyPressed;

        public InputHelper() {

            keyboardSize = Enum.GetNames( typeof( Keys ) ).Length;
            keyPressed = new bool[keyboardSize];
            oldKeyPressed = new bool[keyboardSize];
        }

        public void Update() {

            kbs = Keyboard.GetState();

            for( int i = 0; i < keyboardSize; i++ ) {

                oldKeyPressed[i] = keyPressed[i];
                keyPressed[i] = kbs.IsKeyDown( (Keys) i );
            }
        }

        public bool IsKeyReleased( Keys key ) { return !keyPressed[(int) key] && oldKeyPressed[(int) key]; }
        public bool IsKeyPressed( Keys key ) { return keyPressed[(int) key] && !oldKeyPressed[(int) key]; }
        public bool IsKeyDown( Keys key ) { return keyPressed[(int) key]; }
        public bool IsKeyUp( Keys key ) { return !keyPressed[(int) key]; }
    }
}
