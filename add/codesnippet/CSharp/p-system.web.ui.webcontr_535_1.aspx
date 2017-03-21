    protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (IsOnlineSale)
        {
            e.SelectParameters.Add("Discount", OnlineDiscount);
        }
        else
        {
            e.SelectParameters.Add("Discount", 0);
        }
    }