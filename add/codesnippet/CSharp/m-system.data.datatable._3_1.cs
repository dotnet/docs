    private void ShowRejectChanges(DataTable table)
    {
        // Print the values of row 1, in the column named "CompanyName."
        Console.WriteLine(table.Rows[1]["CompanyName"]);

        // Make Changes to the column named "CompanyName."
        table.Rows[1]["CompanyName"] = "Taro";

        // Reject the changes.
        table.RejectChanges();

        // Print the original values:
        Console.WriteLine(table.Rows[1]["CompanyName"]);
    }