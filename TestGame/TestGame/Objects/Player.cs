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
    public class Player : MoveObj
    {
        Vector2 dir = Vector2.Zero;

        float angle;

        public Player(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            this.DrawOrder = 1;

            KeyState = Keyboard.GetState();

            ObjPos.X = 400.0f; ObjPos.Y = 300.0f;
            angle = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ObjTex = Game.Content.Load<Texture2D>(@"objects\jiki");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            UpdateInput();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(ObjTex, ObjPos, null, Color.White, angle, new Vector2(ObjTex.Width / 2.0f, ObjTex.Height / 2.0f), 2.0f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            KeyState = Keyboard.GetState();
            if (KeyState.IsKeyDown(Keys.Left)) angle -= 0.15f;
            else if (KeyState.IsKeyDown(Keys.Right)) angle += 0.15f;
            angle = MathHelper.WrapAngle(angle);
            dir.X = -(float)Math.Cos((double)(angle + MathHelper.PiOver2)); dir.Y = -(float)Math.Sin((double)(angle + MathHelper.PiOver2));

            if (KeyState.IsKeyDown(Keys.Up))
            {
                dir = Vector2.Multiply(dir, 2.0f);
                Vector2.Add(ref ObjPos, ref dir, out ObjPos);
            }
            if (KeyState.IsKeyDown(Keys.Down))
            {
                dir = Vector2.Negate(dir);
                dir = Vector2.Multiply(dir, 2.0f);
                Vector2.Add(ref ObjPos, ref dir, out ObjPos);
            }
            if (KeyState.IsKeyDown(Keys.LeftShift))
            {
                dir = Vector2.Divide(dir, 2.0f);
                dir = Vector2.Negate(dir);
                Vector2.Add(ref ObjPos, ref dir, out ObjPos);
            }
        }
    }
}
