// String.Compare2.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet12>
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::Globalization;

// IComparer<String> implementation to perform string sort. 
ref class SCompare : System::Collections::Generic::IComparer<String^>
{
public:
   SCompare() {};

   virtual int Compare(String^ x, String^ y)
   {
      return CultureInfo::CurrentCulture->CompareInfo->Compare(x, y, CompareOptions::StringSort);
   }
};

void main()
{
   array<String^>^ strings = gcnew array<String^> { "coop", "co-op", "cooperative", 
                                                    L"co\x00ADoperative", L"cœur", "coeur" };

   // Perform a word sort using the current (en-US) culture. 
   array<String^>^ current = gcnew array<String^>(strings->Length); 
   strings->CopyTo(current, 0); 
   Array::Sort(current, StringComparer::CurrentCulture);

   // Perform a word sort using the invariant culture. 
   array<String^>^ invariant = gcnew array<String^>(strings->Length);
   strings->CopyTo(invariant, 0); 
   Array::Sort(invariant, StringComparer::InvariantCulture);

   // Perform an ordinal sort. 
   array<String^>^ ordinal = gcnew array<String^>(strings->Length);
   strings->CopyTo(ordinal, 0); 
   Array::Sort(ordinal, StringComparer::Ordinal);

   // Perform a string sort using the current culture. 
   array<String^>^ stringSort = gcnew array<String^>(strings->Length);
   strings->CopyTo(stringSort, 0); 
   Array::Sort(stringSort, gcnew SCompare());

   // Display array values
   Console::WriteLine("{0,13} {1,13} {2,15} {3,13} {4,13}\n", 
                     "Original", "Word Sort", "Invariant Word", 
                     "Ordinal Sort", "String Sort");
   for (int ctr = 0; ctr < strings->Length; ctr++)
      Console::WriteLine("{0,13} {1,13} {2,15} {3,13} {4,13}", 
                         strings[ctr], current[ctr], invariant[ctr], 
                         ordinal[ctr], stringSort[ctr] );          
}
// The example displays the following output: 
//         Original     Word Sort  Invariant Word  Ordinal Sort   String Sort 
//     
//             coop          cœur            cœur         co-op         co-op 
//            co-op         coeur           coeur         coeur          cœur 
//      cooperative          coop            coop          coop         coeur 
//      co­operative         co-op           co-op   cooperative          coop 
//             cœur   cooperative     cooperative   co­operative   cooperative 
//            coeur   co­operative     co­operative          cœur   co­operative
// </Snippet12>

