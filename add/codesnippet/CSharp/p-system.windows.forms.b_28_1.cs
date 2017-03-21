private void GetDataSource()
{
   DataSet ds = (DataSet) text1.DataBindings[0].DataSource;
   Console.WriteLine(ds.Tables[0].TableName); 
}
