    // Paints the content that spans multiple columns and the focus rectangle.
    void dataGridView1_RowPostPaint(object sender,
        DataGridViewRowPostPaintEventArgs e)
    {
        // Calculate the bounds of the row.
        Rectangle rowBounds = new Rectangle(
            this.dataGridView1.RowHeadersWidth, e.RowBounds.Top,
            this.dataGridView1.Columns.GetColumnsWidth(
                DataGridViewElementStates.Visible) -
            this.dataGridView1.HorizontalScrollingOffset + 1,
            e.RowBounds.Height);

        SolidBrush forebrush = null;
        try
        {
            // Determine the foreground color.
            if ((e.State & DataGridViewElementStates.Selected) ==
                DataGridViewElementStates.Selected)
            {
                forebrush = new SolidBrush(e.InheritedRowStyle.SelectionForeColor);
            }
            else
            {
                forebrush = new SolidBrush(e.InheritedRowStyle.ForeColor);
            }

            // Get the content that spans multiple columns.
            object recipe =
                this.dataGridView1.Rows.SharedRow(e.RowIndex).Cells[2].Value;

            if (recipe != null)
            {
                String text = recipe.ToString();

                // Calculate the bounds for the content that spans multiple 
                // columns, adjusting for the horizontal scrolling position 
                // and the current row height, and displaying only whole
                // lines of text.
                Rectangle textArea = rowBounds;
                textArea.X -= this.dataGridView1.HorizontalScrollingOffset;
                textArea.Width += this.dataGridView1.HorizontalScrollingOffset;
                textArea.Y += rowBounds.Height - e.InheritedRowStyle.Padding.Bottom;
                textArea.Height -= rowBounds.Height -
                    e.InheritedRowStyle.Padding.Bottom;
                textArea.Height = (textArea.Height / e.InheritedRowStyle.Font.Height) *
                    e.InheritedRowStyle.Font.Height;

                // Calculate the portion of the text area that needs painting.
                RectangleF clip = textArea;
                clip.Width -= this.dataGridView1.RowHeadersWidth + 1 - clip.X;
                clip.X = this.dataGridView1.RowHeadersWidth + 1;
                RectangleF oldClip = e.Graphics.ClipBounds;
                e.Graphics.SetClip(clip);

                // Draw the content that spans multiple columns.
                e.Graphics.DrawString(
                    text, e.InheritedRowStyle.Font, forebrush, textArea);

                e.Graphics.SetClip(oldClip);
            }
        }
        finally
        {
            forebrush.Dispose();
        }

        if (this.dataGridView1.CurrentCellAddress.Y == e.RowIndex)
        {
            // Paint the focus rectangle.
            e.DrawFocus(rowBounds, true);
        }
    }