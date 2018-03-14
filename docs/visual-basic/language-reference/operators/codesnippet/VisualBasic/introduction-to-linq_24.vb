' Place Imports statements at the top of your program.  
Imports <xmlns:ns="http://SomeNamespace">

Module Sample1

    Sub SampleTransform()

        ' Create test by using a global XML namespace prefix. 

        Dim contact = 
            <ns:contact>
                <ns:name>Patrick Hines</ns:name>
                <ns:phone ns:type="home">206-555-0144</ns:phone>
                <ns:phone ns:type="work">425-555-0145</ns:phone>
            </ns:contact>

        Dim phoneTypes = 
          <phoneTypes>
              <%= From phone In contact.<ns:phone> 
                  Select <type><%= phone.@ns:type %></type> 
              %>
          </phoneTypes>

        Console.WriteLine(phoneTypes)
    End Sub

End Module