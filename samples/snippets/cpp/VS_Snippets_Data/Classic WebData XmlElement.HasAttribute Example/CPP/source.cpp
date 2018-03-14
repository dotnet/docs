

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<book genre='novel' ISBN='1-861001-57-5'><title>Pride And Prejudice</title></book>" );
   XmlElement^ root = doc->DocumentElement;
   
   // Check to see if the element has a genre attribute.
   if ( root->HasAttribute( "genre" ) )
   {
      String^ genre = root->GetAttribute( "genre" );
      Console::WriteLine( genre );
   }
}

// </Snippet1>
