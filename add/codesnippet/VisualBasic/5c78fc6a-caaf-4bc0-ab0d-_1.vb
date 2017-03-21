    Public Function GetObjectToSerialize(ByVal obj As Object, _
        ByVal targetType As Type) As Object _
        Implements IDataContractSurrogate.GetObjectToSerialize
        Console.WriteLine("GetObjectToSerialize Invoked")
        Console.WriteLine(vbTab & "type name: {0}", obj.ToString)
        Console.WriteLine(vbTab & "target type: {0}", targetType.Name)
        ' This method is called on serialization.
        ' If Person is not being serialized...
        If TypeOf obj Is Person Then
            Console.WriteLine(vbTab & "returning PersonSurrogated")
            ' ... use the XmlSerializer to perform the actual serialization.
            Dim ps As New PersonSurrogated()
            Dim xs As New XmlSerializer(GetType(Person))
            Dim sw As New StringWriter()
            xs.Serialize(sw, CType(obj, Person))
            ps.xmlData = sw.ToString()
            Return ps
        End If
        Return obj

    End Function