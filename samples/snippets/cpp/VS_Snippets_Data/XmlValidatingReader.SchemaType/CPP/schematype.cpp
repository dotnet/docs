//<snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;

public ref class Sample
{
private:
   static void ValidationCallBack( Object^ sender, ValidationEventArgs^ args )
   {
      Console::WriteLine( "***Validation error" );
      Console::WriteLine( "\tSeverity: {0}", args->Severity );
      Console::WriteLine( "\tMessage  : {0}", args->Message );
   }

public:
   static void main()
   {
      XmlTextReader^ tr = gcnew XmlTextReader( "booksSchema.xml" );
      XmlValidatingReader^ vr = gcnew XmlValidatingReader( tr );
      vr->Schemas->Add( nullptr, "books.xsd" );
      vr->ValidationType = ValidationType::Schema;
      vr->ValidationEventHandler += gcnew ValidationEventHandler( Sample::ValidationCallBack );
      while ( vr->Read() )
      {
         if ( vr->NodeType == XmlNodeType::Element )
         {
            if ( dynamic_cast<XmlSchemaComplexType^>(vr->SchemaType) != nullptr )
            {
               XmlSchemaComplexType^ sct = dynamic_cast<XmlSchemaComplexType^>(vr->SchemaType);
               Console::WriteLine( " {0}( {1})", vr->Name, sct->Name );
            }
            else
            {
               Object^ value = vr->ReadTypedValue();
               Console::WriteLine( " {0}( {1}): {2}", vr->Name, value->GetType()->Name, value );
            }
         }
      }
   }
};

int main()
{
   Sample::main();
}
//</snippet1>
