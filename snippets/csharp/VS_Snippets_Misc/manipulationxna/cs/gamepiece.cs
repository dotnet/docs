// <Snippet_GamePieceClass>
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Input.Manipulations;

namespace ManipulationXNA
{

    public class GamePiece
    {
        // <Snippet_GamePiece_PrivateMembers>
        #region PrivateMembers
        // The sprite batch used for drawing the game piece.
        private SpriteBatch spriteBatch;
        // The position of the game piece.
        private Vector2 position;
        // The origin used for rendering the game piece.
        // Gets set to be the center of the piece.
        private Vector2 origin;
        // The texture for the piece.
        private Texture2D texture;
        // The bounds of the game piece. Used for hit testing.
        private Rectangle bounds;
        // The rotation of the game piece, in radians.
        private float rotation;
        // The scale, in percentage of the actual image size. 1.0 = 100%.
        private float scale;
        // The view port, used to detect when to bounce.
        private Viewport viewport;
        // The manipulation processor for this game piece.
        private ManipulationProcessor2D manipulationProcessor;
        // The inertia processor for this game piece.
        private InertiaProcessor2D inertiaProcessor;
        // Flag to indicate that inertia processing should start or continue.
        private bool processInertia;
        // Flag to indicate whether this piece has captured the mouse.
        private bool isMouseCaptured;
        // Used during manipulation to indicate where the drag is occurring.
        private System.Windows.Point dragPoint;
        // The color of the game piece.
        private Color pieceColor;
        // Represents how spongy the walls act when the piece bounces.
        // Must be <= 1.0 (if greater than 1.0, the piece will accelerate on bounce)
        // 1.0 = no slowdown during a bounce.
        // 0.0 (or less) = won't bounce.
        private float spongeFactor = 0.925f;
        #endregion
        // </Snippet_GamePiece_PrivateMembers>

        /*******************************************/

        // <Snippet_GamePiece_Constructor>
        #region Constructor
        public GamePiece(SpriteBatch spriteBatch, string fileName)
        {
            // For brevity, omitting checking of null parameters.
            this.spriteBatch = spriteBatch;

            // Get the texture from the specified file.
            texture = Texture2D.FromFile(spriteBatch.GraphicsDevice, fileName);

            // Initial position set to 0,0.
            position = new Vector2(0);
            
            // Set the origin to be the center of the texture.
            origin = new Vector2(texture.Width / 2.0f, texture.Height / 2.0f);

            // Set bounds. bounds.X and bounds.Y are set as the position or scale changes.
            bounds = new Rectangle(0, 0, texture.Width, texture.Height);

            // Create manipulation processor.
            Manipulations2D enabledManipulations =
                Manipulations2D.Translate | Manipulations2D.Rotate;
            manipulationProcessor = new ManipulationProcessor2D(enabledManipulations);

            manipulationProcessor.Pivot = new ManipulationPivot2D();
            manipulationProcessor.Pivot.Radius = texture.Width / 2;

            manipulationProcessor.MinimumScaleRotateRadius = 10.0f;

            manipulationProcessor.Started += OnManipulationStarted;
            manipulationProcessor.Delta += OnManipulationDelta;
            manipulationProcessor.Completed += OnManipulationCompleted;

            // Create inertia processor.
            inertiaProcessor = new InertiaProcessor2D();
            inertiaProcessor.Delta += OnInertiaDelta;
            inertiaProcessor.Completed += OnInertiaCompleted;

            inertiaProcessor.TranslationBehavior.DesiredDeceleration = 0.0001F;
            inertiaProcessor.RotationBehavior.DesiredDeceleration = 1e-6F;
            inertiaProcessor.ExpansionBehavior.DesiredDeceleration = 0.0001F;

            // Save the view port. Used to detect when the piece needs to bounce.
            viewport = spriteBatch.GraphicsDevice.Viewport;

            // Set the piece in a random location.
            Random random = new Random((int)Timestamp);
            X = random.Next(viewport.Width);
            Y = random.Next(viewport.Height);

            // Set a random orientation.
            rotation = (float)(random.NextDouble() * Math.PI * 2.0);
            
            dragPoint = new System.Windows.Point(double.NaN, double.NaN);
            pieceColor = Color.White;
            
            // Set scale to normal (100%)
            Scale = 1.0f;
        }
        #endregion
        // </Snippet_GamePiece_Constructor>

        /*******************************************/

        // <Snippet_GamePiece_PublicProperties>
        #region PublicProperties
        public float Scale
        {
            get { return scale; }
            set 
            { 
                scale = value;
                bounds.Width = (int)(texture.Width * value);
                bounds.Height = (int)(texture.Height * value);
                // Setting X and Y (private properties) causes 
                // bounds.X and bounds.Y to adjust to the scale factor.
                X = X;
                Y = Y;
            }
        }

        public Color PieceColor
        {
            get { return pieceColor; }
            set { pieceColor = value; }
        }

        public Rectangle Bounds
        {
            get { return bounds; }
        }
        #endregion
        // </Snippet_GamePiece_PublicProperties>
        
        /*******************************************/

        // <Snippet_GamePiece_ProcessInertia>
        #region ProcessInertia
        public void ProcessInertia()
        {
            if (processInertia)
            {
                inertiaProcessor.Process(Timestamp);
            }
        }
        #endregion
        // </Snippet_GamePiece_ProcessInertia>

        // <Snippet_GamePiece_UpdateFromMouse>
        #region UpdateFromMouse
        public bool UpdateFromMouse(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Released)
            {
                if (isMouseCaptured)
                {
                    manipulationProcessor.CompleteManipulation(Timestamp);
                }
                isMouseCaptured = false;
            }

            if (isMouseCaptured ||
               (mouseState.LeftButton == ButtonState.Pressed &&
               bounds.Contains(mouseState.X, mouseState.Y)))
            {
                isMouseCaptured = true;

                Manipulator2D[] manipulators = new Manipulator2D[] 
                {
                    new Manipulator2D(0, mouseState.X, mouseState.Y)
                };

                dragPoint.X = mouseState.X;
                dragPoint.Y = mouseState.Y;
                manipulationProcessor.ProcessManipulators(Timestamp, manipulators);
            }

            // If the right button is pressed, stop the piece and move it to the center.
            if (mouseState.RightButton == ButtonState.Pressed)
            {
                processInertia = false;
                X = viewport.Width / 2;
                Y = viewport.Height / 2;
                rotation = 0;
            }
            return isMouseCaptured;
        }
        #endregion
        // </Snippet_GamePiece_UpdateFromMouse>

        // <Snippet_GamePiece_Draw>
        #region Draw
        public void Draw()
        {
            spriteBatch.Draw(
                texture, position,
                null, pieceColor, rotation,
                origin, scale,
                SpriteEffects.None, 1.0f);
        }

        public void Draw(Rectangle bounds)
        {
            spriteBatch.Draw(texture, bounds, pieceColor);
        }
        #endregion
        // </Snippet_GamePiece_Draw>
      
        /*******************************************/

        // <Snippet_GamePiece_PrivateProperties>
        #region PrivateProperties
        private long Timestamp
        {
            get 
            {
                // Get timestamp in 100-nanosecond units.
                double nanosecondsPerTick = 1000000000.0 / System.Diagnostics.Stopwatch.Frequency;
                return (long)(System.Diagnostics.Stopwatch.GetTimestamp() / nanosecondsPerTick / 100.0);
            }
        }

        private float X
        {
            get { return position.X; }
            set
            {
                position.X = value;
                manipulationProcessor.Pivot.X = value;
                bounds.X = (int)(position.X - (origin.X * scale));
            }
        }

        private float Y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;
                manipulationProcessor.Pivot.Y = value;
                bounds.Y = (int)(position.Y - (origin.Y * scale));
            }
        }
        #endregion
        // </Snippet_GamePiece_PrivateProperties>
        
        /** Manipulation and Inertia events ********/

        // <Snippet_GamePiece_OnManipulationStarted>
        #region OnManipulationStarted
        private void OnManipulationStarted(object sender, Manipulation2DStartedEventArgs e)
        {
            if (inertiaProcessor.IsRunning)
            {
                inertiaProcessor.Complete(Timestamp);
            }
            processInertia = false;
        }
        #endregion
        // </Snippet_GamePiece_OnManipulationStarted>

        // <Snippet_GamePiece_OnManipulationDelta>
        #region OnManipulationDelta
        private void OnManipulationDelta(object sender, Manipulation2DDeltaEventArgs e)
        {
            //// Adjust the position and rotation of the game piece.
            float deltaX = e.Delta.TranslationX;
            float deltaY = e.Delta.TranslationY;
            if (dragPoint.X != double.NaN || dragPoint.Y != double.NaN)
            {
                // Single-manipulator-drag-rotate mode. Adjust for drag / rotation
                System.Windows.Point center = new System.Windows.Point(position.X, position.Y);
                System.Windows.Vector toCenter = center - dragPoint;
                double sin = Math.Sin(e.Delta.Rotation);
                double cos = Math.Cos(e.Delta.Rotation);
                System.Windows.Vector rotatedToCenter =
                    new System.Windows.Vector(
                        toCenter.X * cos - toCenter.Y * sin,
                        toCenter.X * sin + toCenter.Y * cos);
                System.Windows.Vector shift = rotatedToCenter - toCenter;
                deltaX += (float)shift.X;
                deltaY += (float)shift.Y;
            }

            X += deltaX;
            Y += deltaY;
            rotation += e.Delta.Rotation;
        }
        #endregion
        // </Snippet_GamePiece_OnManipulationDelta>

        // <Snippet_GamePiece_OnManipulationCompleted>
        #region OnManipulationCompleted
        private void OnManipulationCompleted(object sender, Manipulation2DCompletedEventArgs e)
        {
            inertiaProcessor.TranslationBehavior.InitialVelocityX = e.Velocities.LinearVelocityX;
            inertiaProcessor.TranslationBehavior.InitialVelocityY = e.Velocities.LinearVelocityY;
            inertiaProcessor.RotationBehavior.InitialVelocity = e.Velocities.AngularVelocity;
            processInertia = true;
        }
        #endregion
        // </Snippet_GamePiece_OnManipulationCompleted>

        // <Snippet_GamePiece_OnInertiaDelta>
        #region OnInertiaDelta
        private void OnInertiaDelta(object sender, Manipulation2DDeltaEventArgs e)
        {
            // Adjust the position of the game piece.
            X += e.Delta.TranslationX;
            Y += e.Delta.TranslationY;
            rotation += e.Delta.Rotation;

            // Check to see if the piece has hit the edge of the view port.
            bool reverseX = false;
            bool reverseY = false;

            if (X > viewport.Width)
            {
                reverseX = true;
                X = viewport.Width;
            }

            else if (X < viewport.X)
            {
                reverseX = true;
                X = viewport.X;
            }

            if (Y > viewport.Height)
            {
                reverseY = true;
                Y = viewport.Height;
            }

            else if (Y < viewport.Y)
            {
                reverseY = true;
                Y = viewport.Y;
            }

            if (reverseX || reverseY)
            {
                // Get the current velocities, reversing as needed.
                // If reversing, apply sponge factor to slow the piece slightly.
                float velocityX = e.Velocities.LinearVelocityX * ((reverseX) ? -spongeFactor : 1.0f);
                float velocityY = e.Velocities.LinearVelocityY * ((reverseY) ? -spongeFactor : 1.0f);
                // Must stop inertia processing before changing parameters.
                if (inertiaProcessor.IsRunning)
                {
                    inertiaProcessor.Complete(Timestamp);
                }
                // Assign the new velocities.
                inertiaProcessor.TranslationBehavior.InitialVelocityX = velocityX;
                inertiaProcessor.TranslationBehavior.InitialVelocityY = velocityY;
                // Set flag so that inertia processing will continue.
                processInertia = true;
            }
        }
        #endregion
        // </Snippet_GamePiece_OnInertiaDelta>

        // <Snippet_GamePiece_OnInertiaCompleted>
        #region OnInertiaCompleted
        private void OnInertiaCompleted(object sender, Manipulation2DCompletedEventArgs e)
        {
            processInertia = false;
        }
        #endregion
        // </Snippet_GamePiece_OnInertiaCompleted>
    }
}
// </Snippet_GamePieceClass>