

// System.Web.Services.Description.ServiceDescription.Types
// System.Web.Services.Description.ServiceDescription.Write(Stream)
/*
The following program demonstrates the 'Write' method and 'Types' property
of ServiceDescription class.An existing WSDL document is read.
Types of the SericeDescription are removed.New Types are constructed.
Types are then added to ServiceDescription .A new WSDL file is created as output.
*/
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;

// This function creates a XmlComplex Element.
XmlSchemaElement^ CreateComplexTypeXmlElement( String^ minoccurs, String^ maxoccurs, String^ name, XmlQualifiedName^ schemaTypeName )
{
   XmlSchemaElement^ myXmlSchemaElement = gcnew XmlSchemaElement;
   myXmlSchemaElement->MinOccursString = minoccurs;
   myXmlSchemaElement->MaxOccursString = maxoccurs;
   myXmlSchemaElement->Name = name;
   myXmlSchemaElement->SchemaTypeName = schemaTypeName;
   return myXmlSchemaElement;
}

int main()
{
   try
   {
      // Read the existing WSDL.
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Input_CS.wsdl" );

      // <Snippet1>
      myServiceDescription->Types->Schemas->Remove( myServiceDescription->Types->Schemas[ 0 ] );
      XmlSchema^ myXmlSchema = gcnew XmlSchema;
      myXmlSchema->AttributeFormDefault = XmlSchemaForm::Qualified;
      myXmlSchema->ElementFormDefault = XmlSchemaForm::Qualified;
      myXmlSchema->TargetNamespace = myServiceDescription->TargetNamespace;
      XmlSchemaElement^ myXmlElement1 = gcnew XmlSchemaElement;
      myXmlElement1->Name = "Add";
      XmlSchemaComplexType^ myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
      XmlSchemaSequence^ myXmlSchemaSequence = gcnew XmlSchemaSequence;
      myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "a", gcnew XmlQualifiedName( "s:float" ) ) );
      myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "b", gcnew XmlQualifiedName( "s:float" ) ) );
      myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
      myXmlElement1->SchemaType = myXmlSchemaComplexType;
      myXmlSchema->Items->Add( myXmlElement1 );
      XmlSchemaElement^ myXmlElement2 = gcnew XmlSchemaElement;
      myXmlElement2->Name = "AddResponse";
      myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
      myXmlSchemaSequence = gcnew XmlSchemaSequence;
      myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "AddResult", gcnew XmlQualifiedName( "s:float" ) ) );
      myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
      myXmlElement2->SchemaType = myXmlSchemaComplexType;
      myXmlSchema->Items->Add( myXmlElement2 );
      XmlSchemaElement^ myXmlElement3 = gcnew XmlSchemaElement;
      myXmlElement3->Name = "Subtract";
      myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
      myXmlSchemaSequence = gcnew XmlSchemaSequence;
      myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "a", gcnew XmlQualifiedName( "s:float" ) ) );
      myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "b", gcnew XmlQualifiedName( "s:float" ) ) );
      myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
      myXmlElement3->SchemaType = myXmlSchemaComplexType;
      myXmlSchema->Items->Add( myXmlElement3 );
      XmlSchemaElement^ myXmlElement4 = gcnew XmlSchemaElement;
      myXmlElement4->Name = "SubtractResponse";
      myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
      myXmlSchemaSequence = gcnew XmlSchemaSequence;
      myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "SubtractResult", gcnew XmlQualifiedName( "s:int" ) ) );
      myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
      myXmlElement4->SchemaType = myXmlSchemaComplexType;
      myXmlSchema->Items->Add( myXmlElement4 );

      // Add the schemas to the Types property of the ServiceDescription.
      myServiceDescription->Types->Schemas->Add( myXmlSchema );
      // </Snippet1>

      // <Snippet2>
      FileStream^ myFileStream = gcnew FileStream( "output.wsdl",FileMode::OpenOrCreate,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );

      // Write the WSDL.
      Console::WriteLine( "Writing a new WSDL file." );
      myServiceDescription->Write( myStreamWriter );
      myStreamWriter->Close();
      myFileStream->Close();
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught! {0}", e->Message );
   }
}
