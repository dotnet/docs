// System.Web.UI.Control.Dispose()

/* The following example demonstrates the Dispose() method of class Control.
In Dispose() method all resources are cleaned up and Dispose() of
the child control(Button) is invoked.
*/

using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControlNameSpace
{
   public class MyCustomControl:Control
   {
      TextWriter myTextWriter;
      Button  myButton;
      
      public MyCustomControl()
      {
         try
         {
            myTextWriter = File.CreateText("MyTestFile.txt");
            myButton = new Button();
            myButton.Text = "MyButton";
            Controls.Add(myButton);
         }
         catch(Exception myExeception)
         {
            Context.Response.Write("Execption occured:"+myExeception.Message);
         }
      }

// <Snippet1>
      public override void Dispose()
      {
         try
         {
            Context.Response.Write("Disposing " + ToString());
            // Perform resource cleanup.
            myTextWriter.Close();
            myButton.Dispose();
         }
         catch(Exception myException)
         {
            Context.Response.Write("Exception occurred: "+myException.Message);
         }
      }
// </Snippet1>

      protected override void Render(HtmlTextWriter  myWriter)
      {
         this.RenderChildren(myWriter);
         myWriter.Write("My Custom Control");
      }
   }
}
