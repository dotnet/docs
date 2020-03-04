

// <Snippet1>
#using <System.dll>
#using <System.Web.dll>

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Web;
int main()
{
   
   // Use UTF8 encoding.
   Encoding^ encoding = Encoding::UTF8;
   StreamWriter^ writer = gcnew StreamWriter( "Encoding.html",false,encoding );
   writer->WriteLine( "<html><head>" );
   
   // Write charset attribute to the html file.
   // writer -> WriteLine(S"<META HTTP-EQUIV=\"Content-Type\S" CONTENT=\"text/html; charset=S {0}", encoding.WebName +"\S">");
   writer->WriteLine( String::Concat( "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=", encoding->WebName, "\">" ) );
   writer->WriteLine( "</head><body>" );
   writer->WriteLine( "<p>{0}</p>", HttpUtility::HtmlEncode( encoding->EncodingName ) );
   writer->WriteLine( "</body></html>" );
   writer->Flush();
   writer->Close();
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
