// String.Casing.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet7>
using namespace System;
using namespace System::Globalization;
using namespace System::IO;

String^ ShowHexValue(String^ s);

void main()
{
   StreamWriter^ sw = gcnew StreamWriter(".\\case.txt");   
   array<String^>^ words = gcnew array<String^> { L"file", L"sıfır", L"ǅenana" };
   array<CultureInfo^>^ cultures = gcnew array<CultureInfo^> { CultureInfo::InvariantCulture, 
                                                               gcnew CultureInfo("en-US"),  
                                                               gcnew CultureInfo("tr-TR") };

   for each (String^ word in words) {
      sw->WriteLine("{0}:", word);
      for each (CultureInfo^ culture in cultures) {
         String^ name = String::IsNullOrEmpty(culture->Name) ? 
                              "Invariant" : culture->Name;
         String^ upperWord = word->ToUpper(culture);
         sw->WriteLine("   {0,10}: {1,7} {2, 38}", name, 
                        upperWord, ShowHexValue(upperWord));

      }
      sw->WriteLine();  
   }
   sw->Close();
}

String^ ShowHexValue(String^ s)
{
   String^ retval = nullptr;
   for each (Char ch in s) {
      array<Byte>^ bytes = BitConverter::GetBytes(ch);
      retval += String::Format("{0:X2} {1:X2} ", bytes[1], bytes[0]);     
   }
   return retval;
} 
// The example displays the following output: 
//    file: 
//        Invariant:    FILE               00 46 00 49 00 4C 00 45  
//            en-US:    FILE               00 46 00 49 00 4C 00 45  
//            tr-TR:    FİLE               00 46 01 30 00 4C 00 45  
//     
//    sıfır: 
//        Invariant:   SıFıR         00 53 01 31 00 46 01 31 00 52  
//            en-US:   SIFIR         00 53 00 49 00 46 00 49 00 52  
//            tr-TR:   SIFIR         00 53 00 49 00 46 00 49 00 52  
//     
//    ǅenana: 
//        Invariant:  ǅENANA   01 C5 00 45 00 4E 00 41 00 4E 00 41  
//            en-US:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41  
//            tr-TR:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41 
// </Snippet7>
