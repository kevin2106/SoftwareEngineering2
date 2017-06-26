using SoftwareEngineering2.InterfaceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SoftwareEngineering2.Visitor;
using SoftwareEngineering2.Adapter;
using Microsoft.Xna.Framework;

namespace SoftwareEngineering2.Decorator
{
    abstract class GuiElementDecorator : IGuiElement
    {
        protected IGuiElement GuiElement { get; set; }

        public GuiElementDecorator(IGuiElement element)
        {
            GuiElement = element;
        }

        public virtual void Accept(IVisitor visitor)
        {
            GuiElement.Accept(visitor);
        }

        public virtual Vector2 GetPosition()
        {
            return GuiElement.GetPosition();
        }
    }
}
