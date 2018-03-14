

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextReader^ reader = nullptr;
   try
   {
      
      //Load the reader with the XML file.
      reader = gcnew XmlTextReader( "attrs.xml" );
      
      //Read the ISBN attribute.
      reader->MoveToContent();
      String^ isbn = reader->GetAttribute( "ISBN" );
      Console::WriteLine( "The ISBN value: {0}", isbn );
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
