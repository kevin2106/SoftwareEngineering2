using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.InterfaceObjects;
using Microsoft.Xna.Framework.Graphics;
using SoftwareEngineering2.Decorator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SoftwareEngineering2.Adapter
{
    class MonoGameDrawManager : IDrawingManager
    {
        private SpriteBatch spriteBatch;
        public MonoGameDrawManager(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }
        public void Draw(ClickableDecorator button)
        {
            spriteBatch.Begin();
            Color[] colorData = new Color[button.Texture.Width * button.Texture.Height];

            for (int i = 0; i < button.Texture.Height * button.Texture.Width; i++)
            {
                colorData[i] = button.BackgroundColor;
            }

            button.Texture.SetData(colorData);
            spriteBatch.Draw(button.Texture, new Rectangle((int)button.GetPosition().X, (int)button.GetPosition().Y, (int)button.Texture.Width, (int)button.Texture.Height), button.BackgroundColor);
            spriteBatch.End();
        }

        public void Draw(LabelDecorator label)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Game1.Font, label.LabelText, label.GetPosition(), label.TextColor);
            spriteBatch.End();
        }

        public void Draw(InputDecorator input)
        {
            spriteBatch.Begin();
            Color[] colorData = new Color[input.Texture.Width * input.Texture.Height];

            for (int i = 0; i < input.Texture.Height * input.Texture.Width; i++)
            {
                colorData[i] = input.BackgroundColor;
            }

            input.Texture.SetData(colorData);
            spriteBatch.Draw(input.Texture, new Rectangle((int)input.GetPosition().X, (int)input.GetPosition().Y, (int)input.Texture.Width, (int)input.Texture.Height), input.BackgroundColor);
            spriteBatch.DrawString(Game1.Font, CharsToString(input.Text), input.GetPosition(), input.TextColor);
            spriteBatch.End();
        }

        public void Update(InputDecorator inputField)
        {
            IInputManager input = new InputManager();

            if (input.GetKeyboardState().GetPressedKeys().Length == 0)
                return;

            var keyPressed = input.GetKeyboardState().GetPressedKeys()[0];
            switch(keyPressed)
            {
                case Keys.Space:
                    inputField.Text.Insert(inputField.Cursor, ' ');
                    break;
                case Keys.Back:
                    if (inputField.Text.Count == 0)
                        break;
                    inputField.Text.RemoveAt(inputField.Cursor - 1);
                    inputField.Cursor--;
                    break;
                default:
                    inputField.Text.Insert(inputField.Cursor, Convert.ToChar(keyPressed.ToString()));
                    inputField.Cursor++;
                    break;
            }
        }

        public void Update(ClickableDecorator button)
        {
            IInputManager input = new InputManager();
            if (!(input.GetMouseState().Position.X < (button.GetPosition().X + button.Texture.Width)) ||
                !(input.GetMouseState().Position.X > button.GetPosition().X) || 
                !(input.GetMouseState().Position.Y < (button.GetPosition().Y + button.Texture.Height)) ||
                !(input.GetMouseState().Position.Y > button.GetPosition().Y))
            {
                button.BackgroundColor = Color.Black;
                return;
            }

            button.BackgroundColor = button.HoverBackgroundColor;
            if (input.GetMouseState().LeftButton == ButtonState.Pressed)
            {
                Game1.CurrentScreen = button.GoToWindow;
            }
        }

        private string CharsToString(List<char> text)
        {
            string output = "";
            foreach (char item in text)
            {
                output += item;
            }
            return output;
        }
    }
}
