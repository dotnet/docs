    // Draws the backgrounds for entire ListView items.
    private void listView1_DrawItem(object sender,
        DrawListViewItemEventArgs e)
    {
        if ((e.State & ListViewItemStates.Selected) != 0)
        {
            // Draw the background and focus rectangle for a selected item.
            e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
            e.DrawFocusRectangle();
        }
        else
        {
            // Draw the background for an unselected item.
            using (LinearGradientBrush brush =
                new LinearGradientBrush(e.Bounds, Color.Orange,
                Color.Maroon, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
        }

        // Draw the item text for views other than the Details view.
        if (listView1.View != View.Details)
        {
            e.DrawText();
        }
    }