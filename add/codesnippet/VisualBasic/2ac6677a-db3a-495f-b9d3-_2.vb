        ' The Item property is the default property, so you 
        ' can omit its name when accessing elements. 
        Console.WriteLine("For key = ""rtf"", value = {0}.", _
            openWith("rtf"))
        
        ' The default Item property can be used to change the value
        ' associated with a key.
        openWith("rtf") = "winword.exe"
        Console.WriteLine("For key = ""rtf"", value = {0}.", _
            openWith("rtf"))
        
        ' If a key does not exist, setting the default Item property
        ' for that key adds a new key/value pair.
        openWith("doc") = "winword.exe"

        ' The default Item property returns Nothing if the key
        ' is of the wrong data type.
        Console.WriteLine("The default Item property returns Nothing" _
            & " if the key is of the wrong type:")
        Console.WriteLine("For key = 2, value = {0}.", _
            openWith(2))

        ' The default Item property throws an exception when setting
        ' a value if the key is of the wrong data type.
        Try
            openWith(2) = "This does not get added."
        Catch 
            Console.WriteLine("A key of the wrong type was specified" _
                & " when setting the default Item property.")
        End Try