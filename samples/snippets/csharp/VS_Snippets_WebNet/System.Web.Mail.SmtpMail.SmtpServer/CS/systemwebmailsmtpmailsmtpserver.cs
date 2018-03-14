using System;
using System.Web.Mail;

namespace MyNameSpace
{
   class MyClass
   {
      static void Main(string[] args)
      {
         //<Snippet1>
         //This example assigns the name of the mail relay server on the 
         //local network to the SmtpServer property.
         SmtpMail.SmtpServer = "RelayServer.Contoso.com";
         // </Snippet1>
      }
   }
}
