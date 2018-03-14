

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlNodeReader^ reader = nullptr;
   try
   {
      
      //Create and load the XML document.
      XmlDocument^ doc = gcnew XmlDocument;
      doc->LoadXml( "<book genre='novel' ISBN='1-861003-78' publicationdate='1987'> "
      "</book>" );
      
      //Load the XmlNodeReader 
      reader = gcnew XmlNodeReader( doc );
      
      //Read the attributes on the root element.
      reader->MoveToContent();
      if ( reader->HasAttributes )
      {
         for ( int i = 0; i < reader->AttributeCount; i++ )
         {
            reader->MoveToAttribute( i );
            Console::WriteLine( "{0} = {1}", reader->Name, reader->Value );

         }
         reader->MoveToElement();
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
