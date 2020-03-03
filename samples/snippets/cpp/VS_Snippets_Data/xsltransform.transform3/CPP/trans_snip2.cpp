#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Xsl;

int main()
{
   //<snippet1>
   // Create the XslTransform object.
   XslTransform^ xslt = gcnew XslTransform;
   
   // Load the stylesheet.
   xslt->Load( "output.xsl" );
   
   // Transform the file.
   xslt->Transform("books.xml","books.html");
   //</snippet1>
}
