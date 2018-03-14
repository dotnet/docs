using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateOracleParamColl(OracleCommand command) 
    {
        OracleParameterCollection paramCollection = command.Parameters;
        paramCollection.Add("pDName", OracleType.VarChar);
        paramCollection.Add("pLoc", OracleType.VarChar);
        string parameterNames = "";
        for (int i=0; i < paramCollection.Count; i++)
            parameterNames += paramCollection[i].ToString() + "\n";
        Console.WriteLine(parameterNames);
        paramCollection.Clear();
    }
    // </Snippet1>

}
