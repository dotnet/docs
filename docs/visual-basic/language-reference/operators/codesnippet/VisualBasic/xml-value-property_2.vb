    Dim contact As XElement = 
        <contact>
          <name>Patrick Hines</name>
          <phone type="home">206-555-0144</phone>
          <phone type="work">425-555-0145</phone>
        </contact>


    Dim types = contact.<phone>.Attributes("type")

    For Each attr In types
      Console.WriteLine(attr.Value)
    Next