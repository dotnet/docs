    protected void CheckReorderStatus()
    {
        DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        int reorderedProducts = (int)dv.Table.Rows[0][0];
        if (reorderedProducts > 0)
        {
            Label1.Text = "Number of products on reorder: " + reorderedProducts;
        }
        else
        {
            Label1.Text = "No products on reorder.";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckReorderStatus();
    }