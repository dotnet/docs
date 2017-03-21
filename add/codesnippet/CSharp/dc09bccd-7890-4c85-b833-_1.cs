    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // If the column is the Artist column, check the
        // value.
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Artist")
        {
            if (e.Value != null)
            {
                // Check for the string "pink" in the cell.
                string stringValue = (string)e.Value;
                stringValue = stringValue.ToLower();
                if ((stringValue.IndexOf("pink") > -1))
                {
                    e.CellStyle.BackColor = Color.Pink;
                }

            }
        }
        else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
        {
            ShortFormDateFormat(e);
        }
    }

    //Even though the date internaly stores the year as YYYY, using formatting, the
    //UI can have the format in YY.  
    private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
    {
        if (formatting.Value != null)
        {
            try
            {
                System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                DateTime theDate = DateTime.Parse(formatting.Value.ToString());

                dateString.Append(theDate.Month);
                dateString.Append("/");
                dateString.Append(theDate.Day);
                dateString.Append("/");
                dateString.Append(theDate.Year.ToString().Substring(2));
                formatting.Value = dateString.ToString();
                formatting.FormattingApplied = true;
            }
            catch (FormatException)
            {
                // Set to false in case there are other handlers interested trying to
                // format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = false;
            }
        }
    }