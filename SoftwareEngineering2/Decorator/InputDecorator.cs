using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.InterfaceObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoftwareEngineering2.Adapter;
using SoftwareEngineering2.Visitor;

namespace SoftwareEngineering2.Decorator
{
    class InputDecorator : GuiElementDecorator
    {
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Vector2 Position { get; set; }
        public List<char> Text { get; set; }
        public Texture2D Texture { get; set; }
        public int Cursor { get; set; }


        public InputDecorator(IGuiElement element, Color bgColor, Color textColor, List<char> textContent, Texture2D texture) : base(element)
        {
            BackgroundColor = bgColor;
            TextColor = textColor;
            Text = textContent;
            Texture = texture;
        }
        public override void Accept(IVisitor visitor)
        {
            GuiElement.Accept(visitor);
            visitor.Visit(this);
        }
    }
}
