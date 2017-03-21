        private void InitializeControlsAndData()
        {
            // Initialize the controls and set location, size and 
            // other basic properties.
            this.dataGridView1 = new DataGridView();
            
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.Top;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Size = new Size(292, 150);
            this.textBox1.Location = new Point(132, 156);
            this.textBox1.Size = new Size(100, 20);
            this.textBox2.Location = new Point(12, 156);
            this.textBox2.Size = new Size(100, 20);
            this.ClientSize = new Size(292, 266);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);

            // Declare the DataSet and add a table and column.
            DataSet set1 = new DataSet();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            
            // Add the control data bindings.
            dataGridView1.DataSource = set1;
            dataGridView1.DataMember = "Menu";
            textBox1.DataBindings.Add("Text", set1,
                "Menu.Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", set1,
                "Menu.Beverages", true, DataSourceUpdateMode.OnPropertyChanged);

            BindingManagerBase bmb = this.BindingContext[set1, "Menu"];
            bmb.BindingComplete += new BindingCompleteEventHandler(bmb_BindingComplete);
          
        }

        private void bmb_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occured.
            if (e.BindingCompleteContext ==
                BindingCompleteContext.DataSourceUpdate && e.Exception == null)

                // If not, end the current edit.
                e.Binding.BindingManagerBase.EndCurrentEdit(); ;
        }