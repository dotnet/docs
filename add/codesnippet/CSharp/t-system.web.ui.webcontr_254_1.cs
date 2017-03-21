    protected void LinqDataSource_Deleting(object sender, LinqDataSourceDeleteEventArgs e)
    {
        Product product = (Product)e.OriginalObject;
        if (product.OnSale && !confirmCheckBox.Checked)
        {
            e.Cancel = true;
        }
    }