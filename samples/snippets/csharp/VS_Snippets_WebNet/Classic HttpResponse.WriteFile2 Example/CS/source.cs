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
 FileInfo MyFileInfo;
 long StartPos = 0, FileSize;
 
 FileName = "c:\\temp\\login.txt";
 MyFileInfo = new FileInfo(FileName);
 FileSize = MyFileInfo.Length;
 
 Response.Write("Please Login: <br>");
 Response.WriteFile(FileName, StartPos, FileSize);
    
// </Snippet1>
 }
}
