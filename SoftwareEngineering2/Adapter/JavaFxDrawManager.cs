using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.Decorator;

namespace SoftwareEngineering2.Adapter
{
    class JavaFxDrawManager : IDrawingManager
    {
        public void Draw(InputDecorator textField)
        {
            throw new NotImplementedException();
        }

        public void Draw(LabelDecorator label)
        {
            throw new NotImplementedException();
        }

        public void Draw(ClickableDecorator button)
        {
            throw new NotImplementedException();
        }

        public void Update(InputDecorator inputField)
        {
            throw new NotImplementedException();
        }

        public void Update(ClickableDecorator button)
        {
            throw new NotImplementedException();
        }
    }
}
