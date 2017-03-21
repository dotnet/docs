    Public Shared Sub ReadObjectData(ByVal path As String) 
        ' Create the reader.
        Dim fs As New FileStream(path, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
            XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        
        ' Create the DataContractSerializer specifying the type, 
        ' root and namespace to use. The root value corresponds
        ' to the DataContract.Name value, and the namespace value
        ' corresponds to the DataContract.Namespace value.
        Dim ser As New DataContractSerializer(GetType(Person), _
            "Customer", "http://www.contoso.com")
        
        ' Test if the serializer is on the start of the 
        ' object data. If so, read the data and write it 
        ' to the console.
        While reader.Read()
            If ser.IsStartObject(reader) Then
                Console.WriteLine("Found the element")
                Dim p As Person = CType(ser.ReadObject(reader), Person)
                Console.WriteLine("{0} {1}    id:{2}", p.FirstName, p.LastName, p.ID)
            End If
                    
            Console.WriteLine(reader.Name)
        End While
        
        fs.Flush()
        fs.Close()
    
    End Sub     