

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
