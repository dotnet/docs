    protected void LinqDataSource_Inserting(object sender, LinqDataSourceInsertEventArgs e)
    {
        Product product = (Product)e.NewObject;
        product.DateModified = DateTime.Now;
    }