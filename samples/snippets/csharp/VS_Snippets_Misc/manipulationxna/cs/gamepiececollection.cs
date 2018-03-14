// <Snippet_GamePieceCollectionClass>
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace ManipulationXNA
{
    public class GamePieceCollection : List<GamePiece>
    {
        // <Snippet_GamePieceCollection_PrivateMembersAndConstructor>
        #region PrivateMembersAndConstructor
        private int capturedIndex;

        public GamePieceCollection()
        {
            // No capture yet.
            capturedIndex = -1;
        }
        #endregion
        // </Snippet_GamePieceCollection_PrivateMembersAndConstructor>

        // <Snippet_GamePieceCollection_ProcessInertiaAndDraw>
        #region ProcessInertiaAndDraw
        public void ProcessInertia()
        {
            foreach (GamePiece piece in this)
            {
                piece.ProcessInertia();
            }
        }
        
        public void Draw()
        {
            foreach (GamePiece piece in this)
            {
                piece.Draw();
            }
        }
        #endregion
        // </Snippet_GamePieceCollection_ProcessInertiaAndDraw>

        // <Snippet_GamePieceCollection_UpdateFromMouse>
        #region UpdateFromMouse
        public void UpdateFromMouse()
        {
            MouseState mouseState = Mouse.GetState();

            // If there is a current capture and
            // that piece still reports having the capture,
            // then return. Another piece cannot have the capture now.
            if (capturedIndex >= 0 && 
                capturedIndex < Count 
                && this[capturedIndex].UpdateFromMouse(mouseState))
            {
                return;
            }

            capturedIndex = -1;
            // A higher numbered index gets first chance
            // for a capture. It is "on top" of a lower numbered index.
            for (int index = Count - 1; index >= 0; index--)
            {
                if (this[index].UpdateFromMouse(mouseState))
                {
                    capturedIndex = index;
                    return;
                }
            }
        }
        #endregion
        // </Snippet_GamePieceCollection_UpdateFromMouse>
    }
}
// </Snippet_GamePieceCollectionClass>