    // Draws a node.
    private void myTreeView_DrawNode(
        object sender, DrawTreeNodeEventArgs e)
    {
        // Draw the background and node text for a selected node.
        if ((e.State & TreeNodeStates.Selected) != 0)
        {
            // Draw the background of the selected node. The NodeBounds
            // method makes the highlight rectangle large enough to
            // include the text of a node tag, if one is present.
            e.Graphics.FillRectangle(Brushes.Green, NodeBounds(e.Node));

            // Retrieve the node font. If the node font has not been set,
            // use the TreeView font.
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

            // Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White,
                Rectangle.Inflate(e.Bounds, 2, 0));
        }

        // Use the default background and node text.
        else 
        {
            e.DrawDefault = true;
        }

        // If a node tag is present, draw its string representation 
        // to the right of the label text.
        if (e.Node.Tag != null)
        {
            e.Graphics.DrawString(e.Node.Tag.ToString(), tagFont,
                Brushes.Yellow, e.Bounds.Right + 2, e.Bounds.Top);
        }

        // If the node has focus, draw the focus rectangle large, making
        // it large enough to include the text of the node tag, if present.
        if ((e.State & TreeNodeStates.Focused) != 0)
        {
            using (Pen focusPen = new Pen(Color.Black))
            {
                focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Rectangle focusBounds = NodeBounds(e.Node);
                focusBounds.Size = new Size(focusBounds.Width - 1, 
                focusBounds.Height - 1);
                e.Graphics.DrawRectangle(focusPen, focusBounds);
            }
        }
    }