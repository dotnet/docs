        Dim keyList As System.Collections.IEnumerable
        keyList = My.Computer.Registry.ClassesRoot.GetSubKeyNames()
        For Each keyName As String In keyList
            ListBox1.Items.Add(keyName)
        Next