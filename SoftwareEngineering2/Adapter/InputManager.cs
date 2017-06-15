using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace SoftwareEngineering2.Adapter
{
    class InputManager : IInputManager
    {
        public KeyboardState GetKeyboardState()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            return keyboardState;
        }

        public MouseState GetMouseState()
        {
            MouseState mouseState = Mouse.GetState();
            return mouseState;
        }
    }
}
