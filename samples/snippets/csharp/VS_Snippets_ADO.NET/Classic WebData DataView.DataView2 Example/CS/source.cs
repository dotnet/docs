using System;
using System.Data;

public class Sample
{
    // <Snippet1>
    private void MakeDataView(DataSet dataSet)
    {
        DataView view = new DataView(dataSet.Tables["Suppliers"], 
            "Country = 'UK'", "CompanyName", 
            DataViewRowState.CurrentRows);
        view.AllowEdit = true;
        view.AllowNew = true;
        view.AllowDelete = true;
    }
    // </Snippet1>

}
