using System;
using System.Web.Mail;

namespace MyNameSpace
{
   class MyClass
   {
      static void Main(string[] args)
      {
         //<Snippet1>
         MailMessage MyMessage = new MailMessage();
         MyMessage.To = "john@contoso.com";
         // </Snippet1>
      }
   }
}
