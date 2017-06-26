using SoftwareEngineering2.Decorator;
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
        void Draw(ClickableDecorator button);
        void Draw(LabelDecorator label);
        void Draw(InputDecorator textField);
        void Update(ClickableDecorator button);
        void Update(InputDecorator inputField);
    }
}
