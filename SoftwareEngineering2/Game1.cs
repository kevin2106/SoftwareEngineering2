using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftwareEngineering2.Visitor;
using SoftwareEngineering2.InterfaceObjects;
using SoftwareEngineering2.Iterator;

namespace SoftwareEngineering2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private IVisitor _drawVisitor;
        private IVisitor _updateVisitor;

        private IGuiElementCollection collection;

        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public static SpriteFont Font;

        public static ScreenManager CurrentScreen;

        private List<IGuiElement> mainWindowElements, labelWindowElements, inputWindowElements;

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            CurrentScreen = ScreenManager.MainWindow;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("font");
            
            // TODO: use this.Content to load your game content here
            _drawVisitor = new DrawVisitor(_spriteBatch);
            _updateVisitor = new UpdateVisitor(_spriteBatch);

            //MainWindow
            mainWindowElements = new List<IGuiElement>()
            {
                new Label("MainWindow", new Vector2(5, 5), Color.Black),
                new Button(Color.Black, Color.White, new Vector2(250, 50), "Input window",
                    new Texture2D(_graphics.GraphicsDevice, 150, 40), ScreenManager.InputWindow),
                new Button(Color.Black, Color.White, new Vector2(250, 100), "Label window",
                    new Texture2D(_graphics.GraphicsDevice, 150, 40), ScreenManager.LabelWindow),
                new Button(Color.Black, Color.White, new Vector2(250, 150), "Exit",
                    new Texture2D(_graphics.GraphicsDevice, 150, 40), ScreenManager.Exit)
            };

            labelWindowElements = new List<IGuiElement>()
            {
                new Label("LabelWindow", new Vector2(5, 5), Color.Black),
                new Label("I am a label", new Vector2(250, 50), Color.Black),
                new Button(Color.Black, Color.White, new Vector2(250, 150), "Back",
                    new Texture2D(_graphics.GraphicsDevice, 150, 40), ScreenManager.MainWindow)
            };

            inputWindowElements = new List<IGuiElement>()
            {
                new Label("InputWindow", new Vector2(5, 5), Color.Black),
                new TextField(Color.White, Color.Black, new Vector2(250, 90), new List<char>(), new Texture2D(_graphics.GraphicsDevice, 150, 40)),
                new Button(Color.Black, Color.White, new Vector2(250, 150), "Back",
                    new Texture2D(_graphics.GraphicsDevice, 150, 40), ScreenManager.MainWindow)
            };

            collection = new GuiElementCollection(mainWindowElements);
            //_collection.AddGuiElement(new Label("I am a label", new Vector2(50, 35), Color.Black));
            //_collection.AddGuiElement(new TextField(Color.White, Color.Black, new Vector2(50, 90), new List<char>(), new Texture2D(_graphics.GraphicsDevice, 75, 20)));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            IIterator iterator = collection.Iterator();
            while (iterator.HasNext())
            {
                _updateVisitor.Visit(iterator.Next());
            }

            // TODO: Add your update logic here
            switch (CurrentScreen)
            {
                case ScreenManager.MainWindow:
                    UpdateMainWindow(gameTime);
                    break;
                case ScreenManager.InputWindow:
                    UpdateInputWindow(gameTime);
                    break;
                case ScreenManager.LabelWindow:
                    UpdateLabelWindow(gameTime);
                    break;
                case ScreenManager.Exit:
                    //Exit();
                    break;

            }
            

            base.Update(gameTime);
        }

        void UpdateMainWindow(GameTime gameTime)
        {
            collection = new GuiElementCollection(mainWindowElements);
        }

        void UpdateLabelWindow(GameTime gameTime)
        {
            collection = new GuiElementCollection(labelWindowElements);
        }

        void UpdateInputWindow(GameTime gameTime)
        {
            collection = new GuiElementCollection(inputWindowElements);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            IIterator iterator = collection.Iterator();
            while (iterator.HasNext())
            {
                _drawVisitor.Visit(iterator.Next());
            }
            
            base.Draw(gameTime);
        }
    }
}
