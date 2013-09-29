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
        Vector2 Dir, Origin, NormalDir;

        private bool ShotFlag;

        float angle;

        public Vector2 Pos
        {
            set { ObjPos = value; }
            get { return ObjPos; }
        }
        
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
            Dir = Vector2.Zero;

            ShotFlag = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ObjTex = Game.Content.Load<Texture2D>(@"objects\Player");
            Origin = new Vector2(ObjTex.Width / 2.0f, ObjTex.Height / 2.0f);

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
            spriteBatch.Draw(ObjTex, ObjPos, null, Color.White, angle, Origin, 1.0f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        private void UpdateInput()
        {
            KeyState = Keyboard.GetState();

            if (KeyState.IsKeyDown(Keys.Left))
            {
                angle -= 0.15f;
            }

            if (KeyState.IsKeyDown(Keys.Right))
            {
                angle += 0.15f;
            }

            angle = MathHelper.WrapAngle(angle);
            Dir.X = -(float)Math.Cos((double)(angle + MathHelper.PiOver2)); Dir.Y = -(float)Math.Sin((double)(angle + MathHelper.PiOver2));
            NormalDir = Vector2.Normalize(Dir);

            if (KeyState.IsKeyDown(Keys.Up))
            {
                ObjPos += Vector2.Multiply(Dir, 2.0f);
                if (KeyState.IsKeyDown(Keys.LeftShift)) SlowMove();
            }

            if (KeyState.IsKeyDown(Keys.Down))
            {
                ObjPos += Vector2.Multiply(Vector2.Negate(Dir), 2.0f);
                if (KeyState.IsKeyDown(Keys.LeftShift)) SlowMove();
            }

            if (KeyState.IsKeyDown(Keys.Z))
            {
                if (!ShotFlag)
                {
                    Game.Components.Add(new Bullet(Game, ObjPos + Vector2.Multiply(NormalDir, 12.0f), NormalDir));
                    ShotFlag = true;
                }
            }

            if (KeyState.IsKeyUp(Keys.Z)) ShotFlag = false;

        }
        private void SlowMove()
        {
            ObjPos += Vector2.Negate(Vector2.Divide(Dir, 2.0f));
        }
    }
}
