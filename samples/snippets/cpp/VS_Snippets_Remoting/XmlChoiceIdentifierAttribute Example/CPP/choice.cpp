

//<Snippet1>
#using <System.dll>
#using <System.xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::IO;

[XmlType(IncludeInSchema=false)]

public enum class ItemChoiceType
{
   None, Word, Number, DecimalNumber
};

public enum class MoreChoices
{
   None, Item, Amount, Temp
};

public ref class Choices
{
public:

   // The MyChoice field can be set to any one of 
   // the types below. 

   [XmlChoiceIdentifier("EnumType")]
   [XmlElement("Word",String::typeid)]
   [XmlElement("Number",Int32::typeid)]
   [XmlElement("DecimalNumber",Double::typeid)]
   Object^ MyChoice;

   // Don't serialize this field. The EnumType field
   // contains the enumeration value that corresponds
   // to the MyChoice field value.

   [XmlIgnore]
   ItemChoiceType EnumType;

   // The ManyChoices field can contain an array
   // of choices. Each choice must be matched to
   // an array item in the ChoiceArray field.

   [XmlChoiceIdentifier("ChoiceArray")]
   [XmlElement("Item",String::typeid)]
   [XmlElement("Amount",Int32::typeid)]
   [XmlElement("Temp",Double::typeid)]
   array<Object^>^ManyChoices;

   // TheChoiceArray field contains the enumeration
   // values, one for each item in the ManyChoices array.

   [XmlIgnore]
   array<MoreChoices>^ChoiceArray;
};

void SerializeObject( String^ filename );
void DeserializeObject( String^ filename );
int main()
{
   SerializeObject( "Choices.xml" );
   DeserializeObject( "Choices.xml" );
}

void SerializeObject( String^ filename )
{
   XmlSerializer^ mySerializer = gcnew XmlSerializer( Choices::typeid );
   TextWriter^ writer = gcnew StreamWriter( filename );
   Choices^ myChoices = gcnew Choices;

   // Set the MyChoice field to a string. Set the
   // EnumType to Word.
   myChoices->MyChoice = "Book";
   myChoices->EnumType = ItemChoiceType::Word;

   // Populate an object array with three items, one
   // of each enumeration type. Set the array to the 
   // ManyChoices field.
   array<Object^>^strChoices = {"Food",5,98.6};
   myChoices->ManyChoices = strChoices;

   // For each item in the ManyChoices array, add an
   // enumeration value.
   array<MoreChoices>^ itmChoices = {MoreChoices::Item,MoreChoices::Amount,MoreChoices::Temp};
   myChoices->ChoiceArray = itmChoices;
   mySerializer->Serialize( writer, myChoices );
   writer->Close();
}

void DeserializeObject( String^ filename )
{
   XmlSerializer^ ser = gcnew XmlSerializer( Choices::typeid );

   // A FileStream is needed to read the XML document.
   FileStream^ fs = gcnew FileStream( filename,FileMode::Open );
   Choices^ myChoices = safe_cast<Choices^>(ser->Deserialize( fs ));
   fs->Close();

   // Disambiguate the MyChoice value using the enumeration.
   if ( myChoices->EnumType == ItemChoiceType::Word )
   {
      Console::WriteLine( "Word: {0}", myChoices->MyChoice->ToString() );
   }
   else
   if ( myChoices->EnumType == ItemChoiceType::Number )
   {
      Console::WriteLine( "Number: {0}", myChoices->MyChoice->ToString() );
   }
   else
   if ( myChoices->EnumType == ItemChoiceType::DecimalNumber )
   {
      Console::WriteLine( "DecimalNumber: {0}", myChoices->MyChoice->ToString() );
   }

   // Disambiguate the ManyChoices values using the enumerations.
   for ( int i = 0; i < myChoices->ManyChoices->Length; i++ )
   {
      if ( myChoices->ChoiceArray[ i ] == MoreChoices::Item )
            Console::WriteLine( "Item: {0}", myChoices->ManyChoices[ i ] );
      else
      if ( myChoices->ChoiceArray[ i ] == MoreChoices::Amount )
            Console::WriteLine( "Amount: ", myChoices->ManyChoices[ i ]->ToString() );
      if ( myChoices->ChoiceArray[ i ] == MoreChoices::Temp )
            Console::WriteLine( "Temp: {0}", myChoices->ManyChoices[ i ]->ToString() );
   }
}
//</Snippet1>
