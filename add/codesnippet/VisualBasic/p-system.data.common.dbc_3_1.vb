    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder.ConnectionString = _
            "Data Source=(local);Initial Catalog=AdventureWorks;" & _
            "Integrated Security=SSPI"

        ' This should display "3" in the console window.
        Console.WriteLine(builder.Count)

        builder.Add("Connection Timeout", 25)

        ' This should display the new connection string and
        ' the number of items (4) in the console window.
        Console.WriteLine(builder.ConnectionString)
        Console.WriteLine(builder.Count)

        Console.WriteLine()
        Console.WriteLine("Press Enter to finish.")
        Console.ReadLine()
    End Sub