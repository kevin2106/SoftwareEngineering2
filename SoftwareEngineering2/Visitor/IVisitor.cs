using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.InterfaceObjects;
using SoftwareEngineering2.Decorator;

namespace SoftwareEngineering2.Visitor
{
    interface IVisitor
    {
        void Visit(LabelDecorator label);
        void Visit(ClickableDecorator button);
        void Visit(InputDecorator input);
    }
}
