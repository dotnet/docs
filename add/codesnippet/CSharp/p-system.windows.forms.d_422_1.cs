        // Determine whether the cell should be painted
        // with the custom selection background.
        if ((e.State & DataGridViewElementStates.Selected) ==
                    DataGridViewElementStates.Selected)
        {
            // Calculate the bounds of the row.
            Rectangle rowBounds = new Rectangle(
                this.dataGridView1.RowHeadersWidth, e.RowBounds.Top,
                this.dataGridView1.Columns.GetColumnsWidth(
                    DataGridViewElementStates.Visible) -
                this.dataGridView1.HorizontalScrollingOffset + 1,
                e.RowBounds.Height);

            // Paint the custom selection background.
            using (Brush backbrush =
                new System.Drawing.Drawing2D.LinearGradientBrush(rowBounds,
                    this.dataGridView1.DefaultCellStyle.SelectionBackColor,
                    e.InheritedRowStyle.ForeColor,
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(backbrush, rowBounds);
            }
        }