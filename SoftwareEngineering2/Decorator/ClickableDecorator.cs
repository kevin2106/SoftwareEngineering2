using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.InterfaceObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SoftwareEngineering2.Visitor;

namespace SoftwareEngineering2.Decorator
{
    class ClickableDecorator : GuiElementDecorator
    {

        public Color BackgroundColor { get; set; }
        public Color HoverBackgroundColor { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public ScreenManager GoToWindow { get; set; }

        public ClickableDecorator(IGuiElement element, Color bgColor, Color hoverBgColor, Texture2D texture, ScreenManager goToWindow) : base(element)
        {
            BackgroundColor = bgColor;
            HoverBackgroundColor = hoverBgColor;
            Texture = texture;
            GoToWindow = goToWindow;
        }

        public override void Accept(IVisitor visitor)
        {
            GuiElement.Accept(visitor);
            visitor.Visit(this);
        }

    }
}
