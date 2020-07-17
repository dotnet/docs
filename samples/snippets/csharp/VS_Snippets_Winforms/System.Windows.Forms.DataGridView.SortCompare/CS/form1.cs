//<snippet00>
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion
class Form1 : Form
{
    private DataGridView dataGridView1 = new DataGridView();

    // Establish the main entry point for the application.
    [STAThreadAttribute()]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    public Form1()
    {
        // Initialize the form.
        // This code can be replaced with designer generated code.
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.SortCompare += new DataGridViewSortCompareEventHandler(
            this.dataGridView1_SortCompare);
        Controls.Add(this.dataGridView1);
        this.Text = "DataGridView.SortCompare demo";

        PopulateDataGridView();
    }

    //<snippet20>
    // Replace this with your own population code.
    public void PopulateDataGridView()
    {
        // Add columns to the DataGridView.
        dataGridView1.ColumnCount = 3;

        // Set the properties of the DataGridView columns.
        dataGridView1.Columns[0].Name = "ID";
        dataGridView1.Columns[1].Name = "Name";
        dataGridView1.Columns[2].Name = "City";
        dataGridView1.Columns["ID"].HeaderText = "ID";
        dataGridView1.Columns["Name"].HeaderText = "Name";
        dataGridView1.Columns["City"].HeaderText = "City";

        // Add rows of data to the DataGridView.
        dataGridView1.Rows.Add(new string[] { "1", "Parker", "Seattle" });
        dataGridView1.Rows.Add(new string[] { "2", "Parker", "New York" });
        dataGridView1.Rows.Add(new string[] { "3", "Watson", "Seattle" });
        dataGridView1.Rows.Add(new string[] { "4", "Jameson", "New Jersey" });
        dataGridView1.Rows.Add(new string[] { "5", "Brock", "New York" });
        dataGridView1.Rows.Add(new string[] { "6", "Conner", "Portland" });

        // Autosize the columns.
        dataGridView1.AutoResizeColumns();
    }
    //</snippet20>

    //<snippet10>
    private void dataGridView1_SortCompare(object sender,
        DataGridViewSortCompareEventArgs e)
    {
        // Try to sort based on the cells in the current column.
        e.SortResult = System.String.Compare(
            e.CellValue1.ToString(), e.CellValue2.ToString());

        // If the cells are equal, sort based on the ID column.
        if (e.SortResult == 0 && e.Column.Name != "ID")
        {
            e.SortResult = System.String.Compare(
                dataGridView1.Rows[e.RowIndex1].Cells["ID"].Value.ToString(),
                dataGridView1.Rows[e.RowIndex2].Cells["ID"].Value.ToString());
        }
        e.Handled = true;
    }
    //</snippet10>
}
//</snippet00>
