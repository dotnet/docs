    protected void LinqDataSource_Inserted(object sender, LinqDataSourceStatusEventArgs e)
    {
        if (e.Exception == null)
        {
            Product newProduct = (Product)e.Result;
            Literal1.Text = "The new product id is " + newProduct.ProductID;
            Literal1.Visible = true;            
        }
        else
        {
            LogError(e.Exception.Message);
            Literal1.Text = "We are sorry. There was a problem saving the record. The administrator has been notified.";
            Literal1.Visible = true;
            e.ExceptionHandled = true;            
        }
    }