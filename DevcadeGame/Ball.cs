using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;


namespace DevcadeGame
{
    public class Ball
    {
        private Vector2 position;

        private Texture2D texture;

        private Vector2 velocity;

        private Color color;

        private Body body;

        private int radius;

        private Vector2 origin;

        private float scale; // This is determined by the size of the image provided. Set to amount of pixels the image is by. (Square)

        private Game1 game;

        public bool Colliding { get; protected set; }


        public Ball(int radius, Body body, Game1 game)
        {
            this.body = body;
            this.radius = radius;
            this.game = game;

            this.position = new Vector2(Game1.Coordinates.Item1 / 2, Game1.Coordinates.Item2 / 2);
            this.velocity = new Vector2(0, 0);
            this.color = Color.DarkGray; // Reason the ball is dark gray

            this.scale = (float)radius / 600;
            this.origin = new Vector2(600, 600);

            this.body.OnCollision += CollisionHandler;
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.texture = contentManager.Load<Texture2D>("MetalBall");
        }

        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value;
        }

        public Body Body
        {
            get => body;
            set => body = value;
        }

        public int Radius
        {
            get => radius;
            set => radius = value;
        }

        public void resetBall()
        {
            body.Position = new Vector2(385, 925); // Position of the ENTER hole (maybe do this nicer?)
            body.ResetDynamics();
        }

        public void Update(GameTime gameTime)
        {
            Colliding = false;
        }

        public void Draw(SpriteBatch sb)
        {
            if (!game.MetalBar.Reseting)
            {
                sb.Draw(texture, body.Position, null, color, body.Rotation, origin, scale, SpriteEffects.None, 0);
            }
        }

        private bool CollisionHandler(Fixture fixture, Fixture other, Contact contact)
        {
            Colliding = true;
            return true;
        }
    }
}
