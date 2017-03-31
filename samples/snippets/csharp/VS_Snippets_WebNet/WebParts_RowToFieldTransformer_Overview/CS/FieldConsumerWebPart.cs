//<Snippet2>
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

namespace Samples.AspNet.CS.Controls
{
    
    // This sample code creates a Web Parts control that acts
    // as a consumer of an IField interface.

    // A consumer WebPart control that consumes strings.
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
                ViewState["ConnectionPointeEnabled"] = value;
            }
        }

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
        
        [ConnectionConsumer("Field")]
        public void SetConnectionInterface(IWebPartField provider)
        {
            _provider = provider;
        }

        private class FieldConsumerConnectionPoint : ConsumerConnectionPoint
        {
            public FieldConsumerConnectionPoint(MethodInfo callbackMethod, Type interfaceType, Type controlType,
                 string name, string id, bool allowsMultipleConnections)
                : base(callbackMethod, interfaceType, controlType,
                       name, id, allowsMultipleConnections)
            {
            }

            public override bool GetEnabled(Control control)
            {
                return ((FieldConsumerWebPart)control).ConnectionPointEnabled;
            }

        }
    }
}
//</Snippet2>
