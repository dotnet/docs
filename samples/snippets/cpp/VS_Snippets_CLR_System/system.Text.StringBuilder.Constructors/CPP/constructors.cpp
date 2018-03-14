// This sample demonstrates how to use each member of the StringBuilder class.
//<Snippet2>
using namespace System;
using namespace System::Text;

ref class Constructors
{
public:
   static void Main()
   {
      ConstructorWithNothing();
      ConstructorWithCapacity();
      ConstructorWithString();
      ConstructorWithCapacityAndMax();
      ConstructorWithSubstring();
      ConstructorWithStringAndMax();

      Console::Write( L"This sample completed successfully; " );
      Console::WriteLine( L"press Enter to exit." );
      Console::ReadLine();
   }

private:
   static void ConstructorWithNothing()
   {
      // Initialize a new StringBuilder object.
      //<Snippet1>
      StringBuilder^ stringBuilder = gcnew StringBuilder;
      //</Snippet1>
   }

   static void ConstructorWithCapacity()
   {
      // Initialize a new StringBuilder object with the specified capacity.
      //<Snippet3>
      int capacity = 255;
      StringBuilder^ stringBuilder = gcnew StringBuilder( capacity );
      //</Snippet3>
   }

   static void ConstructorWithString()
   {
      // Initialize a new StringBuilder object with the specified string.
      //<Snippet4>
      String^ initialString = L"Initial string.";
      StringBuilder^ stringBuilder = gcnew StringBuilder( initialString );
      //</Snippet4>
   }

   static void ConstructorWithCapacityAndMax()
   {
      // Initialize a new StringBuilder object with the specified capacity
      // and maximum capacity.
      //<Snippet5>
      int capacity = 255;
      int maxCapacity = 1024;
      StringBuilder^ stringBuilder = gcnew StringBuilder( capacity,maxCapacity );
      //</Snippet5>
   }

   static void ConstructorWithSubstring()
   {
      // Initialize a new StringBuilder object with the specified substring.
      //<Snippet6>
      String^ initialString = L"Initial string for stringbuilder.";
      int startIndex = 0;
      int substringLength = 14;
      int capacity = 255;
      StringBuilder^ stringBuilder = gcnew StringBuilder(
         initialString,startIndex,substringLength,capacity );
      //</Snippet6>
   }

   static void ConstructorWithStringAndMax()
   {
      // Initialize a new StringBuilder object with the specified string
      // and maximum capacity.
      //<Snippet7>
      String^ initialString = L"Initial string. ";
      int capacity = 255;
      StringBuilder^ stringBuilder = gcnew StringBuilder(
         initialString,capacity );
      //</Snippet7>

      // Ensure that appending the specified string will not exceed the
      // maximum capacity of the object.
      //<Snippet8>
      String^ phraseToAdd = L"Sentence to be appended.";
      if ( (stringBuilder->Length + phraseToAdd->Length) <=
         stringBuilder->MaxCapacity )
      {
         stringBuilder->Append( phraseToAdd );
      }
      //</Snippet8>

      // Retrieve the string value of the StringBuilder object.
      //<Snippet9>
      String^ builderResults = stringBuilder->ToString();
      //</Snippet9>

      // Retrieve the last 10 characters of the StringBuilder object.
      //<Snippet10>
      int sentenceLength = 10;
      int startPosition = stringBuilder->Length - sentenceLength;
      String^ endPhrase = stringBuilder->ToString( startPosition,
         sentenceLength );
      //</Snippet10>

      // Retrieve the last character of the StringBuilder object.
      //<Snippet11>
      int lastCharacterPosition = stringBuilder->Length - 1;
      char lastCharacter = static_cast<char>(
         stringBuilder->default[ lastCharacterPosition ] );
      //</Snippet11>
   }
};

int main()
{
   Constructors::Main();
}

//
// This sample produces the following output:
//
// This sample completed successfully; press Enter to exit.
//</Snippet2>
