        private void PopulateDataViewAndAdvancedSort()
        {
            DataSet set1 = new DataSet();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>U2</artist><cd>Joshua Tree</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new StringReader(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new DataView(tables[0]);

            // Create a DataGridView control and add it to the form.
            DataGridView datagridview1 = new DataGridView();
            datagridview1.AutoGenerateColumns = true;
            this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new BindingSource();
            source1.DataSource = view1;

            // Set the data source for the DataGridView.
            datagridview1.DataSource = source1;

            source1.Sort = "artist ASC, cd ASC";
        }