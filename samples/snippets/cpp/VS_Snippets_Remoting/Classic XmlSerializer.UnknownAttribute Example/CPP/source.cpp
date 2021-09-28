

//<Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
using namespace System::Xml;
using namespace System::Xml::Schema;

public ref class Group
{
public:
   String^ GroupName;
};

public ref class Test
{
public:
   static void main()
   {
      Test^ t = gcnew Test;
      
      // Deserialize the file containing unknown elements.
      t->DeserializeObject( "UnknownAttributes.xml" );
   }

private:
   void Serializer_UnknownAttribute( Object^ sender, XmlAttributeEventArgs^ e )
   {
      Console::WriteLine( "Unknown Attribute" );
      Console::WriteLine( "\t{0} {1}", e->Attr->Name, e->Attr->InnerXml );
      Console::WriteLine( "\t LineNumber: {0}", e->LineNumber );
      Console::WriteLine( "\t LinePosition: {0}", e->LinePosition );
      Group^ x = dynamic_cast<Group^>(e->ObjectBeingDeserialized);
      Console::WriteLine( x->GroupName );
      Console::WriteLine( sender );
   }

   void DeserializeObject( String^ filename )
   {
      XmlSerializer^ ser = gcnew XmlSerializer( Group::typeid );

      // Add a delegate to handle unknown element events.
      ser->UnknownAttribute += gcnew XmlAttributeEventHandler( this, &Test::Serializer_UnknownAttribute );

      // A FileStream is needed to read the XML document.
      FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
      Group^ g = dynamic_cast<Group^>(ser->Deserialize( fs ));
      fs->Close();
   }
};

int main()
{
   Test::main();
}
//</Snippet1>  
