//<SNIPPET2>
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  // This sample code creates a Web Parts control that acts as a provider 
  // of table data.
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
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

		[ConnectionProvider("Table", typeof(TableProviderConnectionPoint), 
      AllowsMultipleConnections = true)]
		public IWebPartTable GetConnectionInterface()
		{
			return new TableProviderWebPart();
		}

		public class TableProviderConnectionPoint : ProviderConnectionPoint
		{
			public TableProviderConnectionPoint(MethodInfo callbackMethod, 
        Type interfaceType, Type controlType, string name, string id, 
        bool allowsMultipleConnections) 
        : base(callbackMethod, interfaceType, controlType, name, id, 
          allowsMultipleConnections)
			{
			}

			public override bool GetEnabled(Control control)
			{
				return ((TableProviderWebPart)control).ConnectionPointEnabled;
			}

		}

	}


  // This code sample creates a Web Parts control that acts as a consumer 
  // of information provided by the TableProvider.ascx control.
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class TableConsumer : WebPart
  {
    private IWebPartTable _provider;
    private ICollection _tableData;

    private void GetTableData(object tableData)
    {
      _tableData = (ICollection)tableData;
    }

    protected override void OnPreRender(EventArgs e)
    {
      if (_provider != null)
      {
        _provider.GetTableData(new TableCallback(GetTableData));
      }
    }

    protected override void RenderContents(HtmlTextWriter writer)
    {
      if (_provider != null)
      {
        PropertyDescriptorCollection props = _provider.Schema;
        int count = 0;
        if (props != null && props.Count > 0 && _tableData != null)
        {
          foreach (PropertyDescriptor prop in props)
          {
            foreach (DataRow o in _tableData)
            {
              writer.Write(prop.DisplayName + ": " + o[count]);
            }
            writer.WriteBreak();
            writer.WriteLine();
            count = count + 1;
          }
        }
        else
        {
          writer.Write("No data");
        }
      }
      else
      {
        writer.Write("Not connected");
      }
    }

    [ConnectionConsumer("Table")]
    public void SetConnectionInterface(IWebPartTable provider)
    {
      _provider = provider;
    }

    public class TableConsumerConnectionPoint : ConsumerConnectionPoint
    {
      public TableConsumerConnectionPoint(MethodInfo callbackMethod,
        Type interfaceType, Type controlType, string name, string id,
        bool allowsMultipleConnections)
        : base(callbackMethod, interfaceType, controlType, name, id,
        allowsMultipleConnections)
      {
      }

    } // TableConsumerConnectionPoint

  } // TableConsumer

} // Samples.AspNet.CS.Controls
//</SNIPPET2>