    private void dataGridView1_CellPainting(object sender,
    System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
    {
        if (this.dataGridView1.Columns["ContactName"].Index ==
            e.ColumnIndex && e.RowIndex >= 0)
        {
            Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
                e.CellBounds.Y + 1, e.CellBounds.Width - 4,
                e.CellBounds.Height - 4);

            using (
                Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                using (Pen gridLinePen = new Pen(gridBrush))
                {
                    // Erase the cell.
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                    // Draw the grid lines (only the right and bottom lines;
                    // DataGridView takes care of the others).
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                        e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                        e.CellBounds.Top, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom);

                    // Draw the inset highlight box.
                    e.Graphics.DrawRectangle(Pens.Blue, newRect);

                    // Draw the text content of the cell, ignoring alignment.
                    if (e.Value != null)
                    {
                        e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                            Brushes.Crimson, e.CellBounds.X + 2,
                            e.CellBounds.Y + 2, StringFormat.GenericDefault);
                    }
                    e.Handled = true;
                }
            }
        }
    }