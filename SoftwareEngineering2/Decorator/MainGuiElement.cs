using SoftwareEngineering2.InterfaceObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SoftwareEngineering2.Visitor;

namespace SoftwareEngineering2.Decorator
{
    class MainGuiElement : IGuiElement
    {
        public Vector2 Position { get; set; }

        public MainGuiElement(Vector2 position)
        {
            Position = position;
        }

        public void Accept(IVisitor visitor)
        {
            //not needed
        }

        public Vector2 GetPosition()
        {
            return Position;
        }
    }
}
