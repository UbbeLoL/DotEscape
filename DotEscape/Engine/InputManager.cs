using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DotEscape.Engine
{
    class InputManager
    {
        static KeyboardState currentKeyboardState; //This will hold the current state of the keyboard.
        static KeyboardState prevoiusKeyboardState; //This will hold the well, you should be able to figure this out.
        static GamePadState currentGamePadState; //I don't have to explain the rest of these.
        static GamePadState previousGamePadState; //...
        /// <summary>
        ///Call this in every update method of your game to keep things up to date.
        /// </summary>
        public static void Update()
        {
            previousGamePadState = currentGamePadState; //This sets the previous state to the current state.
            prevoiusKeyboardState = currentKeyboardState;

            currentGamePadState = GamePad.GetState(PlayerIndex.One); //Gets the state.
            currentKeyboardState = Keyboard.GetState();
        }
        #region GamePad
        /// <summary>
        /// Checks if the button is being held down.
        /// </summary>
        /// <param name="button">The gamepad button you would like to check.</param>
        /// <returns>Returns a boolean value of rather the button is down or not.</returns>
        public static bool IsButtonDown(Buttons button)
        {
            return (currentGamePadState.IsButtonDown(button));
        }
        /// <summary>
        /// Checks if the button is up. (Not being held down)
        /// </summary>
        /// <param name="button">The gamepad button you would like to check.</param>
        /// <returns>Returns a boolean value of rather the button is up or not.</returns>
        public static bool IsButtonUp(Buttons button)
        {
            return (currentGamePadState.IsButtonUp(button));
        }
        /// <summary>
        /// Checks if the button has been pressed and released.
        /// </summary>
        /// <param name="button">The gamepad button you would like to check.</param>
        /// <returns>Returns a boolean value of rather the button has been pressed or not.</returns>
        public static bool IsButtonPressed(Buttons button)
        {
            return (currentGamePadState.IsButtonUp(button) && previousGamePadState.IsButtonDown(button));
        }
        #endregion
        #region Keyboard
        /// <summary>
        /// Checks if a key is down.
        /// </summary>
        /// <param name="key">The key you would like to check.</param>
        /// <returns>Returns a boolean value of rather the key is down or not.</returns>
        public static bool IsKeyDown(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key));
        }

        /// <summary>
        /// Checks if a key is up.
        /// </summary>
        /// <param name="key">The key you would like to check.</param>
        /// <returns>Returns a boolean value of rather the key is up or not.</returns>
        public static bool IsKeyUp(Keys key)
        {
            return (currentKeyboardState.IsKeyUp(key));
        }
        /// <summary>
        /// Checks if a key has been pressed and released.
        /// </summary>
        /// <param name="key">The key you would like to check.</param>
        /// <returns>Returns a boolean value of rather the key has been pressed and released.</returns>
        public static bool IsKeyPressed(Keys key)
        {
            return (currentKeyboardState.IsKeyUp(key) && prevoiusKeyboardState.IsKeyDown(key));
        }
        #endregion
    }
}
