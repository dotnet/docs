using System;
using System.Web.Mail;
using System.Text;

namespace MyNameSpace
{
   class MyClass
   {
      static void Main(string[] args)
      {
         //<Snippet1>
         MailMessage MyMessage = new MailMessage();
         MyMessage.BodyFormat = MailFormat.Html;
         // </Snippet1>
      }
   }
}
