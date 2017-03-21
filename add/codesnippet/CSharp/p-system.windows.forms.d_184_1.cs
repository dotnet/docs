private void PrintReadOnlyValues()
{
    foreach(DataGridTableStyle tableStyle in dataGrid1.TableStyles)
    {
      Console.WriteLine(tableStyle.ReadOnly);
    }
}
