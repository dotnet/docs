        // This method defines the DragOver event behavior. 
        protected override void OnDragOver(DragEventArgs dea)
        {
            base.OnDragOver(dea);

            // Get the ToolStripButton control 
            // at the given mouse position.
            Point p = new Point(dea.X, dea.Y);
            ToolStripButton item = this.GetItemAt(
                this.PointToClient(p)) as ToolStripButton;

            // If the ToolStripButton control is the empty cell,
            // indicate that the move operation is valid.
            if( item == this.emptyCellButton )
            {
                // Set the drag operation to indicate a valid move.
                dea.Effect = DragDropEffects.Move;
            }
        }