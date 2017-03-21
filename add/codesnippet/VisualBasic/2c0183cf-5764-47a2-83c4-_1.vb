         Dim i As Integer
         For i = 0 To myDiscoveryClientResultCollection.Count - 1
            Dim myClientResult As DiscoveryClientResult = _
                myDiscoveryClientResultCollection(i)
            Console.WriteLine("DiscoveryClientResult " & (i + 1).ToString())
            Console.WriteLine("Type of reference in the discovery document: " _
                & myClientResult.ReferenceTypeName)
            Console.WriteLine("Url for reference:" & myClientResult.Url)
            Console.WriteLine("File for saving the reference: " _
                & myClientResult.Filename)
         Next i