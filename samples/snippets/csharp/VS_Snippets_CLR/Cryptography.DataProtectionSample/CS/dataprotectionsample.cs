//<snippet1>
using System;
using System.Security.Cryptography;

public class DataProtectionSample
{
// Create byte array for additional entropy when using Protect method.
	static byte [] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

	public static void Main()
	{
// Create a simple byte array containing data to be encrypted.
		byte [] secret = { 0, 1, 2, 3, 4, 1, 2, 3, 4 };

//Encrypt the data.
		byte [] encryptedSecret = Protect( secret );
		Console.WriteLine("The encrypted byte array is:");
		PrintValues(encryptedSecret);
		
// Decrypt the data and store in a byte array.
		byte [] originalData = Unprotect( encryptedSecret );
		Console.WriteLine("{0}The original data is:", Environment.NewLine);
		PrintValues(originalData);

	}

	public static byte [] Protect( byte [] data )
	{
		try
		{
			// Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
			//  only by the same current user.
			return ProtectedData.Protect( data, s_aditionalEntropy, DataProtectionScope.CurrentUser );
		} 
		catch (CryptographicException e)
		{
			Console.WriteLine("Data was not encrypted. An error occurred.");
			Console.WriteLine(e.ToString());
			return null;
		}
	}

	public static byte [] Unprotect( byte [] data )
	{
		try
		{
			//Decrypt the data using DataProtectionScope.CurrentUser.
			return ProtectedData.Unprotect( data, s_aditionalEntropy, DataProtectionScope.CurrentUser );
		} 
		catch (CryptographicException e)
		{
			Console.WriteLine("Data was not decrypted. An error occurred.");
			Console.WriteLine(e.ToString());
			return null;
		}
	}

	public static void PrintValues( Byte[] myArr )  
	{
	      foreach ( Byte i in myArr )  
		  	{
		         Console.Write( "\t{0}", i );
			 }
      Console.WriteLine();
	 }

}
//</snippet1>

