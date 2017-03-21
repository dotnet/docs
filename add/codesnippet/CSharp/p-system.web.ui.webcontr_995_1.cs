    protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        ExampleDataContext exampleContext = new ExampleDataContext();
        
        e.Result = from p in exampleContext.Products 
             where p.Category == "Beverages"
             select new {
               ID = p.ProductID,
               Name = p.Name
             };
    }