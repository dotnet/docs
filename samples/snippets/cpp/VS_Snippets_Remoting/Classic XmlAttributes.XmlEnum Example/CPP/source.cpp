

// <Snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
public enum class FoodType
{
   // Subsequent code overrides these enumerations.
   Low, High
};

// This is the class that will be serialized.
public ref class Food
{
public:
   FoodType Type;
};

// Return an XmlSerializer used for overriding. 
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributeOverrides and XmlAttributes objects.
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAttrs = gcnew XmlAttributes;

   // Add an XmlEnumAttribute for the FoodType.Low enumeration.
   XmlEnumAttribute^ xEnum = gcnew XmlEnumAttribute;
   xEnum->Name = "Cold";
   xAttrs->XmlEnum = xEnum;
   xOver->Add( FoodType::typeid, "Low", xAttrs );

   // Add an XmlEnumAttribute for the FoodType.High enumeration.
   xAttrs = gcnew XmlAttributes;
   xEnum = gcnew XmlEnumAttribute;
   xEnum->Name = "Hot";
   xAttrs->XmlEnum = xEnum;
   xOver->Add( FoodType::typeid, "High", xAttrs );

   // Create the XmlSerializer, and return it.
   return gcnew XmlSerializer( Food::typeid,xOver );
}

void SerializeObject( String^ filename )
{
   // Create an instance of the XmlSerializer class.
   XmlSerializer^ mySerializer = CreateOverrider();

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create an instance of the class that will be serialized.
   Food^ myFood = gcnew Food;

   // Set the object properties.
   myFood->Type = FoodType::High;

   // Serialize the class, and close the TextWriter.
   mySerializer->Serialize( writer, myFood );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ mySerializer = CreateOverrider();
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Food^ myFood = dynamic_cast<Food^>(mySerializer->Deserialize( fs ));
   Console::WriteLine( myFood->Type );
}

int main()
{
   SerializeObject( "OverrideEnum.xml" );
   DeserializeObject( "OverrideEnum.xml" );
}
// </Snippet1>
