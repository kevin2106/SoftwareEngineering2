using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SoftwareEngineering2.Visitor;
using Microsoft.Xna.Framework.Graphics;

namespace SoftwareEngineering2.InterfaceObjects
{
    class Label : IGuiElement
    {
        public string LabelText { get; set; }
        public Vector2 Position { get; set; }
        public Color TextColor { get; set; }

        public Label(string labelText, Vector2 position, Color textColor )  
        {
            LabelText = labelText;
            Position = position;
            TextColor = textColor;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Game1.Font, LabelText, Position, TextColor);
            spriteBatch.End();
        }

        public void Update()
        {

        }
    }
}
