using SoftwareEngineering2.InterfaceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering2.Adapter
{
    interface IDrawingManager
    {
        void Draw(Button button);
        void Draw(Label label);
        void Draw(TextField textField);
    }
}
