using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
// <Snippet2>
namespace Samples.AspNet.CS.Controls
{
    //<Snippet5>
    // An interface that the transformer provides to the consumer.
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    public interface IString
    {
        void GetStringValue(StringCallback callback);
    }
    //</Snippet5>

    // A callback method to retrieve the string value.
    public delegate void StringCallback(string stringValue);

    // A provider WebPart control that provides a row of data.
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
            col.ColumnName = "Zip Code";
            _table.Columns.Add(col);

            DataRow row = _table.NewRow();
            row["Name"] = "John Q. Public";
            row["Address"] = "123 Main Street";
            row["Zip Code"] = 98000;
            _table.Rows.Add(row);
        }

        private object RowData
        {
            get
            {
                return _table.DefaultView[0];
            }
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

        protected override void RenderContents(HtmlTextWriter writer)
        {
            PropertyDescriptorCollection props = ((IWebPartRow)this).Schema;
            foreach (PropertyDescriptor prop in props)
            {
                writer.Write(prop.DisplayName + ": " + prop.GetValue(RowData));
                writer.WriteBreak();
                writer.WriteLine();
            }
        }

        [ConnectionProvider("Row", typeof(RowProviderConnectionPoint))]
        public IWebPartRow GetConnectionInterface()
        {
            return this;
        }

        PropertyDescriptorCollection IWebPartRow.Schema
        {
            get
            {
                return TypeDescriptor.GetProperties(RowData);
            }
        }

        void IWebPartRow.GetRowData(RowCallback callback)
        {
            callback(RowData);
        }

        public class RowProviderConnectionPoint : ProviderConnectionPoint
        {
            public RowProviderConnectionPoint(MethodInfo callbackMethod, Type interfaceType, Type controlType,
                                                 string name, string id, bool allowsMultipleConnections)
                : base(
                                                     callbackMethod, interfaceType, controlType,
                                                     name, id, allowsMultipleConnections)
            {
            }

            public override bool GetEnabled(Control control)
            {
                return ((RowProviderWebPart)control).ConnectionPointEnabled;
            }
        }
    }

    //<Snippet4>
    // A transformer that transforms a row to a string.
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [WebPartTransformer(typeof(IWebPartRow), typeof(IString))]
    public class RowToStringTransformer : WebPartTransformer, IString
    {

        private IWebPartRow _provider;
        private StringCallback _callback;

        private void GetRowData(object rowData)
        {
            PropertyDescriptorCollection props = _provider.Schema;
            if (props != null && props.Count > 0 && rowData != null)
            {
                string returnValue = String.Empty;
                foreach (PropertyDescriptor prop in props)
                {
                    if (prop != props[0])
                    {
                        returnValue += ", ";
                    }
                    returnValue += prop.DisplayName + ": " + prop.GetValue(rowData);
                }
                _callback(returnValue);
            }
            else
            {
                _callback(null);
            }
        }
        
        // <Snippet3>
        public override object Transform(object providerData)
        {
            _provider = (IWebPartRow)providerData;
            return this;
        }
        // </Snippet3>

        void IString.GetStringValue(StringCallback callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            if (_provider != null)
            {
                _callback = callback;
                _provider.GetRowData(new RowCallback(GetRowData));
            }
            else
            {
                callback(null);
            }
        }
    }
    //</Snippet4>

    // A consumer WebPart control that consumes strings.
    [AspNetHostingPermission(SecurityAction.Demand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
      Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class StringConsumerWebPart : WebPart
    {

        private IString _provider;
        private string _stringValue;

        private void GetStringValue(string stringValue)
        {
            _stringValue = stringValue;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_provider != null)
            {
                _provider.GetStringValue(new StringCallback(GetStringValue));
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (_provider != null)
            {
                if (_stringValue != null && _stringValue.Length > 0)
                {
                    writer.Write(_stringValue);
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

        [ConnectionConsumer("String")]
        public void SetConnectionInterface(IString provider)
        {
            _provider = provider;
        }
    }
}
// </Snippet2>


