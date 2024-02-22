' Topic: How to: Declare and Use XML Namespace Prefixes
'<Snippet8>
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
'</Snippet8>
'Excellent sample as well. You should make sure that you note in the docs that attributes
'never pick up the default Xml namespaces. By default they are always in the empty
' namespace unless they are explicitly qualified with a namespace (which is rare)


