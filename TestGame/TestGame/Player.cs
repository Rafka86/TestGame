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
    class Player : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D playerImg;

        Vector2 pos;
        Vector2 dir = Vector2.Zero;

        KeyboardState state;

        float angle;

        public Player(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            state = Keyboard.GetState();

            pos.X = 350.0f; pos.Y = 200.0f;
            angle = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerImg = Game.Content.Load<Texture2D>(@"objects\jiki");

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
            spriteBatch.Draw(playerImg, pos, null, Color.White, angle, new Vector2(playerImg.Width / 2.0f, playerImg.Height / 2.0f), 2.0f, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left)) angle -= 0.15f;
            else if (state.IsKeyDown(Keys.Right)) angle += 0.15f;
            angle = MathHelper.WrapAngle(angle);
            dir.X = -(float)Math.Cos((double)(angle + MathHelper.PiOver2)); dir.Y = -(float)Math.Sin((double)(angle + MathHelper.PiOver2));

            if (state.IsKeyDown(Keys.Up)) Vector2.Add(ref pos, ref dir, out pos);
            else if (state.IsKeyDown(Keys.Down))
            {
                dir = Vector2.Negate(dir);
                Vector2.Add(ref pos, ref dir, out pos);
            }
        }
    }
}
