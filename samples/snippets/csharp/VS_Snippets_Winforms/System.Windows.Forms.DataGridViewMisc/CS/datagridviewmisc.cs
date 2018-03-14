// This file is for miscellaneous, tiny snippets that do not need to exist within a wider scope.
// Do not wrap the entire file in a snippet tag for use in any topic.

#region Using directives

using System;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

#endregion

class DataGridViewMisc : Form
{
    private DataGridView dataGridView1 = new DataGridView();

    public DataGridViewMisc()
    {
        dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
    }

    [STAThreadAttribute()]
    public static void Main()
    {
    }

    // How to: Add an Unbound Column to a Data-Bound Windows Forms DataGridView Control
    //<Snippet010>
    private void CreateUnboundButtonColumn()
    {
        // Initialize the button column.
        DataGridViewButtonColumn buttonColumn =
            new DataGridViewButtonColumn();
        buttonColumn.Name = "Details";
        buttonColumn.HeaderText = "Details";
        buttonColumn.Text = "View Details";

        // Use the Text property for the button text for all cells rather
        // than using each cell's value as the text for its own button.
        buttonColumn.UseColumnTextForButtonValue = true;

        // Add the button column to the control.
        dataGridView1.Columns.Insert(0, buttonColumn);
    }
    //</Snippet010>

    // How to: Autogenerate Columns in a Data-Bound Windows Forms DataGridView Control
    private DataGridView customersDataGridView = new DataGridView();
    private DataSet customersDataSet = new DataSet();
    //<Snippet020>
    private void BindData()
    {
        customersDataGridView.AutoGenerateColumns = true;
        customersDataGridView.DataSource = customersDataSet;
        customersDataGridView.DataMember = "Customers";
    }
    //</Snippet020>

    // How to: Change the Border and Gridline Styles in the Windows Forms DataGridView Control
    //<Snippet030>
    private void SetBorderAndGridlineStyles()
    {
        //<Snippet031>
        this.dataGridView1.GridColor = Color.BlueViolet;
        //</Snippet031>
        //<Snippet032>
        this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
        //</Snippet032>
        //<Snippet033>
        this.dataGridView1.CellBorderStyle =
            DataGridViewCellBorderStyle.None;
        this.dataGridView1.RowHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
        this.dataGridView1.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
        //</Snippet033>
    }
    //</Snippet030>

    // How to: Change the Order of the Columns in the Windows Forms DataGridView Control
    //<Snippet040>
    private void AdjustColumnOrder()
    {
        customersDataGridView.Columns["CustomerID"].Visible = false;
        customersDataGridView.Columns["ContactName"].DisplayIndex = 0;
        customersDataGridView.Columns["ContactTitle"].DisplayIndex = 1;
        customersDataGridView.Columns["City"].DisplayIndex = 2;
        customersDataGridView.Columns["Country"].DisplayIndex = 3;
        customersDataGridView.Columns["CompanyName"].DisplayIndex = 4;
    }
    //</Snippet040>

    // 1 of 2 for How to: Display Images in Cells of the Windows Forms DataGridView Control
    //<Snippet050>
    private void createGraphicsColumn()
    {
        Icon treeIcon = new Icon(this.GetType(), "tree.ico");
        DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
        iconColumn.Image = treeIcon.ToBitmap();
        iconColumn.Name = "Tree";
        iconColumn.HeaderText = "Nice tree";
        dataGridView1.Columns.Insert(2, iconColumn);
    }
    //</Snippet050>

    // 2 of 2 for How to: Display Images in Cells of the Windows Forms DataGridView Control
    //<Snippet055>
    private void dataGridView1_CellFormatting(object sender,
        System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == "Icon")
        {
            if (e.RowIndex % 5 == 0)
            {
                Bitmap bmp = new Bitmap(this.GetType(), "Bitmap2.bmp");
                e.Value = bmp;
            }
        }
    }
    //</Snippet055>

    private void TinySnippets()
    {
        // How to: Enable Column Reordering in the Windows Forms DataGridView Control
        //<Snippet060>
        dataGridView1.AllowUserToOrderColumns = true;
        //</Snippet060>

        // How to: Freeze Columns in the Windows Forms DataGridView Control
        //<Snippet061>
        this.dataGridView1.Columns["AddToCartButton"].Frozen = true;
        //</Snippet061>

        // How to: Hide Column Headers in the Windows Forms DataGridView Control
        //<Snippet062>
        dataGridView1.ColumnHeadersVisible = false;
        //</Snippet062>

        // How to: Hide Columns in the Windows Forms DataGridView Control
        //<Snippet063>
        this.dataGridView1.Columns["CustomerID"].Visible = false;
        //</Snippet063>

        // How to: Make Columns in the Windows Forms DataGridView Control Read-Only
        //<Snippet064>
        dataGridView1.Columns["CompanyName"].ReadOnly = true;
        //</Snippet064>

        // How to: Set the Selection Mode of the Windows Forms DataGridView Control
        //<Snippet065>
        this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        this.dataGridView1.MultiSelect = false;
        //</Snippet065>

        // How to: Set the Sort Modes for Columns in the Windows Forms DataGridView Control
        //<Snippet066>
        this.dataGridView1.Columns["Priority"].SortMode =
            DataGridViewColumnSortMode.Automatic;
        //</Snippet066>

        // How to: Specify the Edit Mode for the Windows Forms DataGridView Control
        //<Snippet067>
        this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        //</Snippet067>

        // How to: Set Alternating Row Styles for the Windows Forms DataGridView Control
        //<Snippet068>
        this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
        this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
            Color.Beige;
        //</Snippet068>

        //<Snippet069>
        this.dataGridView1.EditingPanel.BorderStyle = BorderStyle.Fixed3D;
        //</Snippet069>
    }

    // How to: Format Data in the Windows Forms DataGridView Control
    //<Snippet070>
    private void SetFormatting()
    {
        //<Snippet071>
        this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "c";
        this.dataGridView1.Columns["ShipDate"].DefaultCellStyle.Format = "d";
        //</Snippet071>
        //<Snippet072>
        this.dataGridView1.Columns["CustomerName"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleRight;
        //</Snippet072>
        //<Snippet073>
        this.dataGridView1.DefaultCellStyle.NullValue = "no entry";
        //</Snippet073>
        //<Snippet074>
        this.dataGridView1.DefaultCellStyle.WrapMode =
            DataGridViewTriState.True;
        //</Snippet074>
    }
    //</Snippet070>

    // 1 of 2 for How to: Get and Set the Current Cell in the Windows Forms DataGridView Control
    //<Snippet080>
    private void getCurrentCellButton_Click(object sender, System.EventArgs e)
    {
        string msg = String.Format("Row: {0}, Column: {1}",
            dataGridView1.CurrentCell.RowIndex,
            dataGridView1.CurrentCell.ColumnIndex);
        MessageBox.Show(msg, "Current Cell");
    }
    //</Snippet080>

    // 2 of 2 for How to: Get and Set the Current Cell in the Windows Forms DataGridView Control
    //<Snippet085>
    private void setCurrentCellButton_Click(object sender, System.EventArgs e)
    {
        // Set the current cell to the cell in column 1, Row 0. 
        this.dataGridView1.CurrentCell = this.dataGridView1[1,0];
    }
    //</Snippet085>

    // How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control
    //<Snippet090>
    private void MakeReadOnly()
    {
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ReadOnly = true;
    }
    //</Snippet090>

    // How to: Set Font and Color Styles in the Windows Forms DataGridView Control
    //<Snippet100>
    private void SetFontAndColors()
    {
        //<Snippet101>
        this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
        //</Snippet101>
        //<Snippet102>
        this.dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
        this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
        //</Snippet102>
        //<Snippet103>
        this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
        this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
        //</Snippet103>
    }
    //</Snippet100>

    // How to: Remove Autogenerated Columns from a Windows Forms DataGridView Control
    //<Snippet110>
    private void BindDataAndInitializeColumns()
    {
        //<Snippet111>
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.DataSource = customersDataSet;
        dataGridView1.Columns.Remove("Fax");
        //</Snippet111>
        //<Snippet112>
        dataGridView1.Columns["CustomerID"].Visible = false;
        //</Snippet112>
    }
    //</Snippet110>

    // How to: Specify Default Values for New Rows in the Windows Forms DataGridView Control
    private Object NewCustomerId() { return new Object(); }
    //<Snippet120>
    private void dataGridView1_DefaultValuesNeeded(object sender,
        System.Windows.Forms.DataGridViewRowEventArgs e)
    {
        e.Row.Cells["Region"].Value = "WA";
        e.Row.Cells["City"].Value = "Redmond";
        e.Row.Cells["PostalCode"].Value = "98052-6399";
        e.Row.Cells["Country"].Value = "USA";
        e.Row.Cells["CustomerID"].Value = NewCustomerId();
    }
    //</Snippet120>

    // 1 of 2 for How to: Perform a Custom Action Based on Changes in a Cell of a Windows Forms DataGridView Control
    //<Snippet130>
    private void dataGridView1_CellValueChanged(object sender,
        DataGridViewCellEventArgs e)
    {
        string msg = String.Format(
            "Cell at row {0}, column {1} value changed",
            e.RowIndex, e.ColumnIndex);
        MessageBox.Show(msg, "Cell Value Changed");
    }
    //</Snippet130>

    // 2 of 2 for How to: Perform a Custom Action Based on Changes in a Cell of a Windows Forms DataGridView Control
    //<Snippet135>
    private void dataGridView1_CellStateChanged(object sender,
        DataGridViewCellStateChangedEventArgs e)
    {
        DataGridViewElementStates state = e.StateChanged;
        string msg = String.Format("Row {0}, Column {1}, {2}",
            e.Cell.RowIndex, e.Cell.ColumnIndex, e.StateChanged);
        MessageBox.Show(msg, "Cell State Changed");
    }
    //</Snippet135>

    // How to: Set Default Cell Styles for the Windows Forms DataGridView Control
    //<Snippet140>
    private void SetDefaultCellStyles()
    {
        //<Snippet141>
        this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
        this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
        //</Snippet141>

        //<Snippet142>
        DataGridViewCellStyle highlightCellStyle = new DataGridViewCellStyle();
        highlightCellStyle.BackColor = Color.Red;

        DataGridViewCellStyle currencyCellStyle = new DataGridViewCellStyle();
        currencyCellStyle.Format = "C";
        currencyCellStyle.ForeColor = Color.Green;
        //</Snippet142>

        //<Snippet143>
        this.dataGridView1.Rows[3].DefaultCellStyle = highlightCellStyle;
        this.dataGridView1.Rows[8].DefaultCellStyle = highlightCellStyle;
        this.dataGridView1.Columns["UnitPrice"].DefaultCellStyle =
            currencyCellStyle;
        this.dataGridView1.Columns["TotalPrice"].DefaultCellStyle =
            currencyCellStyle;
        //</Snippet143>
    }
    //</Snippet140>

    //<Snippet150>
    private void dataGridView1_Sorted(object sender, EventArgs e)
    {
        this.dataGridView1.FirstDisplayedCell = this.dataGridView1.CurrentCell;
    }
    //</Snippet150>

    //<Snippet160>
    private void dataGridView1_ColumnHeaderMouseClick(
        object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
        DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
        ListSortDirection direction;

        // If oldColumn is null, then the DataGridView is not sorted.
        if (oldColumn != null)
        {
            // Sort the same column again, reversing the SortOrder.
            if (oldColumn == newColumn &&
                dataGridView1.SortOrder == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            else
            {
                // Sort a new column and remove the old SortGlyph.
                direction = ListSortDirection.Ascending;
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }
        else
        {
            direction = ListSortDirection.Ascending;
        }

        // Sort the selected column.
        dataGridView1.Sort(newColumn, direction);
        newColumn.HeaderCell.SortGlyphDirection =
            direction == ListSortDirection.Ascending ?
            SortOrder.Ascending : SortOrder.Descending;
    }

    private void dataGridView1_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
    {
        // Put each of the columns into programmatic sort mode.
        foreach (DataGridViewColumn column in dataGridView1.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }
    }
    //</Snippet160>

    //<Snippet170>
    private void clearSelectionButton_Click(object sender, EventArgs e)
    {
        dataGridView1.ClearSelection();
    }
    //</Snippet170>

    //<Snippet180>
    private void selectAllButton_Click(object sender, EventArgs e)
    {
        dataGridView1.SelectAll();
    }
    //</Snippet180>
    
    //<Snippet190>
    private void dataGridView1_CellEnter(object sender, 
        DataGridViewCellEventArgs e)
    {
        dataGridView1[e.ColumnIndex, e.RowIndex].Style
            .SelectionBackColor = Color.Blue;
    }

    private void dataGridView1_CellLeave(object sender, 
        DataGridViewCellEventArgs e)
    {
        dataGridView1[e.ColumnIndex, e.RowIndex].Style
            .SelectionBackColor = Color.Empty;
    }
    //</Snippet190>

    //<Snippet200>
    private void dataGridView1_RowEnter(object sender, 
        DataGridViewCellEventArgs e)
    {
        for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
        {
            dataGridView1[i, e.RowIndex].Style.BackColor = Color.Yellow;
        }
    }

    private void dataGridView1_RowLeave(object sender, 
        DataGridViewCellEventArgs e)
    {
        for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
        {
            dataGridView1[i, e.RowIndex].Style.BackColor = Color.Empty;
        }
    }
    //</Snippet200>

    //<Snippet210>
    private void dataGridView1_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)
    {
        e.CellStyle.BackColor = Color.Aquamarine;
    }
    //</Snippet210>

    //<Snippet220>
    private void dataGridView1_CellBeginEdit(object sender,
        DataGridViewCellCancelEventArgs e)
    {
        string msg = String.Format("Editing Cell at ({0}, {1})",
            e.ColumnIndex, e.RowIndex);
        this.Text = msg;
    }

    private void dataGridView1_CellEndEdit(object sender,
        DataGridViewCellEventArgs e)
    {
        string msg = String.Format("Finished Editing Cell at ({0}, {1})",
            e.ColumnIndex, e.RowIndex);
        this.Text = msg;
    }
    //</Snippet220>

    private void DemonstrateIndexer()
    {
        //<Snippet230>
        // Retrieve the cell value for the cell at column 3, row 7.
        String testValue1 = (String)dataGridView1[3, 7].Value;
        
        // Retrieve the cell value for the cell in the Name column at row 4.
        String testValue2 = (String)dataGridView1["Name", 4].Value;
        //</Snippet230>
    }
}
