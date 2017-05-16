using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

class Form1 : Form
{
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private DataGridView dataGridView1 = new DataGridView();
    private Button selectedCellsButton = new Button();
    private Button selectedRowsButton = new Button();
    private Button selectedColumnsButton = new Button();

    protected override void OnLoad(EventArgs e)
    {
        this.dataGridView1.Dock = DockStyle.Fill;
        this.dataGridView1.ColumnCount = 5;
        this.dataGridView1.RowCount = 5;
        this.dataGridView1.ColumnHeaderMouseClick +=
            new DataGridViewCellMouseEventHandler(
            dataGridView1_ColumnHeaderMouseClick);
        this.dataGridView1.RowHeaderMouseClick +=
            new DataGridViewCellMouseEventHandler(
            dataGridView1_RowHeaderMouseClick);

        selectedCellsButton.AutoSize = true;
        selectedCellsButton.Text = "selected cells";
        selectedCellsButton.Click +=
            new EventHandler(selectedCellsButton_Click);
        selectedRowsButton.AutoSize = true;
        selectedRowsButton.Text = "selected rows";
        selectedRowsButton.Click +=
            new EventHandler(selectedRowsButton_Click);
        selectedColumnsButton.AutoSize = true;
        selectedColumnsButton.Text = "selected columns";
        selectedColumnsButton.Click +=
            new EventHandler(selectedColumnsButton_Click);

        FlowLayoutPanel panel = new FlowLayoutPanel();
        panel.Dock = DockStyle.Top;
        panel.AutoSize = true;
        panel.Controls.AddRange(new Control[] { 
            this.selectedCellsButton, this.selectedRowsButton,
            this.selectedColumnsButton });

        this.Controls.AddRange(new Control[] { dataGridView1, panel });
        this.Text = "DataGridView selected collections demo";

        base.OnLoad(e);
    }

    //<snippet05>
    void dataGridView1_ColumnHeaderMouseClick(
        object sender, DataGridViewCellMouseEventArgs e)
    {
        this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.ColumnHeaderSelect;
        this.dataGridView1.Columns[e.ColumnIndex].HeaderCell
            .SortGlyphDirection = SortOrder.None;
        this.dataGridView1.Columns[e.ColumnIndex].Selected = true;
    }

    void dataGridView1_RowHeaderMouseClick(
        object sender, DataGridViewCellMouseEventArgs e)
    {
        this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.RowHeaderSelect;
        this.dataGridView1.Rows[e.RowIndex].Selected = true;
    }
    //</snippet05>

    //<snippet10>
    private void selectedCellsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedCellCount =
            dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
        if (selectedCellCount > 0)
        {
            if (dataGridView1.AreAllCellsSelected(true))
            {
                MessageBox.Show("All cells are selected", "Selected Cells");
            }
            else
            {
                System.Text.StringBuilder sb =
                    new System.Text.StringBuilder();

                for (int i = 0;
                    i < selectedCellCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dataGridView1.SelectedCells[i].RowIndex
                        .ToString());
                    sb.Append(", Column: ");
                    sb.Append(dataGridView1.SelectedCells[i].ColumnIndex
                        .ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedCellCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Cells");
            }
        }
    }
    //</snippet10>

    //<snippet20>
    private void selectedRowsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedRowCount =
            dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
        if (selectedRowCount > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < selectedRowCount; i++)
            {
                sb.Append("Row: ");
                sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                sb.Append(Environment.NewLine);
            }

            sb.Append("Total: " + selectedRowCount.ToString());
            MessageBox.Show(sb.ToString(), "Selected Rows");
        }
    }
    //</snippet20>

    //<snippet30>
    private void selectedColumnsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedColumnCount = dataGridView1.Columns
            .GetColumnCount(DataGridViewElementStates.Selected);
        if (selectedColumnCount > 0)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < selectedColumnCount; i++)
            {
                sb.Append("Column: ");
                sb.Append(dataGridView1.SelectedColumns[i].Index
                    .ToString());
                sb.Append(Environment.NewLine);
            }

            sb.Append("Total: " + selectedColumnCount.ToString());
            MessageBox.Show(sb.ToString(), "Selected Columns");
        }
    }
    //</snippet30>

}
