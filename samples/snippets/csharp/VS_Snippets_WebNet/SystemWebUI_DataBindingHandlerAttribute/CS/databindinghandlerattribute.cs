// <snippet1>

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;


namespace CustomControls
{
  [
    DataBindingHandler(typeof(MyDataBindingHandler)),
    ToolboxData("<{0}:MyLabel runat=server></{0}:MyLabel>")
  ]
  public class MyLabel : Label 
  {
    public  MyLabel()
    { 
      // Insert your code here.
    } 
  }

  public class MyDataBindingHandler : DataBindingHandler
  {
    public override void DataBindControl(IDesignerHost host, Control control)
    {
      ((Label)control).Text = "Added by data binding handler.";
    }
  }

}

// </snippet1>
