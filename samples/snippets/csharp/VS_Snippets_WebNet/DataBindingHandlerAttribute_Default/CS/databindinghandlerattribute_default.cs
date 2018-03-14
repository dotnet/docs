// System.Web.UI.DataBindingHandlerAttribute.Default

/*
   The following program demonstrates 'Default' field of 'DataBindingHandlerAttribute' class.
   It obtains an instance of 'DataBindingHandlerAttribute' class by using 'Default' field
   of 'DataBindingHandlerAttribute' class. Then it displays the value of 'HandlerTypeName'
   property.
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;

namespace DataBindingHandlerAttributeTest
{
   class TestAttributes
   {
      public static void Main()
      {
         try
         {
// <Snippet1>
            DataBindingHandlerAttribute myDataBindingHandlerAttribute = 
               DataBindingHandlerAttribute.Default;
// </Snippet1>
            Console.WriteLine("Hash code for DataBindingHandlerAttribute instance is : " + 
               myDataBindingHandlerAttribute.GetHashCode());
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception : " + e.Message);
         }
      }
   }
}
