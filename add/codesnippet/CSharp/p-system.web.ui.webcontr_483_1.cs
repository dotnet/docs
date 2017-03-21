    protected void LinqDataSource_ContextCreating(object sender, LinqDataSourceContextEventArgs e)
    {
        e.ObjectInstance = new ExampleDataContext(ConfigurationManager.ConnectionStrings["ExampleConnectionString"].ConnectionString);
    }