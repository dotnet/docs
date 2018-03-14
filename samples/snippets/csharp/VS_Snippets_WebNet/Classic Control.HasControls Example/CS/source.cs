using System;
using System.Data;
using System.Web.UI;

public class Form1: Control
{
 protected HtmlTextWriter writer;

 protected void Method()
 {
// <Snippet1>
if (HasControls()) {
                 for (int i=0; i < Controls.Count; i++) {
                     Controls[i].RenderControl(writer);
                 }
   }
// </Snippet1>
 }
}
