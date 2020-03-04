// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

ref class StringContainer
{
private:
   // A generic list object that holds the strings.
   List<String^>^ container = gcnew List<String^>;

public:
   // Define a delegate to handle string display.
   delegate void CheckAndDisplayDelegate(String^ str);

   // A method that adds more strings to the collection.
   void AddString(String^ str)
   {
      container->Add(str);
   }

   // Iterate through the strings and invoke the method(s) that the delegate points to.
   void DisplayAllQualified(CheckAndDisplayDelegate^ displayDelegate)
   {
      for each (String^ str in container)
         displayDelegate(str);
//       System::Collections::IEnumerator^ myEnum = container->GetEnumerator();
//       while ( myEnum->MoveNext() )
//       {
//          String^ str = safe_cast<String^>(myEnum->Current);
//          displayDelegate(str);
//      }
   }
};

//end of class StringContainer
// This class contains a few sample methods
ref class StringFuncs
{
public:

   // This method prints a String* that it is passed if the String* starts with a vowel
   static void ConStart(String^ str)
   {
      if (  !(str[ 0 ] == 'a' || str[ 0 ] == 'e' || str[ 0 ] == 'i' || str[ 0 ] == 'o' || str[ 0 ] == 'u') )
            Console::WriteLine( str );
   }

   // This method prints a String* that it is passed if the String* starts with a consonant
   static void VowelStart( String^ str )
   {
      if ( (str[ 0 ] == 'a' || str[ 0 ] == 'e' || str[ 0 ] == 'i' || str[ 0 ] == 'o' || str[ 0 ] == 'u') )
            Console::WriteLine( str );
   }
};

// This function demonstrates using Delegates, including using the Remove and
// Combine methods to create and modify delegate combinations.
int main()
{
   // Declare the StringContainer class and add some strings
   StringContainer^ container = gcnew StringContainer;
   container->AddString( "This" );
   container->AddString( "is" );
   container->AddString( "a" );
   container->AddString( "multicast" );
   container->AddString( "delegate" );
   container->AddString( "example" );

// RETURN HERE.
   // Create two delegates individually using different methods
   StringContainer::CheckAndDisplayDelegate^ conStart = gcnew StringContainer::CheckAndDisplayDelegate( StringFuncs::ConStart );
   StringContainer::CheckAndDisplayDelegate^ vowelStart = gcnew StringContainer::CheckAndDisplayDelegate( StringFuncs::VowelStart );

   // Get the list of all delegates assigned to this MulticastDelegate instance. 
   array<Delegate^>^ delegateList = conStart->GetInvocationList();
   Console::WriteLine("conStart contains {0} delegate(s).", delegateList->Length);
   delegateList = vowelStart->GetInvocationList();
   Console::WriteLine("vowelStart contains {0} delegate(s).\n", delegateList->Length );

   // Determine whether the delegates are System::Multicast delegates
   if ( dynamic_cast<System::MulticastDelegate^>(conStart) && dynamic_cast<System::MulticastDelegate^>(vowelStart) )
   {
      Console::WriteLine("conStart and vowelStart are derived from MulticastDelegate.\n");
   }

   // Execute the two delegates.
   Console::WriteLine("Executing the conStart delegate:" );
   container->DisplayAllQualified(conStart);
   Console::WriteLine();
   Console::WriteLine("Executing the vowelStart delegate:" );
   container->DisplayAllQualified(vowelStart);

   // Create a new MulticastDelegate and call Combine to add two delegates.
   StringContainer::CheckAndDisplayDelegate^ multipleDelegates =
           dynamic_cast<StringContainer::CheckAndDisplayDelegate^>(Delegate::Combine(conStart, vowelStart));

   // How many delegates does multipleDelegates contain?
   delegateList = multipleDelegates->GetInvocationList();
   Console::WriteLine("\nmultipleDelegates contains {0} delegates.\n", 
                      delegateList->Length );

   //       // Pass this multicast delegate to DisplayAllQualified.
   Console::WriteLine("Executing the multipleDelegate delegate.");
   container->DisplayAllQualified(multipleDelegates);
   // Call remove and combine to change the contained delegates.
   multipleDelegates = dynamic_cast<StringContainer::CheckAndDisplayDelegate^>
                      (Delegate::Remove(multipleDelegates, vowelStart));
   multipleDelegates = dynamic_cast<StringContainer::CheckAndDisplayDelegate^>
                      (Delegate::Combine(multipleDelegates, conStart));

   // Pass multipleDelegates to DisplayAllQualified again.
   Console::WriteLine("\nExecuting the multipleDelegate delegate with two conStart delegates:");
   container->DisplayAllQualified(multipleDelegates);
} 
// The example displays the following output:
//    conStart contains 1 delegate(s).
//    vowelStart contains 1 delegate(s).
//    
//    conStart and vowelStart are derived from MulticastDelegate.
//    
//    Executing the conStart delegate:
//    This
//    multicast
//    delegate
//    
//    Executing the vowelStart delegate:
//    is
//    a
//    example
//    
//    
//    multipleDelegates contains 2 delegates.
//    
//    Executing the multipleDelegate delegate.
//    This
//    is
//    a
//    multicast
//    delegate
//    example
//    
//    Executing the multipleDelegate delegate with two conStart delegates:
//    This
//    This
//    multicast
//    multicast
//    delegate
//    delegate
//</Snippet1>
