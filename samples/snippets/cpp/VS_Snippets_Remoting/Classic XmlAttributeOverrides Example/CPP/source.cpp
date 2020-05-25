

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
   /* Each overridden field, property, or type requires 
      an XmlAttributes object. */
   XmlAttributes^ attrs = gcnew XmlAttributes;

   /* Create an XmlElementAttribute to override the 
      field that returns Instrument objects. The overridden field
      returns Brass objects instead. */
   XmlElementAttribute^ attr = gcnew XmlElementAttribute;
   attr->ElementName = "Brass";
   attr->Type = Brass::typeid;

   // Add the element to the collection of elements.
   attrs->XmlElements->Add( attr );

   // Create the XmlAttributeOverrides object.
   XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;

   /* Add the type of the class that contains the overridden 
      member and the XmlAttributes to override it with to the 
      XmlAttributeOverrides object. */
   attrOverrides->Add( Orchestra::typeid, "Instruments", attrs );

   // Create the XmlSerializer using the XmlAttributeOverrides.
   XmlSerializer^ s = gcnew XmlSerializer( Orchestra::typeid,attrOverrides );

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create the object that will be serialized.
   Orchestra^ band = gcnew Orchestra;

   // Create an object of the derived type.
   Brass^ i = gcnew Brass;
   i->Name = "Trumpet";
   i->IsValved = true;
   array<Instrument^>^myInstruments = {i};
   band->Instruments = myInstruments;

   // Serialize the object.
   s->Serialize( writer, band );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlAttributeOverrides^ attrOverrides = gcnew XmlAttributeOverrides;
   XmlAttributes^ attrs = gcnew XmlAttributes;

   // Create an XmlElementAttribute to override the Instrument.
   XmlElementAttribute^ attr = gcnew XmlElementAttribute;
   attr->ElementName = "Brass";
   attr->Type = Brass::typeid;

   // Add the XmlElementAttribute to the collection of objects.
   attrs->XmlElements->Add( attr );
   attrOverrides->Add( Orchestra::typeid, "Instruments", attrs );

   // Create the XmlSerializer using the XmlAttributeOverrides.
   XmlSerializer^ s = gcnew XmlSerializer( Orchestra::typeid,attrOverrides );
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Orchestra^ band = dynamic_cast<Orchestra^>(s->Deserialize( fs ));
   Console::WriteLine( "Brass:" );

   /* The difference between deserializing the overridden 
      XML document and serializing it is this: To read the derived 
      object values, you must declare an object of the derived type 
      (Brass), and cast the Instrument instance to it. */
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
