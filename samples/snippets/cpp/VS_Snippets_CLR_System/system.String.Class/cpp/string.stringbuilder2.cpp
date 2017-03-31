// String.StringBuilder2.cpp : Defines the entry point for the console application.
//
//#include "stdafx.h"

// <Snippet16>
using namespace System;
using namespace System::IO;
using namespace System::Text;

void main()
{
   Random^ rnd = gcnew Random();

   StringBuilder^ sb = gcnew StringBuilder();
   StreamWriter^ sw = gcnew StreamWriter(".\\StringFile.txt", 
                        false, Encoding::Unicode);

   for (int ctr = 0; ctr <= 1000; ctr++) {
      sb->Append(Convert::ToChar(rnd->Next(1, 0x0530))); 
      if (sb->Length % 60 == 0)
         sb->AppendLine();          
   }                    
   sw->Write(sb->ToString());
   sw->Close();
}
// </Snippet16>

