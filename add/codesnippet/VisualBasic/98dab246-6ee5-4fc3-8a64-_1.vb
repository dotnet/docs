    Public Function GetDeserializedObject(ByVal obj As Object, _
        ByVal targetType As Type) As Object Implements _
        IDataContractSurrogate.GetDeserializedObject
        Console.WriteLine("GetDeserializedObject invoked")
        ' This method is called on deserialization.
        ' If PersonSurrogated is being deserialized...
        If TypeOf obj Is PersonSurrogated Then
            Console.WriteLine(vbTab & "returning PersonSurrogated")
            '... use the XmlSerializer to do the actual deserialization.
            Dim ps As PersonSurrogated = CType(obj, PersonSurrogated)
            Dim xs As New XmlSerializer(GetType(Person))
            Return CType(xs.Deserialize(New StringReader(ps.xmlData)), Person)
        End If
        Return obj

    End Function