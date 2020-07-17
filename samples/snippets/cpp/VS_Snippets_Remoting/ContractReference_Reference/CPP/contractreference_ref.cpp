/*
System::Web::Services::Discovery.ContractReference::ctor
System::Web::Services::Discovery.ContractReference::Ref
System::Web::Services::Discovery.ContractReference::DocRef
System::Web::Services::Discovery.ContractReference::Namespace

The following example demonstrates the constructor, the
properties 'Ref', 'DocRef' and 'Namespace'. A sample discovery 
document is read and 'Ref', 'DocRef' and 'Namespace' properties
are displayed.
*/
#using <System.Data.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Data;
using namespace System::Xml;
using namespace System::Web::Services::Discovery;

int main()
{
   
   // <Snippet4>
   // <Snippet3>
   // <Snippet2>
   // <Snippet1>
   // Call the Constructor of ContractReference.
   ContractReference^ myContractReference = gcnew ContractReference;
   // </Snippet1>
   XmlDocument^ myXmlDocument = gcnew XmlDocument;
   
   // Read the discovery document for the 'contractRef' tag.
   myXmlDocument->Load( "http://localhost/Discoverydoc.disco" );
   XmlNode^ myXmlRoot = myXmlDocument->FirstChild;
   XmlNode^ myXmlNode = myXmlRoot[ "scl:contractRef" ];
   XmlAttributeCollection^ myAttributeCollection = myXmlNode->Attributes;
   myContractReference->Ref = myAttributeCollection[ 0 ]->Value;
   Console::WriteLine( "The URL to the referenced service description is : {0}", myContractReference->Ref );
   // </Snippet2>
   myContractReference->DocRef = myAttributeCollection[ 1 ]->Value;
   Console::WriteLine( "The URL implementing the referenced service description is : {0}", myContractReference->DocRef );
   // </Snippet3>
   Console::WriteLine( "Namespace for the referenced service description is : {0}", ContractReference::Namespace );
   // </Snippet4>
}
