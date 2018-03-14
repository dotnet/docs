using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class MyControl:UserControl
{  
   protected string _message;
   public string Message
   {
      get
      {
         return _message;
      }

   }
}
