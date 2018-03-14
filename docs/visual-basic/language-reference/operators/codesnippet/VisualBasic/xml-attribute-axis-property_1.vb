        ' Topic: XML Attribute Axis Property
        Dim phones As XElement = 
            <phones>
                <phone type="home">206-555-0144</phone>
                <phone type="work">425-555-0145</phone>
            </phones>

        Dim phoneTypes As XElement = 
          <phoneTypes>
              <%= From phone In phones.<phone> 
                  Select <type><%= phone.@type %></type> 
              %>
          </phoneTypes>

        Console.WriteLine(phoneTypes)