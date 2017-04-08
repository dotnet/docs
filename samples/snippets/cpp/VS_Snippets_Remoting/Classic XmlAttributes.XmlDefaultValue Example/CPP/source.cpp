

// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::ComponentModel;

// This is the class that will be serialized. 
public ref class Pet
{
public:

   // The default value for the Animal field is "Dog". 

   [DefaultValueAttribute("Dog")]
   String^ Animal;
};

// Return an XmlSerializer used for overriding. 
XmlSerializer^ CreateOverrider()
{
   // Create the XmlAttributeOverrides and XmlAttributes objects. 
   XmlAttributeOverrides^ xOver = gcnew XmlAttributeOverrides;
   XmlAttributes^ xAttrs = gcnew XmlAttributes;

   // Add an override for the default value of the GroupName. 
   Object^ defaultAnimal = "Cat";
   xAttrs->XmlDefaultValue = defaultAnimal;

   // Add all the XmlAttributes to the XmlAttributeOverrides object. 
   xOver->Add( Pet::typeid, "Animal", xAttrs );

   // Create the XmlSerializer and return it.
   return gcnew XmlSerializer( Pet::typeid,xOver );
}

void SerializeObject( String^ filename )
{
   // Create an instance of the XmlSerializer class.
   XmlSerializer^ mySerializer = CreateOverrider();

   // Writing the file requires a TextWriter.
   TextWriter^ writer = gcnew StreamWriter( filename );

   // Create an instance of the class that will be serialized. 
   Pet^ myPet = gcnew Pet;

   /* Set the Animal property. If you set it to the default value,
      which is "Cat" (the value assigned to the XmlDefaultValue
      of the XmlAttributes object), no value will be serialized.
      If you change the value to any other value (including "Dog"),
      the value will be serialized.
      */
   // The default value "Cat" will be assigned (nothing serialized).
   myPet->Animal = "";

   // Uncommenting the next line also results in the default 
   // value because Cat is the default value (not serialized).
   //  myPet.Animal = "Cat"; 
   // Uncomment the next line to see the value serialized:
   // myPet.Animal = "fish";
   // This will also be serialized because Dog is not the 
   // default anymore.
   //  myPet.Animal = "Dog";
   // Serialize the class, and close the TextWriter. 
   mySerializer->Serialize( writer, myPet );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ mySerializer = CreateOverrider();
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Pet^ myPet = dynamic_cast<Pet^>(mySerializer->Deserialize( fs ));
   Console::WriteLine( myPet->Animal );
}

int main()
{
   SerializeObject( "OverrideDefaultValue.xml" );
   DeserializeObject( "OverrideDefaultValue.xml" );
}
// </Snippet1>
