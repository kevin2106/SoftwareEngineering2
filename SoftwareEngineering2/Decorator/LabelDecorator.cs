using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.InterfaceObjects;
using Microsoft.Xna.Framework;
using SoftwareEngineering2.Visitor;

namespace SoftwareEngineering2.Decorator
{
    class LabelDecorator : GuiElementDecorator
    {
        public string LabelText { get; set; }
        public Color TextColor { get; set; }

        public LabelDecorator(IGuiElement element, string labelText, Color textColor) : base(element)
        {
            LabelText = labelText;
            TextColor = textColor;
        }

        public override void Accept(IVisitor visitor)
        {
            GuiElement.Accept(visitor);
            visitor.Visit(this);
        }
    }
}
