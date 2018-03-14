using System;
using System.IO;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String FileName;
 FileStream MyFileStream;
 IntPtr FileHandle;
 long StartPos = 0, FileSize;
 
 FileName = "c:\\temp\\Login.txt";
 
 MyFileStream = new FileStream(FileName, FileMode.Open);
 FileHandle = MyFileStream.Handle;
 FileSize = MyFileStream.Length;
 
 Response.Write("<b>Login: </b>");
 Response.Write("<input type=text id=user /> ");
 Response.Write("<input type=submit value=Submit /><br><br>");
 
 Response.WriteFile(FileHandle, StartPos, FileSize);
    
 MyFileStream.Close();
    
// </Snippet1>
 }
}
