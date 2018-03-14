

// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

int main()
{
   XmlSchema^ s = gcnew XmlSchema;
   s->TargetNamespace = "myNamespace";
   s->Namespaces->Add( "myImpPrefix", "myImportNamespace" );

   // Create the <xs:import> element.
   XmlSchemaImport^ import = gcnew XmlSchemaImport;
   import->Namespace = "myImportNamespace";
   import->SchemaLocation = "http://www.example.com/myImportNamespace";
   s->Includes->Add( import );

   // Create an element and assign a type from imported schema.
   XmlSchemaElement^ elem = gcnew XmlSchemaElement;
   elem->SchemaTypeName = gcnew XmlQualifiedName( "importType","myImportNamespace" );
   elem->Name = "element1";
   s->Items->Add( elem );
   s->Write( Console::Out );
}
// </Snippet1>
