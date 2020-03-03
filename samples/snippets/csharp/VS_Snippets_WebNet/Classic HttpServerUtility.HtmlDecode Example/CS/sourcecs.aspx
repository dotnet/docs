<!--<Snippet1>-->
<%@ PAGE LANGUAGE = "C#" %>
 <%@ IMPORT NAMESPACE = "System.IO" %>
 
 <html xmlns="http://www.w3.org/1999/xhtml">
 <script runat ="server">
 
    String LoadDecodedFile(String file)
       {
       String DecodedString = "";
       FileStream fs = new FileStream(file, FileMode.Open);
       StreamReader r = new StreamReader(fs);
 
       // Position the file pointer at the beginning of the file.
       r.BaseStream.Seek(0, SeekOrigin.Begin);
       
       // Read the entire file into a string and decode each chunk.  
       while (r.Peek() > -1)
          DecodedString += Server.HtmlDecode(r.ReadLine());
 
       r.Close();
       return DecodedString; 
       }
 
 </script>
 <head runat="server">
 <title>HttpServerUtility.HtmlDecode Example</title>
 </head>
 <body></body>
 </html>

<!--</Snippet1>-->
