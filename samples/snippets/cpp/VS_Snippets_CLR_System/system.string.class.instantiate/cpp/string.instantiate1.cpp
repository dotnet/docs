// String.Instantiate1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

// <Snippet1>
using namespace System;

void main()
{
   String^ string1 = "This is a string created by assignment.";
   Console::WriteLine(string1);
   String^ string2a = "The path is C:\\PublicDocuments\\Report1.doc";
   Console::WriteLine(string2a);
}
// The example displays the following output: 
//       This is a string created by assignment. 
//       The path is C:\PublicDocuments\Report1.doc 
// </Snippet1>

