// <Snippet1>
using System;
using System.Web;
using System.Web.UI;

namespace TemplateControlSamples {

    public class TemplateItem : Control, INamingContainer {
        private String     _message         = null;

        public TemplateItem(String message) {
            _message = message;
        }

        public String Message {

           get {
              return _message;
           }
           set {
              _message = value;
           }
        }
    }

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    [ParseChildren(true)]
    public class Template1 : Control, INamingContainer {

        private ITemplate  _messageTemplate = null;
        private String     _message         = null;

        public String Message {

           get {
              return _message;
           }
           set {
              _message = value;
           }
        }

        [
            PersistenceMode(PersistenceMode.InnerProperty),
            TemplateContainer(typeof(TemplateItem))
        ]
        public ITemplate MessageTemplate {
           get {
              return _messageTemplate;
           }
           set {
              _messageTemplate = value;
           }
        }

        protected override void CreateChildControls() {

           // If a template has been specified, use it to create children.
           // Otherwise, create a single LiteralControl with the message value.

           if (MessageTemplate != null) {
              Controls.Clear();
              TemplateItem i = new TemplateItem(this.Message);
              MessageTemplate.InstantiateIn(i);
              Controls.Add(i);
           }
           else {
              this.Controls.Add(new LiteralControl(this.Message));
           }
        }
    }
}
   
// </Snippet1>
