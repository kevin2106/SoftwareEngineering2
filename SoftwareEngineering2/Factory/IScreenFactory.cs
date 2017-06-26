using SoftwareEngineering2.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering2.Factory
{
    interface IScreenFactory
    {
        IGuiElementCollection CreateHomeCollectionScreen();
        IGuiElementCollection CreateInputCollectionScreen();
        IGuiElementCollection CreateLabelCollectionScreen();
    }
}
