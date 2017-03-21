        private void ListDragTarget_DragOver(object sender, System.Windows.Forms.DragEventArgs e) 
        {

            // Determine whether string data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(typeof(System.String))) {

                e.Effect = DragDropEffects.None;
                DropLocationLabel.Text = "None - no string data.";
                return;
            }

            // Set the effect based upon the KeyState.
            if ((e.KeyState & (8+32)) == (8+32) && 
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {
                // KeyState 8 + 32 = CTL + ALT

                // Link drag-and-drop effect.
                e.Effect = DragDropEffects.Link;

            } else if ((e.KeyState & 32) == 32 && 
                (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {

                // ALT KeyState for link.
                e.Effect = DragDropEffects.Link;

            } else if ((e.KeyState & 4) == 4 && 
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) {

                // SHIFT KeyState for move.
                e.Effect = DragDropEffects.Move;

            } else if ((e.KeyState & 8) == 8 && 
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {

                // CTL KeyState for copy.
                e.Effect = DragDropEffects.Copy;

            } else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)  {

                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

            } else
                e.Effect = DragDropEffects.None;
                
            // Get the index of the item the mouse is below. 

            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.

            indexOfItemUnderMouseToDrop = 
                ListDragTarget.IndexFromPoint(ListDragTarget.PointToClient(new Point(e.X, e.Y)));

            // Updates the label text.
            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches){

                DropLocationLabel.Text = "Drops before item #" + (indexOfItemUnderMouseToDrop + 1);
            } else
                DropLocationLabel.Text = "Drops at the end.";

        }