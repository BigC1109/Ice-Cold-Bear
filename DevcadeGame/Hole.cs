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
            EXIT
        }


        private Vector2 position;

        private Texture2D texture;

        private Vector2 velocity;

        private Color color;

        private int radius;

        private HoleState state;

        private Game1 game;

        private int scale;

        public Hole(int radius, Vector2 position, HoleState state, Game1 game)
        {
            this.radius = radius;
            this.position = position;
            this.state = state;
            this.game = game;
            this.color = Color.DarkCyan;
            this.scale = radius / 512;
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.texture = contentManager.Load<Texture2D>("MetalBall");
        }

        private bool ContainsBall()
        {
            if (this.position.X < game.Ball.Body.Position.X && this.position.X + (radius * 2) > game.Ball.Body.Position.X
                && this.position.Y > game.Ball.Body.Position.Y && this.position.Y - (radius * 2) < game.Ball.Body.Position.Y)
            {
                return true;
            }
            return false;
        }

        public void Update(GameTime gameTime)
        {
            if (this.state == HoleState.INCORRECT && ContainsBall()) // Change true into checking if the current Hole that fully contains the ball
            {
                Debug.WriteLine("Successful?");
            } else if (this.state == HoleState.CORRECT && ContainsBall()) // Change true into checking if the current Hole that fully contains the ball
            {

            } else if (this.state == HoleState.EXIT && ContainsBall()) // Change true into checking if the current Hole that fully contains the ball
            {

            }
            //
            //Debug.WriteLine(game.Ball.Body.Position);

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
            // (texture, body.Position, null, color, body.Rotation, origin, scale, SpriteEffects.None, 0);
            Debug.WriteLine(position.X + " " + position.Y);
        }

    }
}
