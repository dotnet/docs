//<snippet1>
using namespace System;
using namespace System::Security;

void main()
{
    String^ msg = L"   The current length of the SecureString object: {0}\n";
    SecureString ^ ss = gcnew SecureString;

    Console::WriteLine(L"1) Instantiate the SecureString object:");
    Console::WriteLine(msg, ss->Length );

    Console::WriteLine(L"2) Append 'a' to the value:");
    ss->AppendChar('a');
    Console::WriteLine(msg, ss->Length );

    Console::WriteLine(L"3) Append 'X' to the value:");
    ss->AppendChar('X');
    Console::WriteLine(msg, ss->Length);

    Console::WriteLine(L"4) Append 'c' to the value:");
    ss->AppendChar('c');
    Console::WriteLine(msg, ss->Length);

    Console::WriteLine(L"5) Insert 'd' at the end of the value:");
    ss->InsertAt(ss->Length, 'd');
    Console::WriteLine(msg, ss->Length);

    Console::WriteLine(L"6) Remove the last character ('d') from the value:");
    ss->RemoveAt(3);
    Console::WriteLine(msg, ss->Length);

    Console::WriteLine(L"7) Set the second character ('X') of the value to 'b':" );
    ss->SetAt(1, 'b');
    Console::WriteLine(msg, ss->Length );

    Console::WriteLine(L"8) Delete the value of the SecureString object:");
    ss->Clear();
    Console::WriteLine(msg, ss->Length);

    delete ss;
}

/*
This code example produces the following results:

This example demonstrates the effect of the AppendChar, InsertAt,
RemoveAt, SetAt, and Clear methods on the value of a SecureString
object. This example simulates the value of the object because the
actual value is encrypted.

1) The initial value of the SecureString object:
   SecureString = ""
   Length = 0

2) AppendChar: Append 'a' to the value:
   SecureString = "a"
   Length = 1

3) AppendChar: Append 'X' to the value:
   SecureString = "aX"
   Length = 2

4) AppendChar: Append 'c' to the value:
   SecureString = "aXc"
   Length = 3

5) InsertAt: Insert 'd' at the end of the value (equivalent
     to AppendChar):
   SecureString = "aXcd"
   Length = 4

6) RemoveAt: Remove the last character ('d') from the value:
   SecureString = "aXc"
   Length = 3

7) SetAt: Set the second character ('X') of the value to 'b':
   SecureString = "abc"
   Length = 3

8) Clear: Delete the value of the SecureString object:
   SecureString = ""
   Length = 0
*/
//</snippet1>
