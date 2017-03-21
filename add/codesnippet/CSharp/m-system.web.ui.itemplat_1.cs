        // Override the ITemplate.InstantiateIn method to ensure 
        // that the templates are created in a Literal control and
        // that the Literal object's DataBinding event is associated
        // with the BindData method.
        public void InstantiateIn(Control container)
        {
            Literal l = new Literal();
            l.DataBinding += new EventHandler(this.BindData);
            container.Controls.Add(l);
        }
        // Create a public method that will handle the
        // DataBinding event called in the InstantiateIn method.
        public void BindData(object sender, EventArgs e)
        {
            Literal l = (Literal) sender;
            DataGridItem container = (DataGridItem) l.NamingContainer;
            l.Text = ((DataRowView) container.DataItem)[column].ToString();
    
        }