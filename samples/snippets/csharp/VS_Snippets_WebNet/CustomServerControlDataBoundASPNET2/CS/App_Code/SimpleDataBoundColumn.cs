// <Snippet1>
using System;
using System.Collections;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.Controls.CS
{
    [AspNetHostingPermission(SecurityAction.Demand,
       Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    // <Snippet2>
    public class SimpleDataBoundColumn : DataBoundControl
    {
        public string DataTextField
        {
            get
            {
                object o = ViewState["DataTextField"];
                return ((o == null) ? string.Empty : (string)o);
            }
            set
            {
                ViewState["DataTextField"] = value;
                if (Initialized)
                {
                    OnDataPropertyChanged();
                }
            }
        }
        // </Snippet2>

        // <Snippet3>
        protected override void PerformSelect()
        {
            // Call OnDataBinding here if bound to a data source using the
            // DataSource property (instead of a DataSourceID), because the
            // databinding statement is evaluated before the call to GetData.       
            if (!IsBoundUsingDataSourceID)
            {
                this.OnDataBinding(EventArgs.Empty);
            }

            // The GetData method retrieves the DataSourceView object from  
            // the IDataSource associated with the data-bound control.            
            GetData().Select(CreateDataSourceSelectArguments(),
                this.OnDataSourceViewSelectCallback);

            // The PerformDataBinding method has completed.
            RequiresDataBinding = false;
            MarkAsDataBound();

            // Raise the DataBound event.
            OnDataBound(EventArgs.Empty);
        }
        // </Snippet3>

        // <Snippet4>
        private void OnDataSourceViewSelectCallback(IEnumerable retrievedData)
        {
            // Call OnDataBinding only if it has not already been 
            // called in the PerformSelect method.
            if (IsBoundUsingDataSourceID)
            {
                OnDataBinding(EventArgs.Empty);
            }
            // The PerformDataBinding method binds the data in the  
            // retrievedData collection to elements of the data-bound control.
            PerformDataBinding(retrievedData);
        }
        // </Snippet4>

        // <Snippet5>
        protected override void PerformDataBinding(IEnumerable retrievedData)
        {
            base.PerformDataBinding(retrievedData);

            // Verify data exists.
            if (retrievedData != null)
            {
                Table tbl = new Table();
                TableRow row;
                TableCell cell;
                string dataStr = String.Empty;

                foreach (object dataItem in retrievedData)
                {
                    // If the DataTextField was specified get the data
                    // from that field, otherwise get the data from the first field. 
                    if (DataTextField.Length > 0)
                    {
                        dataStr = DataBinder.GetPropertyValue(dataItem,
                            DataTextField, null);
                    }
                    else
                    {
                        PropertyDescriptorCollection props =
                                TypeDescriptor.GetProperties(dataItem);
                        if (props.Count >= 1)
                        {
                            if (null != props[0].GetValue(dataItem))
                            {
                                dataStr = props[0].GetValue(dataItem).ToString();
                            }
                        }
                    }

                    row = new TableRow();
                    tbl.Rows.Add(row);
                    cell = new TableCell();
                    cell.Text = dataStr;
                    row.Cells.Add(cell);
                }

                this.Controls.Add(tbl); 
            }
        }
        // </Snippet5>
    }
}
// </Snippet1>
