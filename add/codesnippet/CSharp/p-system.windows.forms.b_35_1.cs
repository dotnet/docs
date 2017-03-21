        public BindingSource bindingSource1 = new BindingSource();
        TextBox box1 = new TextBox();
      
        private void PopulateBindingSourceWithFonts()
        {
            bindingSource1.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.Add(new Font(FontFamily.Families[2], 8.0F));
            bindingSource1.Add(new Font(FontFamily.Families[4], 9.0F));
            bindingSource1.Add(new Font(FontFamily.Families[6], 10.0F));
            bindingSource1.Add(new Font(FontFamily.Families[8], 11.0F));
            bindingSource1.Add(new Font(FontFamily.Families[10], 12.0F));
            DataGridView view1 = new DataGridView();
            view1.DataSource = bindingSource1;
            view1.AutoGenerateColumns = true;
            view1.Dock = DockStyle.Top;
            this.Controls.Add(view1);
            box1.Dock = DockStyle.Bottom;
            box1.Text = "Sample Text";
            this.Controls.Add(box1);
            box1.DataBindings.Add("Text", bindingSource1, "Name");
            view1.Columns[7].DisplayIndex = 0;
            
        }

        void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            box1.Font = (Font)bindingSource1.Current;
        }