    protected void Reset_Click(object sender, EventArgs e)
    {
        ListDictionary keyValues = new ListDictionary();
        ListDictionary newValues = new ListDictionary();
        ListDictionary oldValues = new ListDictionary();

        keyValues.Add("ProductID", int.Parse(((Label)DetailsView1.FindControl("IDLabel")).Text));

        oldValues.Add("ProductName", ((Label)DetailsView1.FindControl("NameLabel")).Text);
        oldValues.Add("ProductCategory", ((Label)DetailsView1.FindControl("CategoryLabel")).Text);
        oldValues.Add("Color", ((Label)DetailsView1.FindControl("ColorLabel")).Text);

        newValues.Add("ProductName", "New Product");
        newValues.Add("ProductCategory", "General");
        newValues.Add("Color", "Not assigned");

        LinqDataSource1.Update(keyValues, newValues, oldValues);

        DetailsView1.DataBind();
    }