using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;


    // <Snippet1>
    public void CreateDataColumnMapping() 
    {
        DataColumnMapping mapping =
            new DataColumnMapping("Description","DataDescription");
    }
    // </Snippet1>

}
