        ' Contains can be used to test keys before inserting 
        ' them.
        If Not openWith.Contains("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", _
                openWith("ht"))
        End If

        ' IDictionary.Contains returns False if the wrong data 
        ' type is supplied.
        Console.WriteLine("openWith.Contains(29.7) returns {0}", _
            openWith.Contains(29.7))