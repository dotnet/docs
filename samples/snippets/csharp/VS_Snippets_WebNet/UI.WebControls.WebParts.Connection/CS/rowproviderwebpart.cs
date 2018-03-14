//<SNIPPET1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//This sample code creates a Web Parts control that acts as a provider of row data.
namespace My 
{
    public sealed class RowProviderWebPart : WebPart, IWebPartRow 
	{

        private DataTable _table;

        public RowProviderWebPart() 
		{
            _table = new DataTable();

            DataColumn col = new DataColumn();
            col.DataType = typeof(string);
            col.ColumnName = "Name";
            _table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = typeof(string);
            col.ColumnName = "Address";
            _table.Columns.Add(col);

            col = new DataColumn();
            col.DataType = typeof(int);
            col.ColumnName = "ZIP Code";
            _table.Columns.Add(col);

            DataRow row = _table.NewRow();
            row["Name"] = "John Q. Public";
            row["Address"] = "123 Main Street";
            row["ZIP Code"] = 98000;
            _table.Rows.Add(row);
        }
		//<SNIPPET6>
        [ConnectionProvider("Row")]
        public IWebPartRow GetConnectionInterface()
		{
            return new RowProviderWebPart();
        }
		//</SNIPPET6>
		//<SNIPPET4>
        public PropertyDescriptorCollection Schema 
		{
            get {
                return TypeDescriptor.GetProperties(_table.DefaultView[0]);
				}
        }
		//</SNIPPET4>
		//<SNIPPET7>
		public void GetRowData(RowCallback callback)
		{
			callback(_table.Rows);
		}
		//</SNIPPET7>            
    }
}
//</SNIPPET1>

