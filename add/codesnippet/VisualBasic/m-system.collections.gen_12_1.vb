        ' Create a new dictionary of strings, with string keys, 
        ' and access it through the IDictionary generic interface.
        Dim openWith As IDictionary(Of String, String) = _
            New Dictionary(Of String, String)
        
        ' Add some elements to the dictionary. There are no 
        ' duplicate keys, but some of the values are duplicates.
        openWith.Add("txt", "notepad.exe")
        openWith.Add("bmp", "paint.exe")
        openWith.Add("dib", "paint.exe")
        openWith.Add("rtf", "wordpad.exe")
        
        ' The Add method throws an exception if the new key is 
        ' already in the dictionary.
        Try
            openWith.Add("txt", "winword.exe")
        Catch 
            Console.WriteLine("An element with Key = ""txt"" already exists.")
        End Try