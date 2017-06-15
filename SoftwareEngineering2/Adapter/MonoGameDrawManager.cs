using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.InterfaceObjects;
using Microsoft.Xna.Framework.Graphics;

namespace SoftwareEngineering2.Adapter
{
    class MonoGameDrawManager : IDrawingManager
    {
        private SpriteBatch spriteBatch;
        public MonoGameDrawManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }
        public void Draw(Button button)
        {
            spriteBatch.Begin();
            spriteBatch.
        }

        public void Draw(Label label)
        {
            throw new NotImplementedException();
        }

        public void Draw(TextField textField)
        {
            throw new NotImplementedException();
        }
    }
}
