// <Snippet_Game1Class>
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Windows.Input.Manipulations;

namespace ManipulationXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // <Snippet_Game1_PrivateMembers>
        #region PrivateMembers
        // Number of game pieces.
        private const int GamePieceCount = 6;
        // The collection of game pieces.
        private GamePieceCollection faces;
        // Graphics device manager.
        private GraphicsDeviceManager graphics;
        // The sprite batch used for rendering game pieces.
        private SpriteBatch spriteBatch;
        #endregion
        // </Snippet_Game1_PrivateMembers>

        // <Snippet_Game1_ConstructorInitialize>
        #region ConstructorInitialize
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // This is the default but assigning here explicitly
            // to show that resizing is not supported. The view port
            // boundaries used to bounce a game piece would not be
            // updated if the window was resized.
            Window.AllowUserResizing = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            faces = new GamePieceCollection();
            // base.Initialize calls the LoadContent method.
            base.Initialize();
        }
        #endregion
        // </Snippet_Game1_ConstructorInitialize>

        // <Snippet_Game1_LoadContent>
        #region LoadContent
        /// <summary>
        /// LoadContent will be called once per game. Load all content here.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            string filename = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string path = System.IO.Path.GetDirectoryName(filename) + @"\Content";

            // Scale pieces from 100% to 160%
            float scale = 1.0f;
            float scaleFactor = 0.60f / ((GamePieceCount/2)-1);
            for (int k = 0; k < GamePieceCount / 2; k++)
            {
                GamePiece face1 = new GamePiece(spriteBatch, path + @"\Face1.png");
                GamePiece face2 = new GamePiece(spriteBatch, path + @"\Face2.png");

                face1.Scale = face2.Scale = scale;
                face1.PieceColor = Color.Green;
                face2.PieceColor = Color.LightSalmon;
                faces.Add(face1);
                faces.Add(face2);
                scale += scaleFactor;
            }
        }
        #endregion
        // </Snippet_Game1_LoadContent>

        // <Snippet_Game1_UnloadContent>
        #region UnloadContent
        /// <summary>
        /// UnloadContent will be called once per game. Unload all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }
        #endregion
        // </Snippet_Game1_UnloadContent>

        // <Snippet_Game1_UpdateGame>
        #region UpdateGame
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            faces.ProcessInertia();
            faces.UpdateFromMouse();
            base.Update(gameTime);
        }
        #endregion
        // </Snippet_Game1_UpdateGame>

        // <Snippet_Game1_DrawGame>
        #region DrawGame
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            faces.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
        // </Snippet_Game1_DrawGame>
    }
}
// </Snippet_Game1Class>