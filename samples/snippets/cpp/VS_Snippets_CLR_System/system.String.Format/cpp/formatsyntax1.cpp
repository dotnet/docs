// FormatSyntax1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"

using namespace System;

void main()
{
   String^ value =
// <Snippet12>
String::Format("{0,-10:C}", (Decimal) 126347.89);         
// </Snippet12>
}


