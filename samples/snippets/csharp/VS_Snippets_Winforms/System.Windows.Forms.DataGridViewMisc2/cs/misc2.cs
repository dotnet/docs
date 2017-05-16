// for MISC snippets only; do not wrap entire file with a snippet tag.

using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        dataGridView1.Dock = DockStyle.Fill;
        Controls.Add(dataGridView1);
        AddColorColumn();
        dataGridView1.RowCount = 10;
    }

    //<snippet20>
    private DataGridView dataGridView1 = new DataGridView();

    private void AddColorColumn()
    {
        DataGridViewComboBoxColumn comboBoxColumn =
            new DataGridViewComboBoxColumn();
        comboBoxColumn.Items.AddRange(
            Color.Red, Color.Yellow, Color.Green, Color.Blue);
        comboBoxColumn.ValueType = typeof(Color);
        dataGridView1.Columns.Add(comboBoxColumn);
        dataGridView1.EditingControlShowing +=
            new DataGridViewEditingControlShowingEventHandler(
            dataGridView1_EditingControlShowing);
    }

    private void dataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox combo = e.Control as ComboBox;
        if (combo != null)
        {
            // Remove an existing event-handler, if present, to avoid 
            // adding multiple handlers when the editing control is reused.
            combo.SelectedIndexChanged -=
                new EventHandler(ComboBox_SelectedIndexChanged);

            // Add the event handler. 
            combo.SelectedIndexChanged +=
                new EventHandler(ComboBox_SelectedIndexChanged);
        }
    }

    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((ComboBox)sender).BackColor = (Color)((ComboBox)sender).SelectedItem;
    }
    //</snippet20>

    //<snippet30>
    // Workaround for bug that prevents DataGridViewRowCollection.AddRange
    // from working when the row for new records is selected. 
    private void AddRows(params DataGridViewRow[] rows)
    {
        InsertRows(dataGridView1.RowCount - 1, rows);
    }

    //<snippet40>
    // Workaround for bug that prevents DataGridViewRowCollection.InsertRange
    // from working when any rows before the insertion index are selected.
    private void InsertRows(int index, params DataGridViewRow[] rows)
    {
        System.Collections.Generic.List<int> selectedIndexes =
            new System.Collections.Generic.List<int>();
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            if (row.Index >= index)
            {
                selectedIndexes.Add(row.Index);
                row.Selected = false;
            }
        }
        dataGridView1.Rows.InsertRange(index, rows);
        foreach (int selectedIndex in selectedIndexes)
        {
            dataGridView1.Rows[selectedIndex].Selected = true;
        }
    }
    //</snippet40>
    //</snippet30>    

    //<snippet50>
    // Display NullValue for cell values equal to DataSourceNullValue.
    private void dataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        String value = e.Value as string;
        if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))
        {
            e.Value = e.CellStyle.NullValue;
            e.FormattingApplied = true;
        }
    }
    //</snippet50>


    //<snippet60>
    public DataGridViewRow CloneWithValues(DataGridViewRow row)
    {
        DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
        for (Int32 index = 0; index < row.Cells.Count; index++)
        {
            clonedRow.Cells[index].Value = row.Cells[index].Value;
        }
        return clonedRow;
    }
    //</snippet60>

}

public class DerivedDGVCell : DataGridViewCell
{
    //<snippet10>
    // Override OnMouseClick in a class derived from DataGridViewCell to 
    // enter edit mode when the user clicks the cell. 
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        if (base.DataGridView != null)
        {
            Point point1 = base.DataGridView.CurrentCellAddress;
            if (point1.X == e.ColumnIndex &&
                point1.Y == e.RowIndex &&
                e.Button == MouseButtons.Left &&
                base.DataGridView.EditMode !=
                DataGridViewEditMode.EditProgrammatically)
            {
                base.DataGridView.BeginEdit(true);
            }
        }
    }
    //</snippet10>
}

//<snippet70>
public class CustomDataGridView : DataGridView
{
    [System.Security.Permissions.UIPermission(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
    protected override bool ProcessDialogKey(Keys keyData)
    {
        // Extract the key code from the key value. 
        Keys key = (keyData & Keys.KeyCode);

        // Handle the ENTER key as if it were a RIGHT ARROW key. 
        if (key == Keys.Enter)
        {
            return this.ProcessRightKey(keyData);
        }
        return base.ProcessDialogKey(keyData);
    }

    [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
    protected override bool ProcessDataGridViewKey(KeyEventArgs e)
    {
        // Handle the ENTER key as if it were a RIGHT ARROW key. 
        if (e.KeyCode == Keys.Enter)
        {
            return this.ProcessRightKey(e.KeyData);
        }
        return base.ProcessDataGridViewKey(e);
    }
}
//</snippet70>