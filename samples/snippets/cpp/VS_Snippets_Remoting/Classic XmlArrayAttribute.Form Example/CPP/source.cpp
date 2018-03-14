

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;
public ref class Winery
{
public:
   String^ Name;
};

public ref class VacationCompany
{
public:
   String^ Name;
};

public ref class Enterprises
{
private:
   array<Winery^>^wineries;
   array<VacationCompany^>^companies;

public:

   // Sets the Form property to qualified, and specifies the namespace. 
   [XmlArray(Form=XmlSchemaForm::Qualified,ElementName="Company",
   Namespace="http://www.cohowinery.com")]
   property array<Winery^>^ Wineries 
   {
      array<Winery^>^ get()
      {
         return wineries;
      }
      void set( array<Winery^>^value )
      {
         wineries = value;
      }
   }

   [XmlArray(Form=XmlSchemaForm::Qualified,ElementName="Company",
   Namespace="http://www.treyresearch.com")]
   property array<VacationCompany^>^ Companies 
   {
      array<VacationCompany^>^ get()
      {
         return companies;
      }
      void set( array<VacationCompany^>^value )
      {
         companies = value;
      }
   }
};

int main()
{
   String^ filename = "MyEnterprises.xml";

   // Creates an instance of the XmlSerializer class.
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Enterprises::typeid );

   // Writing file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Creates an instance of the XmlSerializerNamespaces class.
   XmlSerializerNamespaces^ ns = gcnew XmlSerializerNamespaces;

   // Adds namespaces and prefixes for the XML document instance.
   ns->Add( "winery", "http://www.cohowinery.com" );
   ns->Add( "vacationCompany", "http://www.treyresearch.com" );

   // Creates an instance of the class that will be serialized.
   Enterprises^ myEnterprises = gcnew Enterprises;

   // Creates objects and adds to the array. 
   Winery^ w1 = gcnew Winery;
   w1->Name = "cohowinery";
   array<Winery^>^myWinery = {w1};
   myEnterprises->Wineries = myWinery;
   VacationCompany^ com1 = gcnew VacationCompany;
   com1->Name = "adventure-works";
   array<VacationCompany^>^myCompany = {com1};
   myEnterprises->Companies = myCompany;

   // Serializes the class, and closes the TextWriter.
   mySerializer->Serialize( writer, myEnterprises, ns );
   writer->Close();
}

void ReadEnterprises( String^ filename )
{
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Enterprises::typeid );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Enterprises^ myEnterprises = dynamic_cast<Enterprises^>(mySerializer->Deserialize( fs ));
   for ( int i = 0; i < myEnterprises->Wineries->Length; i++ )
   {
      Console::WriteLine( myEnterprises->Wineries[ i ]->Name );
   }
   for ( int i = 0; i < myEnterprises->Companies->Length; i++ )
   {
      Console::WriteLine( myEnterprises->Companies[ i ]->Name );
   }
}
// </Snippet1>
