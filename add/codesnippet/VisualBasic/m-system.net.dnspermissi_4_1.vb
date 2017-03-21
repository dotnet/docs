    Public Sub useDns()
        ' Create a DnsPermission instance.
        Dim permission As New DnsPermission(PermissionState.Unrestricted)
        ' Check for permission.
        permission.Demand()
        Console.WriteLine("Attributes and Values of DnsPermission instance :")
        ' Print the attributes and values.
        PrintKeysAndValues(permission.ToXml().Attributes)
        ' Check the permission state.
        If permission.IsUnrestricted() Then
            Console.WriteLine("Overall permissions : Unrestricted")
        Else
            Console.WriteLine("Overall permissions : Restricted")
        End If
    End Sub 'useDns
     
    Private Sub PrintKeysAndValues(myList As Hashtable)
        ' Get the enumerator that can iterate through the hash table.
        Dim myEnumerator As IDictionaryEnumerator = myList.GetEnumerator()
        Console.WriteLine(ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
        While myEnumerator.MoveNext()
            Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
        End While
        Console.WriteLine()
    End Sub 'PrintKeysAndValues