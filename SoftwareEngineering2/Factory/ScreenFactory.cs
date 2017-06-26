using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineering2.Iterator;
using SoftwareEngineering2.InterfaceObjects;
using SoftwareEngineering2.Decorator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoftwareEngineering2.Factory
{
    class ScreenFactory : IScreenFactory
    {
        private GraphicsDeviceManager GraphicsDeviceManager;
        public ScreenFactory(GraphicsDeviceManager graphicsDeviceManager)
        {
            GraphicsDeviceManager = graphicsDeviceManager;
        }

        public IGuiElementCollection CreateHomeCollectionScreen()
        {
            List<IGuiElement> HomeGuiElements = new List<IGuiElement>()
            {
                new LabelDecorator(new MainGuiElement(new Vector2(300, 5)), "Main Screen", Color.White),

                new LabelDecorator(new ClickableDecorator(new MainGuiElement(new Vector2(300, 100)), Color.Black, Color.Yellow,
                    new Texture2D(GraphicsDeviceManager.GraphicsDevice, 150, 40), ScreenManager.InputWindow), "Input Screen", Color.White),

                new LabelDecorator(new ClickableDecorator(new MainGuiElement(new Vector2(300, 150)), Color.Black, Color.Yellow,
                    new Texture2D(GraphicsDeviceManager.GraphicsDevice, 150, 40), ScreenManager.LabelWindow), "Label Screen", Color.White),

                new LabelDecorator(new ClickableDecorator(new MainGuiElement(new Vector2(300, 250)), Color.Black, Color.Yellow,
                    new Texture2D(GraphicsDeviceManager.GraphicsDevice, 150, 40), ScreenManager.Exit), "Exit Screen", Color.White),
            };

            return new GuiElementCollection(HomeGuiElements);
        }

        public IGuiElementCollection CreateInputCollectionScreen()
        {
            List<IGuiElement> inputGuiElements = new List<IGuiElement>()
            {
                new LabelDecorator(new MainGuiElement(new Vector2(300,5)), "Input Screen", Color.Blue),

                new InputDecorator(new MainGuiElement(new Vector2(250, 90)), Color.White, Color.Black, new List<char>(), new Texture2D(GraphicsDeviceManager.GraphicsDevice, 500, 40)),

                new LabelDecorator(new ClickableDecorator(new MainGuiElement(new Vector2(100, 150)), Color.Black, Color.Blue,
                    new Texture2D(GraphicsDeviceManager.GraphicsDevice, 150, 40), ScreenManager.MainWindow), "Back", Color.White),
            };
            return new GuiElementCollection(inputGuiElements);
        }


        public IGuiElementCollection CreateLabelCollectionScreen()
        {
            List<IGuiElement> labelGuiElements = new List<IGuiElement>()
            {
                new LabelDecorator(new MainGuiElement(new Vector2(300,5)), "Label Screen", Color.Green),

                new LabelDecorator(new MainGuiElement(new Vector2(250, 50)), "This is a label", Color.Black),

                new LabelDecorator(new ClickableDecorator(new MainGuiElement(new Vector2(100, 150)), Color.Black, Color.Blue,
                    new Texture2D(GraphicsDeviceManager.GraphicsDevice, 150, 40), ScreenManager.MainWindow), "Back", Color.White),

            };

            return new GuiElementCollection(labelGuiElements);
        }
    }
    
}
