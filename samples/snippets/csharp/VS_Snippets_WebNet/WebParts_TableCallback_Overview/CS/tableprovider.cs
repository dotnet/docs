//<Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//This sample code creates a Web Parts control that acts as a provider of table data.
namespace Samples.AspNet.CS.Controls
{
    public sealed class TableProviderWebPart : WebPart, IWebPartTable
    {
        DataTable _table;

        public TableProviderWebPart()
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

        public PropertyDescriptorCollection Schema
        {
            get
            {
                return TypeDescriptor.GetProperties(_table.DefaultView[0]);
            }
        }
        
        public void GetTableData(TableCallback callback)
        {
            callback(_table.Rows);
        }
        

        public bool ConnectionPointEnabled
        {
            get
            {
                object o = ViewState["ConnectionPointEnabled"];
                return (o != null) ? (bool)o : true;
            }
            set
            {
                ViewState["ConnectionPointEnabled"] = value;
            }
        }

        [ConnectionProvider("Table")]
        public IWebPartTable GetConnectionInterface()
        {
            return new TableProviderWebPart();
        }

        
        public class TableProviderConnectionPoint : ProviderConnectionPoint
        {
            public TableProviderConnectionPoint(MethodInfo callbackMethod, 
                Type interfaceType, Type controlType,
                string name, string id, bool allowsMultipleConnections)
                : base(callbackMethod, interfaceType, controlType,
                    name, id, allowsMultipleConnections)
            {
            }
            
            
            public override bool GetEnabled(Control control)
            {
                return ((TableProviderWebPart)control).ConnectionPointEnabled;
            }
            
        }
    }
}
//</Snippet1>