

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   //Load XML data which includes white space, but ignore
   //any white space in the file.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->PreserveWhitespace = false;
   doc->Load( "book.xml" );
   
   //Save the document as is (no white space).
   Console::WriteLine( "Display the modified XML..." );
   doc->PreserveWhitespace = true;
   doc->Save( Console::Out );
}

// </Snippet1>
