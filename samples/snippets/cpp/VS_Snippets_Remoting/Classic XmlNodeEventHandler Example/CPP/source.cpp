#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;

public ref class Class1
{
   // <Snippet1>
private:
   void DeserializeItem( String^ filename )
   {
      XmlSerializer^ mySerializer = gcnew XmlSerializer( ObjectToDeserialize::typeid );

      // Add an instance of the delegate to the event.
      mySerializer->UnknownNode += gcnew XmlNodeEventHandler( this, &Class1::Serializer_UnknownNode );

      // A FileStream is needed to read the file to deserialize.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
      ObjectToDeserialize^ o = dynamic_cast<ObjectToDeserialize^>(mySerializer->Deserialize( fs ));
   }

   void Serializer_UnknownNode( Object^ sender, XmlNodeEventArgs^ e )
   {
      Console::WriteLine( "UnknownNode Name: {0}", e->Name );
      Console::WriteLine( "UnknownNode LocalName: {0}", e->LocalName );
      Console::WriteLine( "UnknownNode Namespace URI: {0}", e->NamespaceURI );
      Console::WriteLine( "UnknownNode Text: {0}", e->Text );
      Object^ o = e->ObjectBeingDeserialized;
      Console::WriteLine( "Object being deserialized {0}", o );
      XmlNodeType myNodeType = e->NodeType;
      Console::WriteLine( myNodeType );
   }
   // </Snippet1>

public:

   ref class ObjectToDeserialize{};
};
