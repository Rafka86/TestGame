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
    class Bullet : MoveObj
    {
        Vector2 dir;

        public Bullet(Game game, Vector2 StartPos, Vector2 Dir)
            : base(game)
        {
            ObjPos = StartPos;
            ObjPos.X -= 16.0f; ObjPos.Y -= 16.0f;
            dir = Dir;
        }

        public override void Initialize()
        {
            this.DrawOrder = 2;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ObjTex = Game.Content.Load<Texture2D>(@"objects\Bullet");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            ObjPos += Vector2.Multiply(dir, 10.0f);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(ObjTex, ObjPos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
