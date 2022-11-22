using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Devcade;
using System.Diagnostics;
using System.Collections.Generic;

namespace DevcadeGame
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Texture2D metalBar;
		private Tuple<int, int> Coordinates; // width, height
		private List<int> Heights = new List<int> { 0, 0 };

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

            // Set window size if running debug (in release it will be fullscreen)
            #region
#if DEBUG
            // Actual size, change to this when submit
            // width = 420
            // height = 980
            Coordinates = Tuple.Create(420, 980);
            _graphics.PreferredBackBufferWidth = Coordinates.Item1;
            _graphics.PreferredBackBufferHeight = Coordinates.Item2;
            //_graphics.ApplyChanges();

            // Connor's massive monitor size requires this
            Coordinates = Tuple.Create(750, 1750);
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

            base.Initialize();
		}

		/// <summary>
		/// Does any setup prior to the first frame that needs loaded content.
		/// </summary>
		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			metalBar = Content.Load<Texture2D>("download");



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
			if (Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				Debug.WriteLine("Down (Left)");
                var height = Heights[0];
                Heights.RemoveAt(0);
                height += 10;
                Heights.Insert(0, height);
            }
			if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Debug.WriteLine("Up (Left)");
				var height = Heights[0];
				Heights.RemoveAt(0);
				height -= 10;
				Heights.Insert(0, height);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Debug.WriteLine("Down (Right)");
                var height = Heights[1];
                Heights.RemoveAt(1);
                height += 10;
                Heights.Insert(1, height);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Debug.WriteLine("Up (Right)");
                var height = Heights[1];
                Heights.RemoveAt(1);
                height -= 10;
                Heights.Insert(1, height);
            }

			Debug.WriteLine($"H1: {Heights[0]} | H2: {Heights[1]}");

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
			//Debug.WriteLine($"x, y:{Coordinates} x:{Coordinates.Item1 / 2} y:{Coordinates.Item2 * (5 / 100)}");
			_spriteBatch.Draw(metalBar, new Rectangle(-15, (Coordinates.Item2/2) + Heights[1], Coordinates.Item1 + 30, Coordinates.Item2/65), new Color(255, 255, 255));
			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}