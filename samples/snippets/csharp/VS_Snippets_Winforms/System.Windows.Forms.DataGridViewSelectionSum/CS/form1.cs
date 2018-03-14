//<snippet00>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private DataGridView DataGridView1 = new DataGridView();
    private FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();
    private Label Label1 = new Label();
    private Label Label2 = new Label();
    private Label Label3 = new Label();
    private Label Label4 = new Label();

    // Establish the main entry point for the application.
    [STAThreadAttribute()]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        // Initialize the form.
        // This code can be replaced with designer generated code.
        AutoSize = true;

        // Set the FlowLayoutPanel1 properties.
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        FlowLayoutPanel1.Location = new System.Drawing.Point(354, 0);
        FlowLayoutPanel1.AutoSize = true;
        FlowLayoutPanel1.Controls.Add(Label1);
        FlowLayoutPanel1.Controls.Add(Label2);
        FlowLayoutPanel1.Controls.Add(Label3);
        FlowLayoutPanel1.Controls.Add(Label4);

        Controls.Add(FlowLayoutPanel1);
        Controls.Add(DataGridView1);

        // Set the Label properties.
        Label1.AutoSize = true;
        Label2.AutoSize = true;
        Label3.AutoSize = true;
    }

    protected override void OnLoad(EventArgs e)
    {
        PopulateDataGridView();
        UpdateLabelText();
        UpdateBalance();

        DataGridView1.CellValidating += new
            DataGridViewCellValidatingEventHandler(
            DataGridView1_CellValidating);
        DataGridView1.CellValidated += new DataGridViewCellEventHandler(
            DataGridView1_CellValidated);
        DataGridView1.CellValueChanged += new DataGridViewCellEventHandler(
            DataGridView1_CellValueChanged);
        DataGridView1.RowsRemoved += new DataGridViewRowsRemovedEventHandler(
            DataGridView1_RowsRemoved);
        DataGridView1.SelectionChanged += new EventHandler(
            DataGridView1_SelectionChanged);
        DataGridView1.UserAddedRow += new DataGridViewRowEventHandler(
            DataGridView1_UserAddedRow);
        DataGridView1.UserDeletingRow += new
            DataGridViewRowCancelEventHandler(DataGridView1_UserDeletingRow);

        base.OnLoad(e);
    }

    // Replace this with your own code to populate the DataGridView.
    private void PopulateDataGridView()
    {
        DataGridView1.Size = new Size(350, 400);
        DataGridView1.AllowUserToDeleteRows = true;

        // Add columns to the DataGridView.
        DataGridView1.ColumnCount = 4;
        DataGridView1.SelectionMode =
            DataGridViewSelectionMode.RowHeaderSelect;

        // Set the properties of the DataGridView columns.
        DataGridView1.Columns[0].Name = "Description";
        DataGridView1.Columns[1].Name = "Withdrawals";
        DataGridView1.Columns[2].Name = "Deposits";
        DataGridView1.Columns[3].Name = "Balance";
        DataGridView1.Columns["Description"].HeaderText = "Description";
        DataGridView1.Columns["Withdrawals"].HeaderText = "W(-)";
        DataGridView1.Columns["Deposits"].HeaderText = "D(+)";
        DataGridView1.Columns["Balance"].HeaderText = "Balance";
        DataGridView1.Columns["Balance"].ReadOnly = true;
        DataGridView1.Columns["Description"].SortMode =
            DataGridViewColumnSortMode.NotSortable;
        DataGridView1.Columns["Withdrawals"].SortMode =
            DataGridViewColumnSortMode.NotSortable;
        DataGridView1.Columns["Deposits"].SortMode =
            DataGridViewColumnSortMode.NotSortable;
        DataGridView1.Columns["Balance"].SortMode =
            DataGridViewColumnSortMode.NotSortable;

        // Add rows of data to the DataGridView.
        DataGridView1.Rows.Add(new string[] {
            "Starting Balance", "", "", "1000" });
        DataGridView1.Rows.Add(new string[] {
            "Paycheck Deposit", "", "850", "" });
        DataGridView1.Rows.Add(new string[] { "Rent", "-500", "", "" });
        DataGridView1.Rows.Add(new string[] { "Groceries", "-25", "", "" });
        DataGridView1.Rows.Add(new string[] { "Tax Return", "", "300", "" });


        // Allow the user to edit the starting balance cell
        DataGridView1.Rows[0].ReadOnly = true;
        DataGridView1.Rows[0].Cells["Balance"].ReadOnly = false;

        // Autosize the columns.
        DataGridView1.AutoResizeColumns();
    }

    //<snippet30>
    private void DataGridView1_CellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        // Update the balance column whenever the value of any cell changes.
        UpdateBalance();
    }

    private void DataGridView1_RowsRemoved(
        object sender, DataGridViewRowsRemovedEventArgs e)
    {
        // Update the balance column whenever rows are deleted.
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        int counter;
        int balance;
        int deposit;
        int withdrawal;

        // Iterate through the rows, skipping the Starting Balance row.
        for (counter = 1; counter < (DataGridView1.Rows.Count - 1);
            counter++)
        {
            deposit = 0;
            withdrawal = 0;
            balance = int.Parse(DataGridView1.Rows[counter - 1]
                .Cells["Balance"].Value.ToString());

            if (DataGridView1.Rows[counter].Cells["Deposits"].Value != null)
            {
                // Verify that the cell value is not an empty string.
                if (DataGridView1.Rows[counter]
                    .Cells["Deposits"].Value.ToString().Length != 0)
                {
                    deposit = int.Parse(DataGridView1.Rows[counter]
                        .Cells["Deposits"].Value.ToString());
                }
            }

            if (DataGridView1.Rows[counter].Cells["Withdrawals"].Value != null)
            {
                if (DataGridView1.Rows[counter]
                    .Cells["Withdrawals"].Value.ToString().Length != 0)
                {
                    withdrawal = int.Parse(DataGridView1.Rows[counter]
                        .Cells["Withdrawals"].Value.ToString());
                }
            }
            DataGridView1.Rows[counter].Cells["Balance"].Value =
                (balance + deposit + withdrawal).ToString();
        }
    }
    //</snippet30>

    private void DataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        // Update the labels to reflect changes to the selection.
        UpdateLabelText();
    }

    //<snippet40>
    private void DataGridView1_UserAddedRow(
        object sender, DataGridViewRowEventArgs e)
    {
        // Update the labels to reflect changes to the number of entries.
        UpdateLabelText();
    }

    //<snippet10>
    private void UpdateLabelText()
    {
        int WithdrawalTotal = 0;
        int DepositTotal = 0;
        int SelectedCellTotal = 0;
        int counter;

        // Iterate through all the rows and sum up the appropriate columns.
        for (counter = 0; counter < (DataGridView1.Rows.Count);
            counter++)
        {
            if (DataGridView1.Rows[counter].Cells["Withdrawals"].Value
                != null)
            {
                if (DataGridView1.Rows[counter].
                    Cells["Withdrawals"].Value.ToString().Length != 0)
                {
                    WithdrawalTotal += int.Parse(DataGridView1.Rows[counter].
                        Cells["Withdrawals"].Value.ToString());
                }
            }

            if (DataGridView1.Rows[counter].Cells["Deposits"].Value != null)
            {
                if (DataGridView1.Rows[counter]
                    .Cells["Deposits"].Value.ToString().Length != 0)
                {
                    DepositTotal += int.Parse(DataGridView1.Rows[counter]
                        .Cells["Deposits"].Value.ToString());
                }
            }
        }

        // Iterate through the SelectedCells collection and sum up the values.
        for (counter = 0;
            counter < (DataGridView1.SelectedCells.Count); counter++)
        {
            if (DataGridView1.SelectedCells[counter].FormattedValueType ==
                Type.GetType("System.String"))
            {
                string value = null;

                // If the cell contains a value that has not been commited,
                // use the modified value.
                if (DataGridView1.IsCurrentCellDirty == true)
                {

                    value = DataGridView1.SelectedCells[counter]
                        .EditedFormattedValue.ToString();
                }
                else
                {
                    value = DataGridView1.SelectedCells[counter]
                        .FormattedValue.ToString();
                }
                if (value != null)
                {
                    // Ignore cells in the Description column.
                    if (DataGridView1.SelectedCells[counter].ColumnIndex !=
                        DataGridView1.Columns["Description"].Index)
                    {
                        if (value.Length != 0)
                        {
                            SelectedCellTotal += int.Parse(value);
                        }
                    }
                }
            }
        }

        // Set the labels to reflect the current state of the DataGridView.
        Label1.Text = "Withdrawals Total: " + WithdrawalTotal.ToString();
        Label2.Text = "Deposits Total: " + DepositTotal.ToString();
        Label3.Text = "Selected Cells Total: " + SelectedCellTotal.ToString();
        Label4.Text = "Total entries: " + DataGridView1.RowCount.ToString();
    }
    //</snippet10>
    //</snippet40>

    private void DataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
    {
        int testint;

        if (e.ColumnIndex != 0)
        {
            if (e.FormattedValue.ToString().Length != 0)
            {
                // Try to convert the cell value to an int.
                if (!int.TryParse(e.FormattedValue.ToString(), out testint))
                {
                    DataGridView1.Rows[e.RowIndex].ErrorText =
                        "Error: Invalid entry";
                    e.Cancel = true;
                }
            }
        }
    }

    //<snippet50>
    private void DataGridView1_CellValidated(object sender,
        DataGridViewCellEventArgs e)
    {
        // Clear any error messages that may have been set in cell validation.
        DataGridView1.Rows[e.RowIndex].ErrorText = null;
    }
    //</snippet50>

    //<snippet20>
    private void DataGridView1_UserDeletingRow(object sender,
        DataGridViewRowCancelEventArgs e)
    {
        DataGridViewRow startingBalanceRow = DataGridView1.Rows[0];

        // Check if the Starting Balance row is included in the selected rows
        if (DataGridView1.SelectedRows.Contains(startingBalanceRow))
        {
            // Do not allow the user to delete the Starting Balance row.
            MessageBox.Show("Cannot delete Starting Balance row!");

            // Cancel the deletion if the Starting Balance row is included.
            e.Cancel = true;
        }
    }
    //</snippet20>

}
//</snippet00>