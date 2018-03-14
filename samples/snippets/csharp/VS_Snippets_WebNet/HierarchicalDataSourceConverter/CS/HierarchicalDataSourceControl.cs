using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Samples.AspNet.CS.Controls
{
    //<Snippet1>
    [
    ToolboxData("<{0}:MyCustomHierarchicalControl runat=server> </{0}:MyCustomHierarchicalControl>")
    ] 
    public class MyCustomHierarchicalControl : TreeView 
	{        
        //<Snippet2>
        private object _dataSource;

        [TypeConverter(typeof(HierarchicalDataSourceConverter))]
        public override object DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                if (value != null) 
                {
                    ValidateDataSource(value);
                }
                _dataSource = value;
                OnDataPropertyChanged();
            }
        }
        //</Snippet2>

        // Define rest of custom control implementation.
        // ...

	}
    //</Snippet1>
}
