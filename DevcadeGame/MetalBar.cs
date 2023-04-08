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
    public class MetalBar
    {
        private Rectangle hitbox;

        private Vector2 position;

        private Vector2 positionL;
        private Vector2 positionR;

        private float rotation;

        private Body body;

        public Texture2D Texture { get; private set; }

        private Color Color { get; set; }

        public MetalBar(Texture2D texture, Body body)
        {
            this.Texture = texture;

            this.hitbox = new Rectangle(0, Game1.Coordinates.Item2 - 30, Game1.Coordinates.Item1 + 800, 30);
            this.position = new Vector2(hitbox.X, hitbox.Y);
            this.positionL = new Vector2(0, Game1.Coordinates.Item2 - 30);
            this.positionR = new Vector2(Game1.Coordinates.Item1, Game1.Coordinates.Item2 - 30);
            this.Color = Color.DarkGray;
            this.rotation = 0;

            this.body = body;
        }
        public Rectangle Hitbox
        {
            get => hitbox;
            set => hitbox = value;
        }

        public Body Body
        {
            get => body;
            set => body = value;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                //Debug.WriteLine("Up (Left)");
                positionL.Y += 10;
                if (positionL.Y > Game1.Coordinates.Item2 - 30)
                {
                    positionL.Y = Game1.Coordinates.Item2 - 30;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                //Debug.WriteLine("Down (Left)");
                positionL.Y -= 10;
                if (positionL.Y < 0)
                {
                    positionL.Y = 0;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                //Debug.WriteLine("Up (Right)");
                positionR.Y += 10;
                if (positionR.Y > Game1.Coordinates.Item2 - 30)
                {
                    positionR.Y = Game1.Coordinates.Item2 - 30;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                //Debug.WriteLine("Down (Right)");
                positionR.Y -= 10;
                if (positionR.Y < 0)
                {
                    positionR.Y = 0;
                }
            }

            rotation = (float)Math.Atan2(positionR.Y - positionL.Y, positionR.X - positionL.X);
            hitbox.Y = (int)positionL.Y;
            body.Position = new Vector2(positionL.X, positionL.Y + 15);
            body.Rotation = rotation;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, hitbox, null, Color, rotation, new Vector2(0, 0), SpriteEffects.None, 0.0f);
        }

    }
}
