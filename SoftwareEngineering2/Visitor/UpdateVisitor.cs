using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftwareEngineering2.InterfaceObjects;

namespace SoftwareEngineering2.Visitor
{
    class UpdateVisitor : IVisitor
    {
        private readonly SpriteBatch _spriteBatch;
        public UpdateVisitor(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Visit(IGuiElement guiElement)
        {
            guiElement.Update();
        }
    }
}
