    private void SetProperty(DataColumn column)
    {
        column.ExtendedProperties.Add("TimeStamp", DateTime.Now);
    }
 
    private void GetProperty(DataColumn column)
    {
        Console.WriteLine(column.ExtendedProperties["TimeStamp"].ToString());
    }