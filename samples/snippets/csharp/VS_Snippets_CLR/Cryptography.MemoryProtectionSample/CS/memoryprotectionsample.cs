//<SNIPPET1>
using System;
using System.Security.Cryptography;

public class MemoryProtectionSample
{

	public static void Main()
	{
// Create the original data to be encrypted (The data length should be a multiple of 16).
		
byte [] secret = { 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 };

// Encrypt the data in memory. The result is stored in the same same array as the original data.
		ProtectedMemory.Protect( secret, MemoryProtectionScope.SameLogon );
	
// Decrypt the data in memory and store in the original array.
		ProtectedMemory.Unprotect( secret, MemoryProtectionScope.SameLogon );
	}

}
//</SNIPPET1>