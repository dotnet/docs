//<Snippet00>
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#endregion

class Form1 : Form
{
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private DataGridView dataGridView1 = new DataGridView();

    public Form1()
    {
        this.dataGridView1.Dock = DockStyle.Fill;
        DataTable data = new DataTable();
        data.Locale = System.Globalization.CultureInfo.InvariantCulture;
        new SqlDataAdapter(
            "select * from customers",
            "data source=localhost;initial catalog=northwind;" + 
            "integrated security=sspi")
            .Fill(data);
        this.dataGridView1.DataSource = data;
        this.Controls.Add(this.dataGridView1);
        this.Text = "DataGridView.CellPainting demo";
    }

    protected override void OnLoad(EventArgs e)
    {
        this.dataGridView1.CellPainting += new
            DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
        base.OnLoad(e);
    }

    //<Snippet10>
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
    //</Snippet10>
}
//</Snippet00>