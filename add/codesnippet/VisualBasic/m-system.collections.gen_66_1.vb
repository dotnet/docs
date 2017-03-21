        ' When a program often has to try keys that turn out not to
        ' be in the dictionary, TryGetValue can be a more efficient 
        ' way to retrieve values.
        Dim value As String = ""
        If openWith.TryGetValue("tif", value) Then
            Console.WriteLine("For key = ""tif"", value = {0}.", value)
        Else
            Console.WriteLine("Key = ""tif"" is not found.")
        End If