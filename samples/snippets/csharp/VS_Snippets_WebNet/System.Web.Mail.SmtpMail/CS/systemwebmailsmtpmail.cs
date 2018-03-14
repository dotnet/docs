// <Snippet1>
using System;
using System.Web.Mail;
 
namespace SendMail
{
   class usage
   {
      public void DisplayUsage()
      {
         Console.WriteLine("Usage SendMail.exe <to> <from> <subject> <body>");
         Console.WriteLine("<to> the addresses of the email recipients");
         Console.WriteLine("<from> your email address");
         Console.WriteLine("<subject> subject of your email");
         Console.WriteLine("<body> the text of the email");
         Console.WriteLine("Example:");
         Console.WriteLine("SendMail.exe SomeOne@Contoso.com;SomeOther@Contoso.com Me@contoso.com Hi hello");
      }
   }
 

   class Start
   {
      // The main entry point for the application.
      [STAThread]
      static void Main(string[] args)
      {
         try
         {
            try
            {
               MailMessage Message = new MailMessage();
               Message.To = args[0];
               Message.From = args[1];
               Message.Subject = args[2];
               Message.Body = args[3];

               try
               {
                  SmtpMail.SmtpServer = "your mail server name goes here";
                  SmtpMail.Send(Message);
               }
               catch(System.Web.HttpException ehttp)
               {
                  Console.WriteLine("{0}", ehttp.Message);
                  Console.WriteLine("Here is the full error message output");
                  Console.Write("{0}", ehttp.ToString());
               }
            }
            catch(IndexOutOfRangeException)
            {
               usage use = new usage();
               use.DisplayUsage();
            }
         }
         catch(System.Exception e)
         {
            Console.WriteLine("Unknown Exception occurred {0}", e.Message);
            Console.WriteLine("Here is the Full Message output");
            Console.WriteLine("{0}", e.ToString());
         }
      }
   }
}
// </Snippet1>