        ' ContainsKey can be used to test keys before inserting 
        ' them.
        If Not openWith.ContainsKey("ht") Then
            openWith.Add("ht", "hypertrm.exe")
            Console.WriteLine("Value added for key = ""ht"": {0}", _
                openWith("ht"))
        End If