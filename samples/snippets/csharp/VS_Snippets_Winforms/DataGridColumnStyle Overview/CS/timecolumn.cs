//<snippet1>
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Permissions;

// This example shows how to create your own column style that
// hosts a control, in this case, a DateTimePicker.
public class DataGridTimePickerColumn : DataGridColumnStyle
{
    private CustomDateTimePicker customDateTimePicker1 = 
        new CustomDateTimePicker();

    // The isEditing field tracks whether or not the user is
    // editing data with the hosted control.
    private bool isEditing;

    public DataGridTimePickerColumn() : base()
    {
        customDateTimePicker1.Visible = false;
    }

    protected override void Abort(int rowNum)
    {
        isEditing = false;
        customDateTimePicker1.ValueChanged -=
            new EventHandler(TimePickerValueChanged);
        Invalidate();
    }

    protected override bool Commit
        (CurrencyManager dataSource, int rowNum)
    {
        customDateTimePicker1.Bounds = Rectangle.Empty;

        customDateTimePicker1.ValueChanged -=
            new EventHandler(TimePickerValueChanged);

        if (!isEditing)
            return true;

        isEditing = false;

        try
        {
            DateTime value = customDateTimePicker1.Value;
            SetColumnValueAtRow(dataSource, rowNum, value);
        }
        catch (Exception)
        {
            Abort(rowNum);
            return false;
        }

        Invalidate();
        return true;
    }

    protected override void Edit(
        CurrencyManager source,
        int rowNum,
        Rectangle bounds,
        bool readOnly,
        string displayText,
        bool cellIsVisible)
    {
        DateTime value = (DateTime)
            GetColumnValueAtRow(source, rowNum);
        if (cellIsVisible)
        {
            customDateTimePicker1.Bounds = new Rectangle
                (bounds.X + 2, bounds.Y + 2,
                bounds.Width - 4, bounds.Height - 4);
            customDateTimePicker1.Value = value;
            customDateTimePicker1.Visible = true;
            customDateTimePicker1.ValueChanged +=
                new EventHandler(TimePickerValueChanged);
        }
        else
        {
            customDateTimePicker1.Value = value;
            customDateTimePicker1.Visible = false;
        }

        if (customDateTimePicker1.Visible)
            DataGridTableStyle.DataGrid.Invalidate(bounds);

        customDateTimePicker1.Focus();
    }

    protected override Size GetPreferredSize(
        Graphics g,
        object value)
    {
        return new Size(100, customDateTimePicker1.PreferredHeight + 4);
    }

    protected override int GetMinimumHeight()
    {
        return customDateTimePicker1.PreferredHeight + 4;
    }

    protected override int GetPreferredHeight(Graphics g,
        object value)
    {
        return customDateTimePicker1.PreferredHeight + 4;
    }

    protected override void Paint(Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum)
    {
        Paint(g, bounds, source, rowNum, false);
    }

    protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        bool alignToRight)
    {
        Paint(
            g, bounds,
            source,
            rowNum,
            Brushes.Red,
            Brushes.Blue,
            alignToRight);
    }

    protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
    {
        DateTime date = (DateTime)
            GetColumnValueAtRow(source, rowNum);
        Rectangle rect = bounds;
        g.FillRectangle(backBrush, rect);
        rect.Offset(0, 2);
        rect.Height -= 2;
        g.DrawString(date.ToString("d"),
            this.DataGridTableStyle.DataGrid.Font,
            foreBrush, rect);
    }

    protected override void SetDataGridInColumn(DataGrid value)
    {
        base.SetDataGridInColumn(value);
        if (customDateTimePicker1.Parent != null)
        {
            customDateTimePicker1.Parent.Controls.Remove
                (customDateTimePicker1);
        }
        if (value != null)
        {
            value.Controls.Add(customDateTimePicker1);
        }
    }

    private void TimePickerValueChanged(object sender, EventArgs e)
    {
        // Remove the handler to prevent it from being called twice in a row.
        customDateTimePicker1.ValueChanged -=
            new EventHandler(TimePickerValueChanged);
        this.isEditing = true;
        base.ColumnStartedEditing(customDateTimePicker1);
    }
}

public class CustomDateTimePicker : DateTimePicker
{
    [SecurityPermissionAttribute(
    SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.UnmanagedCode)]
    protected override bool ProcessKeyMessage(ref Message m)
    {
        // Keep all the keys for the DateTimePicker.
        return ProcessKeyEventArgs(ref m);
    }
}

public class MyForm : Form
{
    private DataTable namesDataTable;
    private DataGrid grid = new DataGrid();
    public MyForm() : base()
    {
        InitForm();

        namesDataTable = new DataTable("NamesTable");
        namesDataTable.Columns.Add(new DataColumn("Name"));
        DataColumn dateColumn = new DataColumn
            ("Date", typeof(DateTime));
        dateColumn.DefaultValue = DateTime.Today;
        namesDataTable.Columns.Add(dateColumn);
        DataSet namesDataSet = new DataSet();
        namesDataSet.Tables.Add(namesDataTable);
        grid.DataSource = namesDataSet;
        grid.DataMember = "NamesTable";
        AddGridStyle();
        AddData();
    }

    private void AddGridStyle()
    {
        DataGridTableStyle myGridStyle = new DataGridTableStyle();
        myGridStyle.MappingName = "NamesTable";

        DataGridTextBoxColumn nameColumnStyle =
            new DataGridTextBoxColumn();
        nameColumnStyle.MappingName = "Name";
        nameColumnStyle.HeaderText = "Name";
        myGridStyle.GridColumnStyles.Add(nameColumnStyle);

        DataGridTimePickerColumn timePickerColumnStyle =
            new DataGridTimePickerColumn();
        timePickerColumnStyle.MappingName = "Date";
        timePickerColumnStyle.HeaderText = "Date";
        timePickerColumnStyle.Width = 100;
        myGridStyle.GridColumnStyles.Add(timePickerColumnStyle);

        grid.TableStyles.Add(myGridStyle);
    }

    private void AddData()
    {

        DataRow dRow = namesDataTable.NewRow();
        dRow["Name"] = "Name 1";
        dRow["Date"] = new DateTime(2001, 12, 01);
        namesDataTable.Rows.Add(dRow);

        dRow = namesDataTable.NewRow();
        dRow["Name"] = "Name 2";
        dRow["Date"] = new DateTime(2001, 12, 04);
        namesDataTable.Rows.Add(dRow);

        dRow = namesDataTable.NewRow();
        dRow["Name"] = "Name 3";
        dRow["Date"] = new DateTime(2001, 12, 29);
        namesDataTable.Rows.Add(dRow);

        dRow = namesDataTable.NewRow();
        dRow["Name"] = "Name 4";
        dRow["Date"] = new DateTime(2001, 12, 13);
        namesDataTable.Rows.Add(dRow);

        dRow = namesDataTable.NewRow();
        dRow["Name"] = "Name 5";
        dRow["Date"] = new DateTime(2001, 12, 21);
        namesDataTable.Rows.Add(dRow);

        namesDataTable.AcceptChanges();
    }

    private void InitForm()
    {
        this.Size = new Size(500, 500);
        grid.Size = new Size(350, 250);
        grid.TabStop = true;
        grid.TabIndex = 1;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Controls.Add(grid);
    }
 
    [STAThread]
    public static void Main()
    {
        Application.Run(new MyForm());
    }
}
//</snippet1>