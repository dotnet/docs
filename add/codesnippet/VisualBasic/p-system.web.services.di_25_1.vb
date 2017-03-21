         ' Enumerate the 'References' in the DiscoveryDocument.
         Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
         Console.WriteLine("The 'References' in the discovery document are-")
         While myEnumerator.MoveNext()
            Console.Write(CType(myEnumerator.Current, DiscoveryDocumentReference).Url)
         End While