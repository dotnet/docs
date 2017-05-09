// System.Web.UI.ValidationPropertyAttribute.ValidationPropertyAttribute(string)

/*The following example demonstrates the constructor of 'ValidationPropertyAttribute(string)'.
  A custom control is created and ValidationPropertyAttribute is applied 
  to specify a property of the server control that can be validated by any validation control.
 */
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyControls
{
// <Snippet1>
   [ValidationPropertyAttribute("Message")]
   public class MessageControl : Label
   {
      private int _message = 0;
      public int Message
      {
         get 
         {
            return _message;
         }
         set
         {
            _message = value;
         }
      }
      
   }
// </Snippet1>
}
