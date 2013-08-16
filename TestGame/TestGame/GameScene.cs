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
    public class GameScene : MoveObj
    {
        public GameScene(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            ObjPos = Vector2.Zero;

            Game.Components.Add(new Player(Game));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ObjTex = Game.Content.Load<Texture2D>(@"textures\texture");

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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(ObjTex, ObjPos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
        }
    }
}
