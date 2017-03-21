private void WriteMappingNames(){
    foreach(DataGridTableStyle dgt in myDataGrid.TableStyles)
    {
        Console.WriteLine(dgt.MappingName);
        foreach(DataGridColumnStyle dgc in dgt.GridColumnStyles)
        {
            Console.WriteLine(dgc.MappingName);
        }
    }
}