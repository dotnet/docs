/* 
System.Web.UI.PersistenceMode.Attribute;System.Web.UI.PersistenceMode.InnerProperty;
System.Web.UI.PersistenceMode.InnerDefaultProperty;

The following example demonstrates the attribute 'PersistenceModeAttribute' and members 'Attribute','InnerProperty'
and 'InnerDefaultProperty' of enumeration PersistenceMode.
A simple Templated control 'MyTemplateControl' is created. Different persistence modes have been applied to it's 
properties.
'PersistenceMode.Attribute' is applied to property 'Author' which is of type string.
This is initialized as an attribute of the html tag. 
'PersistenceMode.InnerProperty' is applied to property 'MessageTemplate' which is of type 'ITemplate'. 
This is initialized as a nested tag in the html tag.
AND  
'PersistenceMode.InnerDefaultProperty' is applied to property 'Items' which is of type 'ListItemCollection'.
This is initialized as inner content of the HTML tag as a child
  */
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersistenceModeAttributeSamples 
{
    // The container control class to instantiate the template property 'MessageTemplate'
    public class TemplateItem : Control, INamingContainer 
    {
        private String     _author         = null;
        public TemplateItem(String author) 
        {
            _author = author;
        }
        public String Author 
        {
           get 
           {
              return _author;
           }
           set 
           {
              _author = value;
           }
        }
    }
    // 'ParseChildren' Attribute ensures nested(child) elements correspond to properties of the control. 
    // Other(nonproperty) elements and literal text between control tags will generate a parser error. 
    [ParseChildren(true)]
    public class MyTemplateControl : Control, INamingContainer 
    {
        private ITemplate  _messageTemplate = null;
        private String     _author         = null;
        private ListItemCollection myCollection = null;

// <Snippet1>
       [PersistenceMode(PersistenceMode.Attribute)]
       public string Author
       {
          get 
          {
             return _author;
          }
          set 
          {
             _author = value;
          }
       }
// </Snippet1>

// <Snippet2>
      [PersistenceMode(PersistenceMode.InnerProperty),
      TemplateContainer(typeof(TemplateItem))]
      public ITemplate MessageTemplate {
         get {
            return _messageTemplate;
         }
         set {
            _messageTemplate = value;
         }
      }
// </Snippet2>
// <Snippet3>
       [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
       public ListItemCollection Items
       {
          get
          {
             if (myCollection == null)
             {
                myCollection = new ListItemCollection();
                if (IsTrackingViewState)
                   ((IStateManager)myCollection).TrackViewState();
             }
             return myCollection;
          }
       }
// </Snippet3>

       // When called on a server control, this method resolves all data-binding; 
       // expressions in the server control and in any of its child controls.
        public override void DataBind() 
        {
            EnsureChildControls();
            base.DataBind();
        }

        protected override void CreateChildControls() 
        {
           // If a template has been specified, use it to create children.
           // Otherwise, create a single literalcontrol with author value.

           if (MessageTemplate != null) 
           {
              Controls.Clear();
              TemplateItem i = new TemplateItem(this.Author);
              MessageTemplate.InstantiateIn(i);
              Controls.Add(i);
           }
           else 
           {
              this.Controls.Add(new LiteralControl(this.Author));
           }
        }
    }
}

  