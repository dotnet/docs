//<SNIPPET1>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;

int main()
{
   
   // Create the original data to be encrypted (The data length should be a multiple of 16).
   array<Byte>^secret = {1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4};
   
   // Encrypt the data in memory. The result is stored in the same same array as the original data.
   ProtectedMemory::Protect( secret, MemoryProtectionScope::SameLogon );
   
   // Decrypt the data in memory and store in the original array.
   ProtectedMemory::Unprotect( secret, MemoryProtectionScope::SameLogon );
}
//</SNIPPET1>
