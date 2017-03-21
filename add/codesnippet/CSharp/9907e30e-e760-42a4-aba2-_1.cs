        // Get data from the underlying data source.
        // Build and return a DataView, regardless of mode.
        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments selectArgs) {
            IEnumerable dataList = null;
            // Open the .csv file.
            if (File.Exists(this.SourceFile)) {
                DataTable data = new DataTable();

                // Open the file to read from.
                using (StreamReader sr = File.OpenText(this.SourceFile)) {
                    // Parse the line
                    string s = "";
                    string[] dataValues;
                    DataColumn col;

                    // Do the following to add schema.
                    dataValues = sr.ReadLine().Split(',');
                    // For each token in the comma-delimited string, add a column
                    // to the DataTable schema.
                    foreach (string token in dataValues) {
                        col = new DataColumn(token,typeof(string));
                        data.Columns.Add(col);
                    }

                    // Do not add the first row as data if the CSV file includes column names.
                    if (! IncludesColumnNames)
                        data.Rows.Add(CopyRowData(dataValues, data.NewRow()));

                    // Do the following to add data.
                    while ((s = sr.ReadLine()) != null) {
                        dataValues = s.Split(',');
                        data.Rows.Add(CopyRowData(dataValues, data.NewRow()));
                    }
                }
                data.AcceptChanges();
                DataView dataView = new DataView(data);
                if (selectArgs.SortExpression != String.Empty) {
                    dataView.Sort = selectArgs.SortExpression;
                }
                dataList = dataView;
            }
            else {
                throw new System.Configuration.ConfigurationErrorsException("File not found, " + this.SourceFile);
            }

            if (null == dataList) {
                throw new InvalidOperationException("No data loaded from data source.");
            }

            return dataList;
        }

        private DataRow CopyRowData(string[] source, DataRow target) {
            try {
                for (int i = 0;i < source.Length;i++) {
                    target[i] = source[i];
                }
            }
            catch (System.IndexOutOfRangeException) {
                // There are more columns in this row than
                // the original schema allows.  Stop copying
                // and return the DataRow.
                return target;
            }
            return target;
        }