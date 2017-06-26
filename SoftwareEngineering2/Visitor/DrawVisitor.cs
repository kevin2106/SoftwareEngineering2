using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoftwareEngineering2.InterfaceObjects;
using SoftwareEngineering2.Decorator;
using SoftwareEngineering2.Adapter;

namespace SoftwareEngineering2.Visitor
{
    class DrawVisitor : IVisitor
    {
        private IDrawingManager drawAdapter;
        public DrawVisitor(IDrawingManager adapter)
        {
            this.drawAdapter = adapter;
        }
        public void Visit(LabelDecorator label)
        {
            drawAdapter.Draw(label);
        }

        public void Visit(ClickableDecorator button)
        {
            drawAdapter.Draw(button);  
        }

        public void Visit(InputDecorator input)
        {
            drawAdapter.Draw(input);
        }
    }
}
