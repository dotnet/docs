//<Snippet000>
using System;
using System.Drawing;
using System.Windows.Forms;

//<Snippet100>
class Form1 : Form
{
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        DataGridView dataGridView1 = new DataGridView();
        DataGridViewRolloverCellColumn col =
            new DataGridViewRolloverCellColumn();
        dataGridView1.Columns.Add(col);
        dataGridView1.Rows.Add(new string[] { "" });
        dataGridView1.Rows.Add(new string[] { "" });
        dataGridView1.Rows.Add(new string[] { "" });
        dataGridView1.Rows.Add(new string[] { "" });
        this.Controls.Add(dataGridView1);
        this.Text = "DataGridView rollover-cell demo";
    }
}
//</Snippet100>

//<Snippet200>
//<Snippet201>
public class DataGridViewRolloverCell : DataGridViewTextBoxCell
{
//</Snippet201>
    //<Snippet210>
    protected override void Paint(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates cellState,
        object value,
        object formattedValue,
        string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        // Call the base class method to paint the default cell appearance.
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
            value, formattedValue, errorText, cellStyle,
            advancedBorderStyle, paintParts);

        // Retrieve the client location of the mouse pointer.
        Point cursorPosition =
            this.DataGridView.PointToClient(Cursor.Position);

        // If the mouse pointer is over the current cell, draw a custom border.
        if (cellBounds.Contains(cursorPosition))
        {
            Rectangle newRect = new Rectangle(cellBounds.X + 1,
                cellBounds.Y + 1, cellBounds.Width - 4,
                cellBounds.Height - 4);
            graphics.DrawRectangle(Pens.Red, newRect);
        }
    }
    //</Snippet210>

    //<Snippet220>
    // Force the cell to repaint itself when the mouse pointer enters it.
    protected override void OnMouseEnter(int rowIndex)
    {
        this.DataGridView.InvalidateCell(this);
    }

    // Force the cell to repaint itself when the mouse pointer leaves it.
    protected override void OnMouseLeave(int rowIndex)
    {
        this.DataGridView.InvalidateCell(this);
    }
    //</Snippet220>

//<Snippet202>
}
//</Snippet202>
//</Snippet200>

//<Snippet300>
public class DataGridViewRolloverCellColumn : DataGridViewColumn
{
    public DataGridViewRolloverCellColumn()
    {
        this.CellTemplate = new DataGridViewRolloverCell();
    }
}
//</Snippet300>
//</Snippet000>