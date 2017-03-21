public void AddSqlParameters() 
{
// ...
// create categoriesDataSet and categoriesAdapter
// ...

  categoriesAdapter.SelectCommand.Parameters.Add(
    "@CategoryName", SqlDbType.VarChar, 80).Value = "toasters";
  categoriesAdapter.SelectCommand.Parameters.Add(
    "@SerialNum", SqlDbType.Int).Value = 239;
  categoriesAdapter.Fill(categoriesDataSet);

}