using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateDataTableMapping() 
    {
        DataTableMapping mapping = new DataTableMapping();
        mapping.SourceTable = "Categories";
        mapping.DataSetTable = "DataCategories";
    }
    // </Snippet1>

}
