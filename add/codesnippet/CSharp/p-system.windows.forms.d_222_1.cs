    // Draws column headers.
    private void listView1_DrawColumnHeader(object sender,
        DrawListViewColumnHeaderEventArgs e)
    {
        using (StringFormat sf = new StringFormat())
        {
            // Store the column text alignment, letting it default
            // to Left if it has not been set to Center or Right.
            switch (e.Header.TextAlign)
            {
                case HorizontalAlignment.Center:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Right:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }

            // Draw the standard header background.
            e.DrawBackground();

            // Draw the header text.
            using (Font headerFont =
                        new Font("Helvetica", 10, FontStyle.Bold))
            {
                e.Graphics.DrawString(e.Header.Text, headerFont,
                    Brushes.Black, e.Bounds, sf);
            }
        }
        return;
    }