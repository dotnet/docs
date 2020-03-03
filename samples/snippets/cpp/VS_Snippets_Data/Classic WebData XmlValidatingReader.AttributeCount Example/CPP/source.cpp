

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlValidatingReader^ reader = nullptr;
   try
   {
      
      //Create the string to parse.
      String^ xmlFrag = "<book genre='novel' ISBN='1-861003-78' pubdate='1987'></book> ";
      
      //Create the XmlNamespaceManager.
      NameTable^ nt = gcnew NameTable;
      XmlNamespaceManager^ nsmgr = gcnew XmlNamespaceManager( nt );
      
      //Create the XmlParserContext.
      XmlParserContext^ context = gcnew XmlParserContext( nullptr,nsmgr,nullptr,XmlSpace::None );
      
      //Create the XmlValidatingReader .
      reader = gcnew XmlValidatingReader( xmlFrag,XmlNodeType::Element,context );
      
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
