using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftwareEngineering2.InterfaceObjects;
using SoftwareEngineering2.Adapter;
using SoftwareEngineering2.Decorator;

namespace SoftwareEngineering2.Visitor
{
    class UpdateVisitor : IVisitor
    {
        private IDrawingManager adapter;
        public UpdateVisitor(IDrawingManager adapter)
        {
            this.adapter = adapter;
        }

        public void Visit(LabelDecorator label)
        {
        }

        public void Visit(ClickableDecorator button)
        {
            adapter.Update(button);
        }

        public void Visit(InputDecorator input)
        {
            adapter.Update(input);
        }
    }
}
