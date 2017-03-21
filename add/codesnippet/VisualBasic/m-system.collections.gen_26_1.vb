        ' Use the Remove method to remove a key/value pair.
        Console.WriteLine(vbLf + "Remove(""doc"")")
        openWith.Remove("doc")
        
        If Not openWith.ContainsKey("doc") Then
            Console.WriteLine("Key ""doc"" is not found.")
        End If