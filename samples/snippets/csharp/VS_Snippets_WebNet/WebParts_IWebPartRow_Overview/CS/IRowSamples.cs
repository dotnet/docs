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
  // of row data.
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
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

    [ConnectionProvider("Row")]
    public IWebPartRow GetConnectionInterface()
		{
      return new RowProviderWebPart();
    }

    public PropertyDescriptorCollection Schema 
		{
      get 
      {
        return TypeDescriptor.GetProperties(_table.DefaultView[0]);
			}
    }

		public void GetRowData(RowCallback callback)
		{
			callback(_table.Rows);
		}

  } // RowProviderWebPart


  // This sample code creates a Web Parts control that acts as a consumer 
  // of row data.
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]  
  public sealed class RowConsumerWebPart : WebPart 
  {
    private IWebPartRow _provider;
		private ICollection _tableData;
	
		private void GetRowData(object rowData)
		{
			_tableData = (ICollection)rowData;
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (_provider != null)
			{
				_provider.GetRowData(new RowCallback(GetRowData));
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
					      writer.WriteBreak();
					      writer.WriteLine();
					      count = count + 1;
				      }
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

    [ConnectionConsumer("Row")]
    public void SetConnectionInterface(IWebPartRow provider) 
		{
      _provider = provider;
    }

  } // RowConsumerWebPart
    
} // Samples.AspNet.CS.Controls 

//</SNIPPET2>

