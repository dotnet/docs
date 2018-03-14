 '<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates



Class AsnEncodedDataSample
   Shared msg As String
   Shared Sub Main()
      'The following example demonstrates the usage the AsnEncodedData classes.
      ' Asn encoded data is read from the extensions of an X509 certificate.
      Try
         ' Open the certificate store.
         Dim store As New X509Store("MY", StoreLocation.CurrentUser)
         store.Open((OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly))
         Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
         Dim fcollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindByTimeValid, DateTime.Now, False), X509Certificate2Collection)
         ' Select one or more certificates to display extensions information.
         Dim scollection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(fcollection, "Certificate Select", "Select certificates from the following list to get extension information on that certificate", X509SelectionFlag.MultiSelection)
         
         ' Create a new AsnEncodedDataCollection object.
         Dim asncoll As New AsnEncodedDataCollection()
         Dim i As Integer
         For i = 0 To scollection.Count - 1
            ' Display certificate information.
	    msg = "Certificate name: "& scollection(i).GetName()
            MsgBox(msg)

            ' Display extensions information.
            Dim extension As X509Extension
            For Each extension In  scollection(i).Extensions
               ' Create an AsnEncodedData object using the extensions information.
               Dim asndata As New AsnEncodedData(extension.Oid, extension.RawData)
	       msg = "Extension type: " & extension.Oid.FriendlyName & Environment.NewLine & "Oid value: " & asndata.Oid.Value _
		& Environment.NewLine & "Raw data length: " & asndata.RawData.Length & Environment.NewLine _
		& asndata.Format(True) & Environment.NewLine
               MsgBox(msg)
		
               ' Add the AsnEncodedData object to the AsnEncodedDataCollection object.
               asncoll.Add(asndata)
            Next extension
         Next i
	 msg = "Number of AsnEncodedData items in the collection: " & asncoll.Count
         MsgBox(msg)         
         store.Close()

         'Create an enumerator for moving through the collection.
         Dim asne As AsnEncodedDataEnumerator = asncoll.GetEnumerator()
         'You must execute a MoveNext() to get to the first item in the collection.
         asne.MoveNext()
         ' Write out AsnEncodedData in the collection.
	 msg = "First AsnEncodedData in the collection: " & asne.Current.Format(True)
	 MsgBox(msg)
	
         
         asne.MoveNext()
	 msg = "Second AsnEncodedData in the collection: " & asne.Current.Format(True)
	 MsgBox(msg)
        
         'Return index in the collection to the beginning.
         asne.Reset()
      Catch 
         MsgBox("Information could not be written out for this certificate.")
      End Try
   End Sub 'Main
End Class 'AsnEncodedDataSample
'</SNIPPET1>