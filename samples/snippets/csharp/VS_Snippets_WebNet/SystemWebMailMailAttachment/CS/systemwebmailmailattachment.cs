using System;
using System.Web.Mail;

namespace MyNameSpace
{
   class MyClass
   {
      static void Main(string[] args)
      {
         //<Snippet1>
         //This example shows how to programmatically add attached files 
         //to a mail lessage.

         MailMessage myMail = new MailMessage();

         // Concatenate a list of attachment files in a string.
         string sAttach = @"C:\images\image1.jpg,C:\images\image2.jpg,C:\images\image3.jpg";

         // Build an IList of mail attachments using the files named in the string.
         char[] delim = new char[] {','};
         foreach (string sSubstr in sAttach.Split(delim))
         {
            MailAttachment myAttachment = new MailAttachment(sSubstr);
            myMail.Attachments.Add(myAttachment);
         }
         // </Snippet1>
      }
   }
}
