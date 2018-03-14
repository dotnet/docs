// String.Normalize.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet14>
using namespace System;
using namespace System::Globalization;
using namespace System::IO;
using namespace System::Text;

public ref class Example
{
private:
   StreamWriter^ sw;

   void TestForEquality(... array<String^>^  words)
   {
      for (int ctr = 0; ctr <= words->Length - 2; ctr++)
         for (int ctr2 = ctr + 1; ctr2 <= words->Length - 1; ctr2++) 
            sw->WriteLine("{0} ({1}) = {2} ({3}): {4}", 
                         words[ctr], ShowBytes(words[ctr]),
                         words[ctr2], ShowBytes(words[ctr2]),
                         words[ctr]->Equals(words[ctr2], StringComparison::Ordinal));
   }

   String^ ShowBytes(String^ str)
   {
      String^ result = nullptr;
      for each (Char ch in str)
         result += String::Format("{0} ", Convert::ToUInt16(ch).ToString("X4")); 
      return result->Trim();            
   } 

   array<String^>^ NormalizeStrings(NormalizationForm nf, ... array<String^>^ words)
   {
      for (int ctr = 0; ctr < words->Length; ctr++)
         if (! words[ctr]->IsNormalized(nf))
            words[ctr] = words[ctr]->Normalize(nf); 
      return words;   
   }

public: 
   void Execute()
   {
      sw = gcnew StreamWriter(".\\TestNorm1.txt");

      // Define three versions of the same word.  
      String^ s1 = L"sống";        // create word with U+1ED1 
      String^ s2 = L"s\x00F4\x0301ng";
      String^ s3 = L"so\x0302\x0301ng";

      TestForEquality(s1, s2, s3);      
      sw->WriteLine();

      // Normalize and compare strings using each normalization form. 
      for each (String^ formName in Enum::GetNames(NormalizationForm::typeid))
      {
         sw->WriteLine("Normalization {0}:\n", formName); 
         NormalizationForm nf = (NormalizationForm) Enum::Parse(NormalizationForm::typeid, formName);
         array<String^>^ sn = NormalizeStrings(nf, s1, s2, s3 );
         TestForEquality(sn);           
         sw->WriteLine("\n");                                        
      }

      sw->Close(); 
   }
};

void main()
{
   Example^ ex = gcnew Example();
   ex->Execute();
}
// The example produces the following output:
// The example displays the following output: 
//       sống (0073 1ED1 006E 0067) = sống (0073 00F4 0301 006E 0067): False 
//       sống (0073 1ED1 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False 
//       sống (0073 00F4 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False 
//        
//       Normalization FormC: 
//        
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True 
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True 
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True 
//        
//        
//       Normalization FormD: 
//        
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True 
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True 
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True 
//        
//        
//       Normalization FormKC: 
//        
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True 
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True 
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True 
//        
//        
//       Normalization FormKD: 
//        
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True 
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True 
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
// </Snippet14>
