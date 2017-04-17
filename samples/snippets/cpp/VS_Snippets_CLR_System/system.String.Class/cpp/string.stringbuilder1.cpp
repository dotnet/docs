// String.StringBuilder1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

// <Snippet15>
using namespace System;
using namespace System::IO;
using namespace System::Text;

void main()
{
   Random^ rnd = gcnew Random();

   String^ str = String::Empty;
   StreamWriter^ sw = gcnew StreamWriter(".\\StringFile.txt", 
                        false, Encoding::Unicode);

   for (int ctr = 0; ctr <= 1000; ctr++) {
      str += Convert::ToChar(rnd->Next(1, 0x0530)); 
      if (str->Length % 60 == 0)
         str += Environment::NewLine;          
   }                    
   sw->Write(str);
   sw->Close();
}
// </Snippet15>

