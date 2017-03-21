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