using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2DMiningGameMG
{
    internal class InputHelper
    {
        float cameraSpeed = 1.0f;
        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;
        MouseState mouseState;
        MouseState prevMouseState;

        public InputHelper() { }
        public void UpdateStates()
        {
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
        }
        public void UpdatePlayState(GameTime gameTime, World world)
        {
            UpdateStates();
            if (keyboardState.IsKeyDown(Keys.W))
                world.cameraOffset += new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (keyboardState.IsKeyDown(Keys.S))
                world.cameraOffset -= new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (keyboardState.IsKeyDown(Keys.A))
                world.cameraOffset += new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
            if (keyboardState.IsKeyDown(Keys.D))
                world.cameraOffset -= new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
            if (LeftButtonJustPressed()) //Change this to influence the tile or let world influence the tile and this just tell world that it is pressed
                world.cameraOffset -= new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
            

        }

        public bool LeftButtonJustPressed()
        {
            if (mouseState.LeftButton == ButtonState.Pressed
                && prevMouseState.LeftButton == ButtonState.Released)
                return true;
            else return false;
        }

        public bool LeftButtonJustReleased()
        {
            if (mouseState.LeftButton == ButtonState.Released
                && prevMouseState.LeftButton == ButtonState.Pressed)
                return true;
            else return false;
        }
    }
}
