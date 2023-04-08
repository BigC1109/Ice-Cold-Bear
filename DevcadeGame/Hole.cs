using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace DevcadeGame
{
    public class Hole
    {
        public enum HoleState
        {
            INCORRECT,
            CORRECT,
            ENTER
        }


        private Vector2 position;

        private Texture2D texture;

        private Vector2 velocity;

        private Color color;

        private int radius;

        private HoleState state;

        private Game1 game;

        private float scale;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Hole(int radius, Vector2 position, HoleState state, Game1 game)
        {
            this.radius = radius;
            this.position = position;
            this.state = state;
            this.game = game;
            this.color = Color.DarkCyan;
            this.scale = (float)radius / 600;
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.texture = contentManager.Load<Texture2D>("MetalBall");
        }

        private bool ContainsBall()
        {
            Vector2 ballCenter = game.Ball.Body.Position;
            int ballRadius = game.Ball.Radius;
            if (ballCenter.X + ballRadius < (this.position.X + (radius * 2)) &&
                ballCenter.Y + ballRadius < (this.position.Y + (radius * 2)) &&
                ballCenter.X - ballRadius > (this.position.X) &&
                ballCenter.Y - ballRadius > (this.position.Y))
            {
                return true;
            }
            return false;
        }

        public void Update(GameTime gameTime)
        {
            if (this.state == HoleState.INCORRECT && ContainsBall()) // Change true into checking if the current Hole that fully contains the ball
            {
                Debug.WriteLine($"Successful? {game.Ball.Body.Position - new Vector2(25, 25)} | {this.position}");
                this.color = Color.Red;
            } else if (this.state == HoleState.CORRECT && ContainsBall()) // Change true into checking if the current Hole that fully contains the ball
            {

            } else if (this.state == HoleState.ENTER && ContainsBall()) // Change true into checking if the current Hole that fully contains the ball
            {

            } else
            {
                this.color = Color.DarkCyan;
            }

            //position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            //
            //Debug.WriteLine(game.Ball.Body.Position);

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
            // (texture, body.Position, null, color, body.Rotation, origin, scale, SpriteEffects.None, 0);
            //Debug.WriteLine(position.X + " " + position.Y);
        }

    }
}
