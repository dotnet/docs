// <snippet1>
/* Create a class that implements the ITemplate interface.
   This class overrides the InstantiateIn method to always
   place templates in a Literal object. It also creates a 
   custom BindData method that is used as the event handler
   associated with the Literal object's DataBinding event.  
*/
  
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsingItemTemplates
{
    public class GenericItem : ITemplate
    {
        private string column;
      
        public GenericItem(string column)
        {
            this.column = column;
        }

        // <snippet2>
        // Override the ITemplate.InstantiateIn method to ensure 
        // that the templates are created in a Literal control and
        // that the Literal object's DataBinding event is associated
        // with the BindData method.
        public void InstantiateIn(Control container)
        {
            Literal l = new Literal();
            l.DataBinding += new EventHandler(this.BindData);
            container.Controls.Add(l);
        }
        // Create a public method that will handle the
        // DataBinding event called in the InstantiateIn method.
        public void BindData(object sender, EventArgs e)
        {
            Literal l = (Literal) sender;
            DataGridItem container = (DataGridItem) l.NamingContainer;
            l.Text = ((DataRowView) container.DataItem)[column].ToString();
    
        }
        // </snippet2>
    }
}
// </snippet1>
