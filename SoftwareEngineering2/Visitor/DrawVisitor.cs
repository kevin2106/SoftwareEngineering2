using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoftwareEngineering2.InterfaceObjects;

namespace SoftwareEngineering2.Visitor
{
    class DrawVisitor : IVisitor
    {
        private readonly SpriteBatch _spriteBatch;
        public DrawVisitor(SpriteBatch spriteBatch)
        {
            //need something like spritebatch/screenmanager or something so i can start drawing
            _spriteBatch = spriteBatch;
        }
        public void Visit(IGuiElement guiElement)
        {
            guiElement.Draw(_spriteBatch);
        }
    }
}
