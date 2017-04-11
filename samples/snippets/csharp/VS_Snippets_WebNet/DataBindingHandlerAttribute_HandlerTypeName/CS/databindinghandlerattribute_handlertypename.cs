// System.Web.UI.DataBindingHandlerAttribute.HandlerTypeName

/*
   The following program demonstrates 'HandlerTypeName' property of 
   'DataBindingHandlerAttribute' class.
   A new control 'SimpleWebControl' is created. DataBindingHandlerAttribute is attached
   to the 'SimpleWebControl'. The attributes and their corresponding handler type name 
   of the custom control are displayed to the console.
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace DataBindingHandlerAttributeTest
{
// <Snippet1>
   [
     DataBindingHandlerAttribute(typeof(System.Web.UI.Design.TextDataBindingHandler))
   ]
   public class SimpleWebControl:WebControl
   {
      // Insert code for class members here
   }

   class TestAttributes
   {
      public static void Main()
      {
         System.ComponentModel.AttributeCollection myAttributes = 
            TypeDescriptor.GetAttributes(typeof(SimpleWebControl));

         DataBindingHandlerAttribute myDataBindingHandlerAttribute = 
            myAttributes[typeof(DataBindingHandlerAttribute)] as DataBindingHandlerAttribute;

         if(myDataBindingHandlerAttribute != null)
         {
            Console.Write("DataBindingHandlerAttribute's HandlerTypeName is : " + 
                  myDataBindingHandlerAttribute.HandlerTypeName);
         }
      }
   }
// </Snippet1>
}
