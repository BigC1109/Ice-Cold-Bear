using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace DevcadeGame
{
    public class Level
    {
        private LinkedList<Hole> holes;

        private Hole curObjective;

        private int curLevel;

        private Hole ballFellIn;

        private bool failed;

        private Game1 game;

        public Level (LinkedList<Hole> holes, Game1 game)
        {
            this.holes = holes;
            this.curLevel = 0;
            this.curObjective = null;
            this.ballFellIn = null;
            this.failed = false;
            this.game = game;
        }

        public void nextLevel()
        {
            if (curObjective != null)
            {
                passedLevel();
            }
           
            int counter = 0;
            foreach (Hole hole in holes)
            {
                if (hole.SpecialHole && counter == curLevel)
                {
                    if (curObjective != null)
                    {
                        curObjective.State = Hole.HoleType.INCORRECT;
                    }
                    hole.State = Hole.HoleType.CORRECT;
                    curObjective = hole;
                    break;
                } else if (hole.SpecialHole)
                {
                    counter++;
                }
            }
            Debug.WriteLine(curLevel);
            curLevel++;
        }

        private void passedLevel()
        {
            this.ballFellIn = curObjective;
            this.failed = false;
        }

        public void failedLevel(Hole hole)
        {
            this.ballFellIn = hole;
            this.failed = true;
        }

        public void Update(GameTime gameTime)
        {
            if (game.MetalBar.Reseting && ballFellIn != null)
            {
                if (failed)
                {
                    ballFellIn.Color = Color.DarkRed;
                } else
                {
                    ballFellIn.Color = Color.Gold;
                }
            }
        }
    }
}
