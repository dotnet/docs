    Public Shared Sub ReadObject(ByVal fileName As String) 
        Console.WriteLine("Deserializing an instance of the object.")
        Dim fs As New FileStream(fileName, FileMode.Open)
        Dim reader As XmlDictionaryReader = _
            XmlDictionaryReader.CreateTextReader(fs, New XmlDictionaryReaderQuotas())
        Dim ser As New DataContractSerializer(GetType(Person))
        
        ' Deserialize the data and read it from the instance.
        Dim deserializedPerson As Person = CType(ser.ReadObject(reader, True), Person)
        reader.Close()
        fs.Close()
        Console.WriteLine(String.Format("{0} {1}, ID: {2}", deserializedPerson.FirstName, deserializedPerson.LastName, deserializedPerson.ID))
    End Sub 