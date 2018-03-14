// This example demonstrates using images to create a 
// TicTacToe game.
//<snippet0>
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System;

public class TicTacToe : System.Windows.Forms.Form
{
    public TicTacToe()
    {
        blank = new Bitmap(new MemoryStream(blankImage));
        x = new Bitmap(new MemoryStream(xImage));
        o = new Bitmap(new MemoryStream(oImage));

        this.AutoSize = true;
        SetupButtons();
        InitializeDataGridView(null, null);
    }

    private DataGridView dataGridView1;
    private Button Button1 = new Button();
    private Label turn = new Label();
    private Button Button2 = new Button();
    private Button Button3 = new Button();
    private Button Button4 = new Button();
    private Button Button5 = new Button();
    private FlowLayoutPanel Panel1 = new FlowLayoutPanel();

    #region "bitmaps"
    private byte[] oImage = new byte[] {
        0x42, 0x4D, 0xC6, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x76, 
        0x0, 0x0, 0x0, 0x28, 0x0, 0x0, 0x0, 0xB, 0x0, 0x0, 0x0, 0xA,
        0x0, 0x0, 0x0, 0x1, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0, 0x0, 0x50,
        0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10,
        0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,
        0x0, 0x80, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x80, 0x80, 0x0, 
        0x80, 0x0, 0x0, 0x0, 0x80, 0x0, 0x80, 0x0, 0x80, 0x80, 0x0, 
        0x0, 0xC0, 0xC0, 0xC0, 0x0, 0x80, 0x80, 0x80, 0x0, 0x0, 0x0,
        0xFF, 0x0, 0x0, 0xFF, 0x0, 0x0, 0x0, 0xFF, 0xFF, 0x0, 0xFF, 
        0x0, 0x0, 0x0, 0xFF, 0x0, 0xFF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0x0, 0xFF, 0xFF, 0x0, 0xF, 0xFF, 0xF0, 
        0x0, 0x0, 0xFF, 0x0, 0xFF, 0xF0, 0xF, 0xF0, 0x0, 0x0, 0xF0, 
        0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xF0, 0xFF, 0xFF, 
        0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xF, 0xFF, 0xFF, 0xFF, 0xFF, 
        0x0, 0x0, 0x0, 0xF, 0xFF, 0xFF, 0xFF, 0xFF, 0x0, 0x0, 0x0, 
        0xF0, 0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xF0, 0xFF, 
        0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xFF, 0x0, 0xFF, 0xF0, 
        0xF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0x0, 0xF, 0xFF, 0xF0, 0x0, 
        0x0};

    private byte[] xImage = new byte[]{
        0x42, 0x4D, 0xC6, 0x0, 0x0, 0x0, 0x0, 
        0x0, 0x0, 0x0, 0x76, 0x0, 0x0, 0x0, 0x28, 0x0, 0x0, 0x0, 
        0xB, 0x0, 0x0, 0x0, 0xA, 0x0, 0x0, 0x0, 0x1, 0x0, 0x4, 0x0, 
        0x0, 0x0, 0x0, 0x0, 0x50, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,
        0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 
        0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x80, 
        0x0, 0x0, 0x0, 0x80, 0x80, 0x0, 0x80, 0x0, 0x0, 0x0, 0x80, 
        0x0, 0x80, 0x0, 0x80, 0x80, 0x0, 0x0, 0xC0, 0xC0, 0xC0, 0x0,
        0x80, 0x80, 0x80, 0x0, 0x0, 0x0, 0xFF, 0x0, 0x0, 0xFF, 0x0, 
        0x0, 0x0, 0xFF, 0xFF, 0x0, 0xFF, 0x0, 0x0, 0x0, 0xFF, 0x0, 
        0xFF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0x0, 
        0xF0, 0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xFF, 0xF, 
        0xFF, 0xFF, 0xF, 0xF0, 0x0, 0x0, 0xFF, 0xF0, 0xFF, 0xF0, 
        0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xF, 0xF, 0xFF, 0xF0, 0x0,
        0x0, 0xFF, 0xFF, 0xF, 0xF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF,
        0xF, 0xF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xF0, 0xFF, 0xF0, 
        0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xF, 0xFF, 0xFF, 0xF, 0xF0, 0x0,
        0x0, 0xF0, 0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xFF, 
        0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0};

    private byte[] blankImage = new byte[] {
        0x42, 0x4D, 0xC6, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x76, 
        0x0, 0x0, 0x0, 0x28, 0x0, 0x0, 0x0, 0xB, 0x0, 0x0, 0x0, 0xA,
        0x0, 0x0, 0x0, 0x1, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0, 0x0, 0x50,
        0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10,
        0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,
        0x0, 0x80, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x80, 0x80, 0x0, 
        0x80, 0x0, 0x0, 0x0, 0x80, 0x0, 0x80, 0x0, 0x80, 0x80, 0x0, 
        0x0, 0xC0, 0xC0, 0xC0, 0x0, 0x80, 0x80, 0x80, 0x0, 0x0, 0x0,
        0xFF, 0x0, 0x0, 0xFF, 0x0, 0x0, 0x0, 0xFF, 0xFF, 0x0, 0xFF, 
        0x0, 0x0, 0x0, 0xFF, 0x0, 0xFF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 
        0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 
        0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 
        0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 
        0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 
        0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 
        0xFF, 0xF0, 0x0, 0x0};
    #endregion

    private Bitmap blank;
    private Bitmap x;
    private Bitmap o;
    private string xString = "X's turn";
    private string oString = "O's turn";
    private string gameOverString = "Game Over";
    private int bitmapPadding = 6;

    private void InitializeDataGridView(object sender,
        EventArgs e)
    {
        this.Panel1.SuspendLayout();
        this.SuspendLayout();

        ConfigureForm();
        SizeGrid();
        CreateColumns();
        CreateRows();

        this.Panel1.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private void ConfigureForm()
    {
        AutoSize = true;
        turn.Size = new System.Drawing.Size(75, 34);
        turn.TextAlign = ContentAlignment.MiddleLeft;
        turn.Text = xString;

        Panel1.Location = new System.Drawing.Point(0, 8);
        Panel1.Size = new System.Drawing.Size(120, 196);
        Panel1.FlowDirection = FlowDirection.TopDown;

        ClientSize = new System.Drawing.Size(355, 200);
        Controls.Add(this.Panel1);
        Text = "TicTacToe";

        dataGridView1 = new System.Windows.Forms.DataGridView();
        dataGridView1.Location = new Point(120, 0);
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.CellClick += new
            DataGridViewCellEventHandler(dataGridView1_CellClick);
        dataGridView1.CellMouseEnter += new
            DataGridViewCellEventHandler(dataGridView1_CellMouseEnter);
        dataGridView1.CellMouseLeave += new
            DataGridViewCellEventHandler(dataGridView1_CellMouseLeave);

        Controls.Add(dataGridView1);
    }

    private void SetupButtons()
    {
        Button1.AutoSize = true;
        SetupButton(Button1, "Restart", new EventHandler(Reset));
        Panel1.Controls.Add(turn);
        SetupButton(Button2, "Increase Cell Size", new EventHandler(MakeCellsLarger));
        SetupButton(Button3, "Stretch Images", new EventHandler(Stretch));
        SetupButton(Button4, "Zoom Images", new EventHandler(ZoomToImage));
        SetupButton(Button5, "Normal Images", new EventHandler(NormalImage));
    }

    private void SetupButton(Button button, string buttonLabel, EventHandler handler)
    {
        Panel1.Controls.Add(button);
        button.Text = buttonLabel;
        button.AutoSize = true;
        button.Click += handler;
    }

    //<snippet5>
    private void CreateColumns()
    {
        DataGridViewImageColumn imageColumn;
        int columnCount = 0;
        do
        {
            Bitmap unMarked = blank;
            imageColumn = new DataGridViewImageColumn();

            //Add twice the padding for the left and 
            //right sides of the cell.
            imageColumn.Width = x.Width + 2 * bitmapPadding + 1;

            imageColumn.Image = unMarked;
            dataGridView1.Columns.Add(imageColumn);
            columnCount = columnCount + 1;
        }
        while (columnCount < 3);
    }
    //</snippet5>

    private void CreateRows()
    {
        dataGridView1.Rows.Add();
        dataGridView1.Rows.Add();
        dataGridView1.Rows.Add();
    }

    //<snippet7>
    private void SizeGrid()
    {
        dataGridView1.ColumnHeadersVisible = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AllowUserToResizeColumns = false;;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.BorderStyle = BorderStyle.None;

        //Add twice the padding for the top of the cell 
        //and the bottom.
        dataGridView1.RowTemplate.Height = x.Height +
            2 * bitmapPadding + 1;

        dataGridView1.AutoSize = true;
    }
    //</snippet7>

    private void Reset(object sender, System.EventArgs e)
    {
        dataGridView1.Dispose();
        InitializeDataGridView(null, null);
    }

    //<snippet10>
    private void dataGridView1_CellClick(object sender,
        DataGridViewCellEventArgs e)
    {

        if (turn.Text.Equals(gameOverString)) { return; }

        DataGridViewImageCell cell = (DataGridViewImageCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

        if (cell.Value == blank)
        {
            if (IsOsTurn())
            {
                cell.Value = o;
            }
            else
            {
                cell.Value = x;
            }
            ToggleTurn();
        }
        if (IsAWin())
        {
            turn.Text = gameOverString;
        }
    }
    //</snippet10>

    //<snippet15>
    private void dataGridView1_CellMouseEnter(object sender,
        DataGridViewCellEventArgs e)
    {
        Bitmap markingUnderMouse = (Bitmap)dataGridView1.
               Rows[e.RowIndex].
               Cells[e.ColumnIndex].Value;

        if (markingUnderMouse == blank)
        {
            dataGridView1.Cursor = Cursors.Default;
        }
        else if (markingUnderMouse == o || markingUnderMouse == x)
        {
            dataGridView1.Cursor = Cursors.No;
            ToolTip(e, true);
        }
    }

    private void ToolTip(DataGridViewCellEventArgs e, bool showTip)
    {
        DataGridViewImageCell cell = (DataGridViewImageCell)
            dataGridView1
            .Rows[e.RowIndex].Cells[e.ColumnIndex];
        DataGridViewImageColumn imageColumn =
            (DataGridViewImageColumn)
            dataGridView1.Columns[cell.ColumnIndex];

        if (showTip) cell.ToolTipText = imageColumn.Description;
        else { cell.ToolTipText = String.Empty; }
    }

    private void dataGridView1_CellMouseLeave(object sender,
        DataGridViewCellEventArgs e)
    {
        ToolTip(e, false);
        dataGridView1.Cursor = Cursors.Default;
    }
    //</snippet15>

    //<snippet20>
    private void Stretch(object sender, EventArgs e)
    {
        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            column.Description = "Stretched";
        }
    }

    private void ZoomToImage(object sender, EventArgs e)
    {

        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column.Description = "Zoomed";
        }
    }

    private void NormalImage(object sender, EventArgs e)
    {

        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.ImageLayout = DataGridViewImageCellLayout.Normal;
            column.Description = "Normal";
        }
    }
    //</snippet20>

    private void MakeCellsLarger(object sender, EventArgs e)
    {
        foreach (DataGridViewImageColumn column in
            dataGridView1.Columns)
        {
            column.Width = column.Width * 2;
        }
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.IsNewRow) break;
            row.Height = (int)(row.Height * 1.5);
        }
    }

    private bool IsAWin()
    {
        if (ARowIsSame() || AColumnIsSame() || ADiagonalIsSame())
            return true;
        else return false;
    }

    private bool ARowIsSame()
    {
        Bitmap marking = null;

        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.IsNewRow) break;
            marking = (Bitmap)row.Cells[0].Value;
            if (marking != blank)
            {
                if (marking == row.Cells[1].Value &&
                    marking == row.Cells[2].Value) return true;
            }
        }
        return false;
    }

    private bool AColumnIsSame()
    {
        int columnIndex = 0;
        Bitmap marking;
        do
        {
            marking = (Bitmap)
                dataGridView1.Rows[0].Cells[columnIndex].Value;
            if (marking != blank)
            {
                if (marking == (Bitmap)dataGridView1.Rows[1]
                    .Cells[columnIndex].Value
                    && marking == (Bitmap)dataGridView1.Rows[2].
                    Cells[columnIndex].Value) return true;
            }
            columnIndex = columnIndex + 1;
        }
        while (columnIndex < dataGridView1.Columns.GetColumnCount(
            DataGridViewElementStates.Visible));
        return false;
    }

    private bool ADiagonalIsSame()
    {
        if (LeftToRightDiagonalIsSame()) { return true; }
        if (RightToLeftDiagonalIsSame()) { return true; }
        return false;
    }

    private bool LeftToRightDiagonalIsSame()
    {
        return IsDiagonalSame(0, 2);
    }

    private bool RightToLeftDiagonalIsSame()
    {
        return IsDiagonalSame(2, 0);
    }

    private bool IsDiagonalSame(int startingColumn, int lastColumn)
    {
        Bitmap marking = (Bitmap)dataGridView1.Rows[0]
            .Cells[startingColumn].Value;

        if (marking == blank) return false;
        if (marking == dataGridView1.Rows[1].Cells[1]
            .Value && marking == dataGridView1.Rows[2]
            .Cells[lastColumn].Value) return true;

        return false;
    }

    private void ToggleTurn()
    {
        if (turn.Text.Equals(xString)) { turn.Text = oString; }
        else { turn.Text = xString; }
    }

    private bool IsOsTurn()
    {
        if (turn.Text.Equals(oString)) return true;
        return false;
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new TicTacToe());
    }

}
//</snippet0>