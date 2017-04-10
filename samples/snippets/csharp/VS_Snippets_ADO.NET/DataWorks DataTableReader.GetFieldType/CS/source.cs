using System;
using System.Data;
class DataTableReaderPrintCol
{
    [STAThread]
    static void Main()
    {
    }
    // <Snippet1>
    private void TestGetFieldType(DataTableReader reader)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            Console.WriteLine(reader.GetName(i) + ":" + 
                reader.GetFieldType(i).FullName);
        }
    }
    // </Snippet1>
}

