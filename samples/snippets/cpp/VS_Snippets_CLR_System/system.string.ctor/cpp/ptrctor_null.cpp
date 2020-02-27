// <Snippet6>
using namespace System;

void main()
{
   char bytes[] = { 0x61, 0x62, 0x063, 0x064, 0x00, 0x41, 0x42,0x43, 
                    0x44, 0x00 };
   
   char* bytePtr = bytes;
   String^ s = gcnew String(bytePtr, 0, sizeof(bytes) / sizeof (char));
   
   for each (Char ch in s)
      Console::Write("{0:X4} ", Convert::ToUInt16(ch));
   
   Console::WriteLine();
   
   s = gcnew String(bytePtr);

   for each (Char ch in s)
      Console::Write("{0:X4} ", Convert::ToUInt16(ch));
   Console::WriteLine();       
}
// The example displays the following output:
//      0061 0062 0063 0064 0000 0041 0042 0043 0044 0000
//      0061 0062 0063 0064
// </Snippet6>

