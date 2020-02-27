// <Snippet5>
using namespace System;

void main()
{
   wchar_t chars[] = { L'a', L'b', L'c', L'd', L'\0', L'A', L'B', 
                       L'C', L'D', L'\0' };
   Char* chPtr = chars;
   String^ s = gcnew String(chPtr, 0, 
                            sizeof(chars) / sizeof (wchar_t));            
   for each (Char ch in s)
      Console::Write("{0:X4} ", Convert::ToUInt16(ch));
   Console::WriteLine();
   
   s = gcnew String(chPtr);         
   
   for each (Char ch in s)
      Console::Write("{0:X4} ", Convert::ToUInt16(ch));
   Console::WriteLine();    
}
// The example displays the following output:
//       0061 0062 0063 0064 0000 0041 0042 0043 0044 0000
//       0061 0062 0063 0064
// </Snippet5>
