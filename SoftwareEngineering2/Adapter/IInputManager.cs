using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering2.Adapter
{
    interface IInputManager
    {
        KeyboardState GetKeyboardState();
        MouseState GetMouseState();
    }
}
