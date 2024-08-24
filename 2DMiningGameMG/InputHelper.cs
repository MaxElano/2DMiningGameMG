using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace _2DMiningGameMG
{
    internal class InputHelper
    {
        float cameraSpeed = 1.0f;
        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;
        MouseState mouseState;
        MouseState prevMouseState;

        Keys cameraUp = Keys.W;
        Keys cameraDown = Keys.S;
        Keys cameraLeft = Keys.A;
        Keys cameraRight = Keys.D;


        public InputHelper() { }
        public void Update()
        {
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        public Vector2 CameraMovement(GameTime gameTime)
        {
            Vector2 mov = new Vector2();
            if (keyboardState.IsKeyDown(Keys.W))
                mov += new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (keyboardState.IsKeyDown(Keys.S))
                mov -= new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (keyboardState.IsKeyDown(Keys.A))
                mov += new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
            if (keyboardState.IsKeyDown(Keys.D))
                mov -= new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);

            return mov;
        }

        public (bool, Vector2) PlaceBuilding()
        {
            return (LeftButtonJustPressed(), new Vector2(mouseState.Position.X, mouseState.Position.Y));
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
