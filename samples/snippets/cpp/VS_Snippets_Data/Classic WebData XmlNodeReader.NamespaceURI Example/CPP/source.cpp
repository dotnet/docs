

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
      doc->LoadXml( "<book xmlns:bk='urn:samples'> "
      "<title>Pride And Prejudice</title>"
      "<bk:genre>novel</bk:genre>"
      "</book>" );
      
      //Load the XmlNodeReader 
      reader = gcnew XmlNodeReader( doc );
      
      //Parse the XML.  If they exist, display the prefix and  
      //namespace URI of each node.
      while ( reader->Read() )
      {
         if ( reader->IsStartElement() )
         {
            if ( reader->Prefix == String::Empty )
                        Console::WriteLine( "<{0}>", reader->LocalName );
            else
            {
               Console::Write( "<{0}:{1}>", reader->Prefix, reader->LocalName );
               Console::WriteLine( " The namespace URI is {0}", reader->NamespaceURI );
            }
         }
      }
   }
   finally
   {
      if ( reader != nullptr )
            reader->Close();
   }

}

// </Snippet1>
