    Public Sub UseDns()
        ' Create a DnsPermission instance.
        Dim myPermission As New DnsPermission(PermissionState.Unrestricted)
        ' Check for permission.
        myPermission.Demand()
        ' Create an identical copy of the above DnsPermission object.
        Dim myPermissionCopy As DnsPermission = CType(myPermission.Copy(), DnsPermission)
        Console.WriteLine("Attributes and Values of 'DnsPermission' instance :")
        ' Print the attributes and values.
        PrintKeysAndValues(myPermission.ToXml().Attributes)
        Console.WriteLine("Attribute and values of copied instance :")
        PrintKeysAndValues(myPermissionCopy.ToXml().Attributes)
    End Sub 'UseDns
    
    
    Private Sub PrintKeysAndValues(myHashtable As Hashtable)
        ' Get the enumerator that can iterate through he hash table.
        Dim myEnumerator As IDictionaryEnumerator = myHashtable.GetEnumerator()
        Console.WriteLine(ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
        While myEnumerator.MoveNext()
            Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
        End While
        Console.WriteLine()
    End Sub 'PrintKeysAndValues
