    // Moves the insertion mark as the item is dragged.
    private void myListView_DragOver(object sender, DragEventArgs e)
    {
        // Retrieve the client coordinates of the mouse pointer.
        Point targetPoint = 
            myListView.PointToClient(new Point(e.X, e.Y));

        // Retrieve the index of the item closest to the mouse pointer.
        int targetIndex = myListView.InsertionMark.NearestIndex(targetPoint);

        // Confirm that the mouse pointer is not over the dragged item.
        if (targetIndex > -1) 
        {
            // Determine whether the mouse pointer is to the left or
            // the right of the midpoint of the closest item and set
            // the InsertionMark.AppearsAfterItem property accordingly.
            Rectangle itemBounds = myListView.GetItemRect(targetIndex);
            if ( targetPoint.X > itemBounds.Left + (itemBounds.Width / 2) )
            {
                myListView.InsertionMark.AppearsAfterItem = true;
            }
            else
            {
                myListView.InsertionMark.AppearsAfterItem = false;
            }
        }

        // Set the location of the insertion mark. If the mouse is
        // over the dragged item, the targetIndex value is -1 and
        // the insertion mark disappears.
        myListView.InsertionMark.Index = targetIndex;
    }