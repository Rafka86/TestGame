using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace TestGame
{
    public abstract class MoveObj : DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;
        protected Texture2D ObjTex;
        protected Vector2 ObjPos;

        protected KeyboardState KeyState;

        public MoveObj(Game game)
            : base(game)
        {
        }
    }
}
