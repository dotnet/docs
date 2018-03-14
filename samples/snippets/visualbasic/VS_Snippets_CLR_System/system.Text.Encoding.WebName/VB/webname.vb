 ' <Snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Web

Namespace WebNameExample
   Public Class ExampleClass
      
      Public Overloads Shared Sub Main()
         ' Use UTF8 encoding.
         Dim encoding As Encoding = Encoding.UTF8
         Dim writer As New StreamWriter("Encoding.html", False, encoding)
         
         writer.WriteLine("<html><head>")
         
         ' Write charset attribute to the html file.
         writer.Write("<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html;")
         writer.WriteLine(" charset=" + encoding.WebName + """>")
         
         writer.WriteLine("</head><body>")
         writer.WriteLine("<p>" + HttpUtility.HtmlEncode(encoding.EncodingName) + "</p>")
         writer.WriteLine("</body></html>")
         writer.Flush()
         writer.Close()
      End Sub
   End Class
End Namespace

'This code produces the following output in an HTML file.
'<html><head>
'<META HTTP-EQUIV="Content-Type" CONTENT="text/html; 'charset=utf-8">
'</head><body>
'<p>Unicode (UTF-8)</p>
'</body></html>
'
' </Snippet1>
