//<SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class AsnEncodedDataSample
{
	static void Main()
	{		
		//The following example demonstrates the usage the AsnEncodedData classes.
		// Asn encoded data is read from the extensions of an X509 certificate.
		try
		{
			// Open the certificate store.
			X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
			store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
			X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
			X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
			// Select one or more certificates to display extensions information.
			X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(fcollection, "Certificate Select", "Select certificates from the following list to get extension information on that certificate", X509SelectionFlag.MultiSelection);

			// Create a new AsnEncodedDataCollection object.
			AsnEncodedDataCollection asncoll = new AsnEncodedDataCollection();
			for (int i = 0; i < scollection.Count; i++)
			{
				// Display certificate information.
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Certificate name: {0}", scollection[i].GetName());
				Console.ResetColor();
				// Display extensions information.
				foreach (X509Extension extension in scollection[i].Extensions)
				{
					// Create an AsnEncodedData object using the extensions information.
					AsnEncodedData asndata = new AsnEncodedData(extension.Oid, extension.RawData);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Extension type: {0}", extension.Oid.FriendlyName);
					Console.WriteLine("Oid value: {0}",asndata.Oid.Value);
					Console.WriteLine("Raw data length: {0} {1}", asndata.RawData.Length, Environment.NewLine);
					Console.ResetColor();
					Console.WriteLine(asndata.Format(true));
					Console.WriteLine(Environment.NewLine);
					// Add the AsnEncodedData object to the AsnEncodedDataCollection object.
					asncoll.Add(asndata);
				}
				Console.WriteLine(Environment.NewLine);
			}
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Number of AsnEncodedData items in the collection: {0} {1}", asncoll.Count, Environment.NewLine);
			Console.ResetColor();

			store.Close();
			//Create an enumerator for moving through the collection.
			AsnEncodedDataEnumerator asne = asncoll.GetEnumerator();
			//You must execute a MoveNext() to get to the first item in the collection.
			asne.MoveNext();
			// Write out AsnEncodedData in the collection.
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("First AsnEncodedData in the collection: {0}", asne.Current.Format(true));
			Console.ResetColor();

			asne.MoveNext();
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("Second AsnEncodedData in the collection: {0}", asne.Current.Format(true));
			Console.ResetColor();
			//Return index in the collection to the beginning.
			asne.Reset();
		}
		catch (CryptographicException)
		{
			Console.WriteLine("Information could not be written out for this certificate.");
		}
	}
}
	//</SNIPPET1>