        ' Use the Remove method to remove a key/value pair. No
        ' exception is thrown if the wrong data type is supplied.
        Console.WriteLine(vbLf + "Remove(""dib"")")
        openWith.Remove("dib")
        
        If Not openWith.Contains("dib") Then
            Console.WriteLine("Key ""dib"" is not found.")
        End If