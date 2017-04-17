// <Snippet1>
using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected string MyString;
 private void Page_Load(Object sender, EventArgs e)
 {
   HttpFileCollection MyFileCollection;
   HttpPostedFile MyFile;
   int FileLen;
   System.IO.Stream MyStream;
 
   MyFileCollection = Request.Files;
   MyFile = MyFileCollection[0];
 
   FileLen = MyFile.ContentLength;
   byte[] input = new byte[FileLen];
 
   // Initialize the stream.
   MyStream = MyFile.InputStream;
 
   // Read the file into the byte array.
   MyStream.Read(input, 0, FileLen);
 
   // Copy the byte array into a string.
   for (int Loop1 = 0; Loop1 < FileLen; Loop1++)
     MyString = MyString + input[Loop1].ToString();
    
 }
}
// </Snippet1>
