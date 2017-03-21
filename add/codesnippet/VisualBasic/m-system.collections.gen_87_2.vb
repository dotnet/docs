        ' The default Item property throws an exception if the requested
        ' key is not in the dictionary.
        Try
            Console.WriteLine("For key = ""tif"", value = {0}.", _
                openWith("tif"))
        Catch 
            Console.WriteLine("Key = ""tif"" is not found.")
        End Try