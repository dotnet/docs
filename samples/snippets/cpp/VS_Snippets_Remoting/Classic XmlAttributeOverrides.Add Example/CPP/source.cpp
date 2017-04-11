

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;

ref class Band;
ref class Instrument;

/* This is the class that will be overridden. The XmlIncludeAttribute 
tells the XmlSerializer that the overriding type exists. */

[XmlInclude(Band::typeid)]
public ref class Orchestra
{
public:
   array<Instrument^>^Instruments;
};

// This is the overriding class.
public ref class Band: public Orchestra
{
public:
   String^ BandName;
};

public ref class Instrument
{
public:
   String^ Name;
};

void SerializeObject( String^ filename )
{
   /* Each object that is being overridden requires 
      an XmlAttributes object. */
   XmlAttributes^ attrs = gcnew XmlAttributes;

   // An XmlRootAttribute allows overriding the Orchestra class.
   XmlRootAttribute^ xmlRoot = gcnew XmlRootAttribute;

   // Set the object to the XmlAttribute.XmlRoot property.
   attrs->XmlRoot = xmlRoot;

   // Create an XmlAttributeOverrides object.
   XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;

   // Add the XmlAttributes to the XmlAttributeOverrrides.
   attrOverrides->Add( Orchestra::typeid, attrs );

   // Create the XmlSerializer using the XmlAttributeOverrides.
   XmlSerializer^ s = gcnew XmlSerializer( Orchestra::typeid,attrOverrides );

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create the object using the derived class.
   Band^ band = gcnew Band;
   band->BandName = "NewBand";

   // Create an Instrument.
   Instrument^ i = gcnew Instrument;
   i->Name = "Trumpet";
   array<Instrument^>^myInstruments = {i};
   band->Instruments = myInstruments;

   // Serialize the object.
   s->Serialize( writer, band );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlAttributes^ attrs = gcnew XmlAttributes;
   XmlRootAttribute^ attr = gcnew XmlRootAttribute;
   attrs->XmlRoot = attr;
   XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;
   attrOverrides->Add( Orchestra::typeid, "Instruments", attrs );
   XmlSerializer^ s = gcnew XmlSerializer( Orchestra::typeid,attrOverrides );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );

   // Deserialize the Band object.
   Band^ band = dynamic_cast<Band^>(s->Deserialize( fs ));
   Console::WriteLine( "Brass:" );
   System::Collections::IEnumerator^ myEnum = band->Instruments->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Instrument^ i = safe_cast<Instrument^>(myEnum->Current);
      Console::WriteLine( i->Name );
   }
}

int main()
{
   SerializeObject( "Override.xml" );
   DeserializeObject( "Override.xml" );
}
// </Snippet1>
