

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
      doc->LoadXml( "<book genre='novel' ISBN='1-861003-78' publicationdate='1987'></book>" );
      
      //Load the XmlNodeReader 
      reader = gcnew XmlNodeReader( doc );
      
      //Read the genre attribute.
      reader->MoveToContent();
      reader->MoveToFirstAttribute();
      String^ genre = reader->Value;
      Console::WriteLine( "The genre value: {0}", genre );
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
