        Dim fs As New FileStream("C:\data\books.xml", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
        
        ' Create the XmlReader object.
        Dim reader As XmlReader = XmlReader.Create(fs)
    
    End Sub 'FileStream