using Devcade;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DevcadeGame
{
    public class MetalBar
    {
        private Texture2D _texture;
        private Dictionary<int, int[]> metalBarPosition = new Dictionary<int, int[]>();

        public MetalBar(Texture2D _texture)
        {
            this._texture = _texture;
            metalBarPosition[0] = new int[] { 0, Game1.Coordinates.Item2 - 30 };
            metalBarPosition[1] = new int[] { Game1.Coordinates.Item1, Game1.Coordinates.Item2 - 30 };
        }
        
    }
}
