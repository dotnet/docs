        Dim phoneType As String = "home"
        Dim contact2 As XElement = 
          <contact>
            <phone type=<%= phoneType %>>206-555-0144</phone>
          </contact>
        Console.WriteLine(contact2)