    protected void Add_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.ListDictionary listDictionary
            = new System.Collections.Specialized.ListDictionary();
        listDictionary.Add("ProductName", TextBox1.Text);
        listDictionary.Add("ProductCategory", "General");
        listDictionary.Add("Color", "Not assigned");
        listDictionary.Add("ListPrice", null);
        LinqDataSource1.Insert(listDictionary);

        TextBox1.Text = String.Empty;
        DetailsView1.DataBind();
    }