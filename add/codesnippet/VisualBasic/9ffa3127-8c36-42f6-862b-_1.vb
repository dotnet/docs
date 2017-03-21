    Public Function GetReferencedTypeOnImport(ByVal typeName As String, _
        ByVal typeNamespace As String, ByVal customData As Object) As Type _
        Implements IDataContractSurrogate.GetReferencedTypeOnImport
        Console.WriteLine("GetReferencedTypeOnImport invoked")
        ' This method is called on schema import.
        ' If a PersonSurrogated data contract is 
        ' in the specified namespace, do not create a new type for it 
        ' because there is already an existing type, "Person".
        Console.WriteLine(vbTab & "Type Name: {0}", typeName)

        'If typeNamespace.Equals("http://schemas.datacontract.org/2004/07/DCSurrogateSample") Then
        If typeName.Equals("PersonSurrogated") Then
            Console.WriteLine("Returning Person")
            Return GetType(Person)
        End If
        'End If
        Return Nothing

    End Function