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
    class Enemy : MoveObj
    {
        Vector2 dir,playerpos,Origin;
        float speed = 1.5f;

        public Enemy(Game game)
            : base(game)
        {
        }

        public Vector2 playerPos
        {
            set { playerpos = value; }
            get { return playerpos; }
        }

        public override void Initialize()
        {
            this.DrawOrder = 1;

            ObjPos.X = 0; ObjPos.Y = 10f;
            dir = Vector2.Zero;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ObjTex = Game.Content.Load<Texture2D>(@"objects\Enemy");
            Origin = new Vector2(ObjTex.Width / 2.0f, ObjTex.Height / 2.0f);
            base.LoadContent();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(ObjTex, ObjPos, null, Color.White, 0f, Origin, 1.0f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        public override void Update(GameTime gameTime)
        {
            dir = Vector2.Normalize(playerpos - ObjPos);
            ObjPos += Vector2.Multiply(dir, speed);
            base.Update(gameTime);
        }
    }
}
