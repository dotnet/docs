    Public Sub useDns()
        ' Create a DnsPermission instance.
        Dim permission As New DnsPermission(PermissionState.Unrestricted)
        
        ' Check for permission.
        permission.Demand()
        ' Create a SecurityElement object to hold XML encoding of the DnsPermission instance.
        Dim securityElementObj As SecurityElement = permission.ToXml()
        Console.WriteLine("Tag, Attributes and Values of 'DnsPermission' instance :")
        Console.WriteLine((ControlChars.Cr + ControlChars.Tab + "Tag :" + securityElementObj.Tag))
        ' Print the attributes and values.
        PrintKeysAndValues(securityElementObj.Attributes)
    End Sub 'useDns
    
    Private Sub PrintKeysAndValues(myList As Hashtable)
        ' Get the enumerator that can iterate through the hash table.
        Dim myEnumerator As IDictionaryEnumerator = myList.GetEnumerator()
        Console.WriteLine(ControlChars.Cr + ControlChars.Tab + "-KEY-" + ControlChars.Tab + "-VALUE-")
        While myEnumerator.MoveNext()
            Console.WriteLine(ControlChars.Tab + "{0}:" + ControlChars.Tab + "{1}", myEnumerator.Key, myEnumerator.Value)
        End While
        Console.WriteLine()
    End Sub 'PrintKeysAndValues