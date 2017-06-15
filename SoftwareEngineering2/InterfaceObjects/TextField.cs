using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoftwareEngineering2.Visitor;
using Microsoft.Xna.Framework.Input;

namespace SoftwareEngineering2.InterfaceObjects
{
    class TextField : IGuiElement
    {
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Vector2 Position { get; set; }
        public List<char> Text { get; set; }
        public Texture2D Texture { get; set; }
        public int Cursor { get; set; }

        public TextField(Color backgroundColor, Color textColor, Vector2 position, List<char> text, Texture2D texture )
        {
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            Position = position;
            Text = text;
            Texture = texture;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draw the textfield
            spriteBatch.Begin();

            //draw the box
            //fill in the pixels of the texture2D
            Color[] colorData = new Color[Texture.Width * Texture.Height];

            for (int i = 0; i < Texture.Height * Texture.Width; i++)
            {
                colorData[i] = BackgroundColor;
            }

            Texture.SetData(colorData);

            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Texture.Width, (int)Texture.Height), BackgroundColor);

            //draw the text + cursor

            string text = "";
            for (int i = 0; i < Text.Count; i++)
            {
                //check if cursor is on this place
                if (Cursor == i)
                {
                    text += "|";
                }
                text += Text[i];
            }

            spriteBatch.DrawString(Game1.Font, text, Position, TextColor);

            spriteBatch.End();
        }

        public void Update()
        {
            if (Keyboard.GetState().GetPressedKeys().Length == 0)
                return;

            var key = Keyboard.GetState().GetPressedKeys()[0];
            switch (key)
            {
                case Keys.Space:
                    Text.Insert(Cursor, ' ');
                    Cursor++;
                    break;
                case Keys.Back:
                    if (Text.Count == 0)
                        break;
                    Text.RemoveAt(Cursor - 1);
                    Cursor--;
                    break;
                default:
                    //add to list where cursor is
                    //increment cursor
                    try
                    {
                        Text.Insert(Cursor, Convert.ToChar(key.ToString()));
                        Cursor++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    break;
            }
        }
    }
}
