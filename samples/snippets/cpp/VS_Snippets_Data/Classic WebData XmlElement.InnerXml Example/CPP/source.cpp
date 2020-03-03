

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<root><elem>some text<child/>more text</elem></root>" );
   XmlElement^ elem = dynamic_cast<XmlElement^>(doc->DocumentElement->FirstChild);
   
   // Note that InnerText does not include the markup.
   Console::WriteLine( "Display the InnerText of the element..." );
   Console::WriteLine( elem->InnerText );
   
   // InnerXml includes the markup of the element.
   Console::WriteLine( "Display the InnerXml of the element..." );
   Console::WriteLine( elem->InnerXml );
   
   // Set InnerText to a string that includes markup.  
   // The markup is escaped.
   elem->InnerText = "Text containing <markup/> will have char(<) and char(>) escaped.";
   Console::WriteLine( elem->OuterXml );
   
   // Set InnerXml to a string that includes markup.  
   // The markup is not escaped.
   elem->InnerXml = "Text containing <markup/>.";
   Console::WriteLine( elem->OuterXml );
}
// This example produces the following results:
//
// Display the InnerText of the element...
// some textmore text
// Display the InnerXml of the element...
// some text<child />more text
// <elem>Text containing &lt;markup/&gt; will have char(&lt;) and char(&gt;) escaped.</elem>
// <elem>Text containing <markup />.</elem>
// </Snippet1>
