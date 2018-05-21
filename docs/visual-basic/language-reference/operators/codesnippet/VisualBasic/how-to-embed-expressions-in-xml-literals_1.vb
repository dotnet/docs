        Dim contactName As String = "Patrick Hines"
        Dim contact As XElement = 
          <contact>
            <name><%= contactName %></name>
          </contact>
        Console.WriteLine(contact)