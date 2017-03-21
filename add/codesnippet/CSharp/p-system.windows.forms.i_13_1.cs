    private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
    {
        // Move the dragged node when the left mouse button is used.
        if (e.Button == MouseButtons.Left)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        // Copy the dragged node when the right mouse button is used.
        else if (e.Button == MouseButtons.Right)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy);
        }
    }