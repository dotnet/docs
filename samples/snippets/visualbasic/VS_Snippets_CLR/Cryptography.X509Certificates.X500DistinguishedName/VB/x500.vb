 '<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Security.Permissions
Imports System.IO
Imports System.Security.Cryptography.X509Certificates



Class X500Sample
   Shared msg As String
   Shared Sub Main()
	
      Try
         Dim store As New X509Store("MY", StoreLocation.CurrentUser)
         store.Open((OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly))
         Dim collection As X509Certificate2Collection = CType(store.Certificates, X509Certificate2Collection)
         Dim fcollection As X509Certificate2Collection = CType(collection.Find(X509FindType.FindByTimeValid, DateTime.Now, False), X509Certificate2Collection)
         Dim scollection As X509Certificate2Collection = X509Certificate2UI.SelectFromCollection(fcollection, "Test Certificate Select", "Select a certificate from the following list to get information on that certificate", X509SelectionFlag.MultiSelection)
	 msg = "Number of certificates: " & scollection.Count & Environment.NewLine
	 MsgBox(msg)
         Dim x509 As X509Certificate2
         For Each x509 In  scollection
            Dim dname As New X500DistinguishedName(x509.SubjectName)
	    msg = "X500DistinguishedName: " & dname.Name & Environment.NewLine
	 MsgBox(msg)
            x509.Reset()
         Next x509
         store.Close()
	 Catch e As Exception
            msg = "Error: Information could not be written out for this certificate."
            MsgBox(msg)
      End Try
   End Sub 'Main 
End Class 'X500Sample
'</SNIPPET1>