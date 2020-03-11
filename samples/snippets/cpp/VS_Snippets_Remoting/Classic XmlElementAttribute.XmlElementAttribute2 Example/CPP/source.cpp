

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml::Serialization;
public ref class Instrument
{
public:
   String^ Name;
};

public ref class Brass: public Instrument
{
public:
   bool IsValved;
};

public ref class Orchestra
{
public:
   array<Instrument^>^Instruments;
};

void SerializeObject( String^ filename )
{
   // To write the file, a TextWriter is required.
   TextWriter^ writer = gcnew StreamWriter( filename );
   XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;
   XmlAttributes^ attrs = gcnew XmlAttributes;

   // Creates an XmlElementAttribute that overrides the Instrument type.
   XmlElementAttribute^ attr = gcnew XmlElementAttribute( Brass::typeid );
   attr->ElementName = "Brass";

   // Adds the element to the collection of elements.
   attrs->XmlElements->Add( attr );
   attrOverrides->Add( Orchestra::typeid, "Instruments", attrs );

   // Creates the XmlSerializer using the XmlAttributeOverrides.
   XmlSerializer^ s = gcnew XmlSerializer( Orchestra::typeid,attrOverrides );

   // Creates the object to serialize.
   Orchestra^ band = gcnew Orchestra;

   // Creates an object of the derived type.
   Brass^ i = gcnew Brass;
   i->Name = "Trumpet";
   i->IsValved = true;
   array<Instrument^>^myInstruments = {i};
   band->Instruments = myInstruments;
   s->Serialize( writer, band );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;
   XmlAttributes^ attrs = gcnew XmlAttributes;

   // Creates an XmlElementAttribute that override the Instrument type.
   XmlElementAttribute^ attr = gcnew XmlElementAttribute( Brass::typeid );
   attr->ElementName = "Brass";

   // Adds the element to the collection of elements.
   attrs->XmlElements->Add( attr );
   attrOverrides->Add( Orchestra::typeid, "Instruments", attrs );

   // Creates the XmlSerializer using the XmlAttributeOverrides.
   XmlSerializer^ s = gcnew XmlSerializer( Orchestra::typeid,attrOverrides );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Orchestra^ band = dynamic_cast<Orchestra^>(s->Deserialize( fs ));
   Console::WriteLine( "Brass:" );

   /* Deserializing differs from serializing. To read the 
      derived-object values, declare an object of the derived 
      type (Brass) and cast the Instrument instance to it. */
   Brass^ b;
   System::Collections::IEnumerator^ myEnum = band->Instruments->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Instrument^ i = safe_cast<Instrument^>(myEnum->Current);
      b = dynamic_cast<Brass^>(i);
      Console::WriteLine( "{0}\n{1}", b->Name, b->IsValved );
   }
}

int main()
{
   SerializeObject( "Override.xml" );
   DeserializeObject( "Override.xml" );
}
// </Snippet1>
