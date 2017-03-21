    Public Function GetDataContractType(ByVal type As Type) As Type _
       Implements IDataContractSurrogate.GetDataContractType
        Console.WriteLine("GetDataContractType invoked")
        Console.WriteLine(vbTab & "type name: {0}", type.Name)
        ' "Person" will be serialized as "PersonSurrogated"
        ' This method is called during serialization,
        ' deserialization, and schema export.
        If GetType(Person).IsAssignableFrom(type) Then
            Console.WriteLine(vbTab & "returning PersonSurrogated")
            Return GetType(PersonSurrogated)
        End If
        Return type

    End Function