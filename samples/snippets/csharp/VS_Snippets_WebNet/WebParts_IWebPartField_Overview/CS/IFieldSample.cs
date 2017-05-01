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
  // of field data.
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public sealed class FieldProviderWebPart : WebPart, IWebPartField
  {
    private DataTable _table;

    public FieldProviderWebPart() 
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

 	  [ConnectionProvider("FieldProvider")]
	  public IWebPartField GetConnectionInterface()
    {
        return new FieldProviderWebPart();
    }

    public PropertyDescriptor Schema 
    {
        get 
        {
            /* The two parameters are row and field. Zero is the first record. 
                0,2 returns the zip code field value.   */ 
            return TypeDescriptor.GetProperties(_table.DefaultView[0])[2];
        }
    }

    //<SNIPPET3>
	  void IWebPartField.GetFieldValue(FieldCallback callback) 
    {
        callback(Schema.GetValue(_table.DefaultView[0]));
    }
    //</SNIPPET3>

  } // end FieldProviderWebPart

  // This sample code creates a Web Parts control that acts as a consumer 
  // of an IWebPartField interface.
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class FieldConsumerWebPart : WebPart
  {

    private IWebPartField _provider;
    private object _fieldValue;

    private void GetFieldValue(object fieldValue)
    {
      _fieldValue = fieldValue;
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

    //<SNIPPET4>
    protected override void OnPreRender(EventArgs e)
    {
      if (_provider != null)
      {
        _provider.GetFieldValue(new FieldCallback(GetFieldValue));
      }
      base.OnPreRender(e);
    }

    protected override void RenderContents(HtmlTextWriter writer)
    {

      if (_provider != null)
      {
        PropertyDescriptor prop = _provider.Schema;

        if (prop != null && _fieldValue != null)
        {
          writer.Write(prop.DisplayName + ": " + _fieldValue);
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
    //</SNIPPET4>

    [ConnectionConsumer("FieldConsumer", "Connpoint1", 
      typeof(FieldConsumerConnectionPoint), AllowsMultipleConnections = true)]
    public void SetConnectionInterface(IWebPartField provider)
    {
      _provider = provider;
    }

    public class FieldConsumerConnectionPoint : ConsumerConnectionPoint
    {
      public FieldConsumerConnectionPoint(MethodInfo callbackMethod, 
        Type interfaceType, Type controlType, string name, string id, 
        bool allowsMultipleConnections)
        : base(
        callbackMethod, interfaceType, controlType,
        name, id, allowsMultipleConnections)
      {
      }

      public override bool GetEnabled(Control control)
      {
        return ((FieldConsumerWebPart)control).ConnectionPointEnabled;
      }
    } // end FieldConsumerConnectionPoint

  } // end FieldConsumerWebPart

} // end namespace Samples.AspNet.CS.Controls
//</SNIPPET2>