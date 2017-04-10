//<Snippet00>
using System;
using System.Drawing;
using System.Windows.Forms;

class DataGridViewRowPainting : Form
{
    private DataGridView dataGridView1 = new DataGridView();
    private Int32 oldRowIndex = 0;
    private const Int32 CUSTOM_CONTENT_HEIGHT = 30;

    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new DataGridViewRowPainting());
    }

    public DataGridViewRowPainting()
    {
        this.dataGridView1.Dock = DockStyle.Fill;
        this.Controls.Add(this.dataGridView1);
        this.Load += new EventHandler(DataGridViewRowPainting_Load);
        this.Text = "DataGridView row painting demo";
    }

    void DataGridViewRowPainting_Load(object sender, EventArgs e)
    {
        //<Snippet10>
        // Set a cell padding to provide space for the top of the focus 
        // rectangle and for the content that spans multiple columns. 
        Padding newPadding = new Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT);
        this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;

        // Set the selection background color to transparent so 
        // the cell won't paint over the custom selection background.
        this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor =
            Color.Transparent;

        // Set the row height to accommodate the content that 
        // spans multiple columns.
        this.dataGridView1.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;
        //</Snippet10>

        // Initialize other DataGridView properties.
        this.dataGridView1.AllowUserToAddRows = false;
        this.dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        this.dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
        this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        // Set the column header names.
        this.dataGridView1.ColumnCount = 4;
        this.dataGridView1.Columns[0].Name = "Recipe";
        this.dataGridView1.Columns[0].SortMode =
            DataGridViewColumnSortMode.NotSortable;
        this.dataGridView1.Columns[1].Name = "Category";
        this.dataGridView1.Columns[2].Name = "Main Ingredients";
        this.dataGridView1.Columns[3].Name = "Rating";

        // Hide the column that contains the content that spans 
        // multiple columns.
        this.dataGridView1.Columns[2].Visible = false;

        // Populate the rows of the DataGridView.
        string[] row1 = new string[]{"Meatloaf", "Main Dish",
            "1 lb. lean ground beef, 1/2 cup bread crumbs, " + 
            "1/4 cup ketchup, 1/3 tsp onion powder, 1 clove of garlic, " +
            "1/2 pack onion soup mix, dash of your favorite BBQ Sauce",
            "****"};
        string[] row2 = new string[]{"Key Lime Pie", "Dessert", 
            "lime juice, whipped cream, eggs, evaporated milk", "****"};
        string[] row3 = new string[]{"Orange-Salsa Pork Chops", 
            "Main Dish", "pork chops, salsa, orange juice, pineapple", "****"};
        string[] row4 = new string[]{"Black Bean and Rice Salad", 
            "Salad", "black beans, brown rice", "****"};
        string[] row5 = new string[]{"Chocolate Cheesecake", 
            "Dessert", "cream cheese, unsweetened chocolate", "***"};
        string[] row6 = new string[]{"Black Bean Dip", "Appetizer",
            "black beans, sour cream, salsa, chips", "***"};
        object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };
        foreach (string[] rowArray in rows)
        {
            this.dataGridView1.Rows.Add(rowArray);
        }

        // Adjust the row heights to accommodate the normal cell content.
        this.dataGridView1.AutoResizeRows(
            DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        // Attach handlers to DataGridView events.
        this.dataGridView1.ColumnWidthChanged += new
            DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
        this.dataGridView1.RowPrePaint += new
            DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);
        this.dataGridView1.RowPostPaint += new
            DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);
        this.dataGridView1.CurrentCellChanged += new
            EventHandler(dataGridView1_CurrentCellChanged);
        this.dataGridView1.RowHeightChanged += new
            DataGridViewRowEventHandler(dataGridView1_RowHeightChanged);
    }

    //<snippet18>
    // Forces the control to repaint itself when the user 
    // manually changes the width of a column.
    void dataGridView1_ColumnWidthChanged(object sender,
        DataGridViewColumnEventArgs e)
    {
        this.dataGridView1.Invalidate();
    }
    //</snippet18>

    //<Snippet19>
    // Forces the row to repaint itself when the user changes the 
    // current cell. This is necessary to refresh the focus rectangle.
    void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
    {
        if (oldRowIndex != -1)
        {
            this.dataGridView1.InvalidateRow(oldRowIndex);
        }
        oldRowIndex = this.dataGridView1.CurrentCellAddress.Y;
    }
    //</Snippet19>

    //<Snippet20>
    // Paints the custom selection background for selected rows.
    void dataGridView1_RowPrePaint(object sender,
            DataGridViewRowPrePaintEventArgs e)
    {
        // Do not automatically paint the focus rectangle.
        e.PaintParts &= ~DataGridViewPaintParts.Focus;

        //<Snippet25>
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
        //</Snippet25>
    }
    //</Snippet20>

    //<Snippet30>
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
            //<Snippet34>
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
            //</Snippet34>

            //<Snippet35>
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
            //</Snippet35>
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
    //</Snippet30>

    //<Snippet40>
    // Adjusts the padding when the user changes the row height so that 
    // the normal cell content is fully displayed and any extra
    // height is used for the content that spans multiple columns.
    void dataGridView1_RowHeightChanged(object sender,
        DataGridViewRowEventArgs e)
    {
        // Calculate the new height of the normal cell content.
        Int32 preferredNormalContentHeight =
            e.Row.GetPreferredHeight(e.Row.Index, 
            DataGridViewAutoSizeRowMode.AllCellsExceptHeader, true) -
            e.Row.DefaultCellStyle.Padding.Bottom;

        // Specify a new padding.
        Padding newPadding = e.Row.DefaultCellStyle.Padding;
        newPadding.Bottom = e.Row.Height - preferredNormalContentHeight;
        e.Row.DefaultCellStyle.Padding = newPadding;
    }
    //</Snippet40>
}
//</Snippet00>

