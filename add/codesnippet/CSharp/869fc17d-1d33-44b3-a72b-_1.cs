        // One-dimensional list for the grid data.
        ArrayList dataArray = new ArrayList();

        // Copy grid data to one-dimensional list, add row separators.
        protected override void PerformDataBinding(IEnumerable data)
        {
            IEnumerator dataSourceEnumerator = data.GetEnumerator();

            // Iterate through the table rows.
            while (dataSourceEnumerator.MoveNext())
            {
                // Add the next data row to the ArrayList.
                dataArray.AddRange(
                    ((DataRowView)dataSourceEnumerator.Current).Row.ItemArray);

                // Add a separator to the ArrayList.
                dataArray.Add("----------");
            }
        }

        // Render the data source as a one-dimensional list.
        protected override void RenderContents(
            System.Web.UI.HtmlTextWriter writer)
        {
            // Render the data list.
            for( int col=0; col<dataArray.Count;col++)
            {
                writer.Write(dataArray[col]);
                writer.WriteBreak();
            }
        }