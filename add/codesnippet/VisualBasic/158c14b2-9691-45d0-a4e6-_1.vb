            Dim myFileStream As New FileStream("Temp.vsdisco", _
                 FileMode.OpenOrCreate, FileAccess.Write)
            myDiscoveryDocumentReference.WriteDocument( _
                 myDiscoveryDocument, myFileStream)
            myFileStream.Close()