// <Snippet1>
using System;
using System.IO;
using System.Text;
using System.Web;

namespace WebNameExample 
{
   public class ExampleClass 
   {
      public static void Main(string[] args) 
      {
         // Use UTF8 encoding.
	 Encoding encoding = Encoding.UTF8;
	 StreamWriter writer = new StreamWriter("Encoding.html", false, encoding);
	 		
	 writer.WriteLine("<html><head>");

	 // Write charset attribute to the html file.
	 // The value of charset is returned by the WebName property.
	 writer.WriteLine("<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=" +
                           encoding.WebName +"\">");
	
         writer.WriteLine("</head><body>");
	 writer.WriteLine("<p>" + HttpUtility.HtmlEncode(encoding.EncodingName) + "</p>");
	 writer.WriteLine("</body></html>");
	 writer.Flush();
	 writer.Close();
      }
   }
}

/*
This code produces the following output in an HTML file.

<html><head>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
</head><body>
<p>Unicode (UTF-8)</p>
</body></html>

*/

// </Snippet1>
