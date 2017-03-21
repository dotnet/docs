    void dataGridView1_CellToolTipTextNeeded(object sender,
        DataGridViewCellToolTipTextNeededEventArgs e)
    {
        string newLine = Environment.NewLine;
        if (e.RowIndex > -1)
        {
            DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

            // Add the employee's ID to the ToolTipText.
            e.ToolTipText = String.Format("EmployeeID {0}:{1}",
                dataGridViewRow1.Cells["EmployeeID"].Value, newLine);

            // Add the employee's name to the ToolTipText.
            e.ToolTipText += String.Format("{0} {1} {2}{3}",
                dataGridViewRow1.Cells["TitleOfCourtesy"].Value.ToString(),
                dataGridViewRow1.Cells["FirstName"].Value.ToString(),
                dataGridViewRow1.Cells["LastName"].Value.ToString(),
                newLine);

            // Add the employee's title to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}",
                dataGridViewRow1.Cells["Title"].Value.ToString(),
                newLine, newLine);

            // Add the employee's contact information to the ToolTipText.
            e.ToolTipText += String.Format("{0}{1}{2}, ",
                dataGridViewRow1.Cells["Address"].Value.ToString(), newLine,
                dataGridViewRow1.Cells["City"].Value.ToString());
            if (!String.IsNullOrEmpty(
                dataGridViewRow1.Cells["Region"].Value.ToString()))
            {
                e.ToolTipText += String.Format("{0}, ",
                    dataGridViewRow1.Cells["Region"].Value.ToString());
            }
            e.ToolTipText += String.Format("{0}, {1}{2}{3} EXT:{4}{5}{6}",
                dataGridViewRow1.Cells["Country"].Value.ToString(),
                dataGridViewRow1.Cells["PostalCode"].Value.ToString(),
                newLine, dataGridViewRow1.Cells["HomePhone"].Value.ToString(),
                dataGridViewRow1.Cells["Extension"].Value.ToString(),
                newLine, newLine);

            // Add employee information to the ToolTipText.
            DateTime HireDate =
                (DateTime)dataGridViewRow1.Cells["HireDate"].Value;
            e.ToolTipText +=
                String.Format("Employee since: {0}/{1}/{2}{3}Manager: {4}",
                HireDate.Month.ToString(), HireDate.Day.ToString(),
                HireDate.Year.ToString(), newLine,
                dataGridViewRow1.Cells["Manager"].Value.ToString());
        }
    }