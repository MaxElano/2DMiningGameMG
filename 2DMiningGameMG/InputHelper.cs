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

        public Vector2 MousePosition { get; private set; }

        Keys cameraUp = Keys.W;
        Keys cameraDown = Keys.S;
        Keys cameraLeft = Keys.A;
        Keys cameraRight = Keys.D;
        Keys rotate = Keys.R;

        public InputHelper() { }
        public void Update()
        {
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            MousePosition = new Vector2(mouseState.Position.X, mouseState.Position.Y);
        }

        public Vector2 CameraMovement(GameTime gameTime)
        {
            Vector2 mov = new Vector2();
            if (keyboardState.IsKeyDown(cameraUp))
                mov += new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (keyboardState.IsKeyDown(cameraDown))
                mov -= new Vector2(0, cameraSpeed * gameTime.ElapsedGameTime.Milliseconds);
            if (keyboardState.IsKeyDown(cameraLeft))
                mov += new Vector2(cameraSpeed * gameTime.ElapsedGameTime.Milliseconds, 0);
            if (keyboardState.IsKeyDown(cameraRight))
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

        public bool RotatePressed()
        {
            if (keyboardState.IsKeyDown(rotate) && prevKeyboardState.IsKeyUp(rotate))
                return true;
            return false;
        }
    }
}
