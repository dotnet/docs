

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   String^ xmlData = "<book xmlns:bk='urn:samples'></book>";
   doc->Load( gcnew StringReader( xmlData ) );
   
   // Create a new element and add it to the document.
   XmlElement^ elem = doc->CreateElement( "bk", "genre", "urn:samples" );
   elem->InnerText = "fantasy";
   doc->DocumentElement->AppendChild( elem );
   Console::WriteLine( "Display the modified XML..." );
   doc->Save( Console::Out );
}

// </Snippet1>
