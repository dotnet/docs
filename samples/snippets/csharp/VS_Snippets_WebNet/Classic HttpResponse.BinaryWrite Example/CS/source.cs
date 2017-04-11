using System;
using System.IO;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
FileStream MyFileStream;
 long FileSize;
 
 MyFileStream = new FileStream("sometext.txt", FileMode.Open);
 FileSize = MyFileStream.Length;
      
 byte[] Buffer = new byte[(int)FileSize];
 MyFileStream.Read(Buffer, 0, (int)FileSize);
 MyFileStream.Close();
 
 Response.Write("<b>File Contents: </b>");
 Response.BinaryWrite(Buffer);
    
// </Snippet1>
 }
}
