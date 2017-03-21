         Dim i As Integer = 0
         While groupEnum.MoveNext()
            Dim groupName As String = groups.GetKey(i)
            Console.WriteLine("Group name: {0}", groupName)
            i += 1
         End While