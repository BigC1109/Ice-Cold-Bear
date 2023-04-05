using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;
using Microsoft.Xna.Framework.Content;


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

        private float scale;


        public Ball(int radius, Body body)
        {
            this.body = body;
            this.radius = radius;

            this.position = new Vector2(Game1.Coordinates.Item1 / 2, Game1.Coordinates.Item2 / 2);
            this.velocity = new Vector2(0, 0);
            this.color = Color.DarkGray;

            this.scale = (float)radius / 49;
            this.origin = new Vector2(49, 49);
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.texture = contentManager.Load<Texture2D>("CircleSprite");
        }

        public Vector2 Velocity
        {
            get => velocity;
            set => velocity = value;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, body.Position, null, color, body.Rotation, origin, scale, SpriteEffects.None, 0);
        }
    }
}
