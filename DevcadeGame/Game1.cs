using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using tainicom.Aether.Physics2D.Dynamics;

namespace DevcadeGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D MetalBarTexture { get; set; }
        public static Tuple<int, int> Coordinates = Tuple.Create(420, 980); // width, height
        public MetalBar MetalBar { get; set; }
        public Ball Ball { get; set; }
        public World World { get; set; }

        /// <summary>
        /// Game constructor
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        /// <summary>
        /// Does any setup prior to the first frame that doesn't need loaded content.
        /// </summary>
        protected override void Initialize()
        {
            Input.Initialize(); // Sets up the input library

            World = new World();
            World.Gravity = new Vector2(0, 40f);

            var top = 0;
            var bottom = Coordinates.Item2;
            var left = 0;
            var right = Coordinates.Item1;
            var edges = new Body[] {
                World.CreateEdge(new Vector2(left, top), new Vector2(right, top)),
                World.CreateEdge(new Vector2(left, top), new Vector2(left, bottom)),
                World.CreateEdge(new Vector2(left, bottom), new Vector2(right, bottom)),
                World.CreateEdge(new Vector2(right, top), new Vector2(right, bottom)),
            };

            foreach (var edge in edges)
            {
                edge.BodyType = BodyType.Static;
                edge.SetRestitution(1);
            }

            var radius = 25;
            var position = new Vector2(Coordinates.Item1 / 2, Coordinates.Item2 / 2);
            var body = World.CreateCircle(radius, 1, position, BodyType.Dynamic);
            body.SetRestitution(0);

            Ball = new Ball(radius, body);

            MetalBarTexture = new Texture2D(GraphicsDevice, 1, 1);
            MetalBarTexture.SetData(new Color[] { Color.Gray });

            // Set window size if running debug (in release it will be fullscreen)
            #region
#if DEBUG
            // Actual size, change to this when submit
            // width = 420
            // height = 980
            _graphics.PreferredBackBufferWidth = Coordinates.Item1;
            _graphics.PreferredBackBufferHeight = Coordinates.Item2;
            //_graphics.ApplyChanges();

            // Connor's massive monitor size requires this
            // Coordinates = Tuple.Create(750, 1750);
            _graphics.PreferredBackBufferWidth = Coordinates.Item1;
            _graphics.PreferredBackBufferHeight = Coordinates.Item2;
            _graphics.ApplyChanges();
#else
			_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
			_graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
			_graphics.ApplyChanges();
#endif
            #endregion

            // TODO: Add your initialization logic here

            var metalBarBody = World.CreateRectangle(Coordinates.Item1 + 800, 30, 1, new Vector2(0, Coordinates.Item2 - 30), 0, BodyType.Static);
            MetalBar = new MetalBar(MetalBarTexture, metalBarBody);

            base.Initialize();
        }

        /// <summary>
        /// Does any setup prior to the first frame that needs loaded content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Ball.LoadContent(Content);

            // BallTexture = Content.Load<Texture2D>("CircleSprite");

            // TODO: use this.Content to load your game content here
            // ex.
            // texture = Content.Load<Texture2D>("fileNameWithoutExtention");
        }

        /// <summary>
        /// Your main update loop. This runs once every frame, over and over.
        /// </summary>
        /// <param name="gameTime">This is the gameTime object you can use to get the time since last frame.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.Update(); // Updates the state of the input library

            // Exit when both menu buttons are pressed (or escape for keyboard debuging)
            // You can change this but it is suggested to keep the keybind of both menu
            // buttons at once for gracefull exit.
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) ||
                (Input.GetButton(1, Input.ArcadeButtons.Menu) &&
                Input.GetButton(2, Input.ArcadeButtons.Menu)))
            {
                Exit();
            }

            // TODO: Add your update logic here
            MetalBar.Update(gameTime);

            Ball.Update(gameTime);
            World.Step((float)gameTime.ElapsedGameTime.TotalSeconds);

            // Debug.WriteLine($"H1: {Heights[0]} | H2: {Heights[1]}");

            base.Update(gameTime);
        }

        /// <summary>
        /// Your main draw loop. This runs once every frame, over and over.
        /// </summary>
        /// <param name="gameTime">This is the gameTime object you can use to get the time since last frame.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(227, 208, 36));

            _spriteBatch.Begin();
            // TODO: Add your drawing code here

            Ball.Draw(_spriteBatch);
            MetalBar.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}