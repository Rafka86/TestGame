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
    public class StartMenu : DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        Texture2D BG;

        SpriteFont font;

        KeyboardState oldState, newState;

        Vector2 BGPos = Vector2.Zero;

        public StartMenu(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            BG = Game.Content.Load<Texture2D>(@"textures\texture");

            font = Game.Content.Load<SpriteFont>(@"Fonts\font");

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
            spriteBatch.Draw(BG, BGPos, Color.White);
            //spriteBatch.DrawString(font, "oldState:" + oldState.GetPressedKeys()[1], new Vector2(5, 5), Color.Black);
            //spriteBatch.DrawString(font, "newState:" + newState.GetPressedKeys()[1], new Vector2(5, 15), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            newState = Keyboard.GetState();
            oldState = newState;
        }
    }
}
