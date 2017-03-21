    protected void LinqDataSource_Updating(object sender, LinqDataSourceUpdateEventArgs e)
    {
        Product originalProduct = (Product)e.OriginalObject;
        Product newProduct = (Product)e.NewObject;

        if (originalProduct.Category != newProduct.Category)
        {
            newProduct.CategoryChanged = true;
        }
    }