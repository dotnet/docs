    // Draws subitem text and applies content-based formatting.
    private void listView1_DrawSubItem(object sender,
        DrawListViewSubItemEventArgs e)
    {
        TextFormatFlags flags = TextFormatFlags.Left;

        using (StringFormat sf = new StringFormat())
        {
            // Store the column text alignment, letting it default
            // to Left if it has not been set to Center or Right.
            switch (e.Header.TextAlign)
            {
                case HorizontalAlignment.Center:
                    sf.Alignment = StringAlignment.Center;
                    flags = TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    sf.Alignment = StringAlignment.Far;
                    flags = TextFormatFlags.Right;
                    break;
            }

            // Draw the text and background for a subitem with a 
            // negative value. 
            double subItemValue;
            if (e.ColumnIndex > 0 && Double.TryParse(
                e.SubItem.Text, NumberStyles.Currency,
                NumberFormatInfo.CurrentInfo, out subItemValue) &&
                subItemValue < 0)
            {
                // Unless the item is selected, draw the standard 
                // background to make it stand out from the gradient.
                if ((e.ItemState & ListViewItemStates.Selected) == 0)
                {
                    e.DrawBackground();
                }

                // Draw the subitem text in red to highlight it. 
                e.Graphics.DrawString(e.SubItem.Text,
                    listView1.Font, Brushes.Red, e.Bounds, sf);

                return;
            }

            // Draw normal text for a subitem with a nonnegative 
            // or nonnumerical value.
            e.DrawText(flags);
        }
    }