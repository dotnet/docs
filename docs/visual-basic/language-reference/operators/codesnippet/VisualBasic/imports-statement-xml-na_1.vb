' Place Imports statements at the top of your program.  
Imports <xmlns="http://DefaultNamespace">
Imports <xmlns:ns="http://NewNamespace">

Module Module1

  Sub Main()
    ' Create element by using the default global XML namespace. 
    Dim inner = <innerElement/>

    ' Create element by using both the default global XML namespace
    ' and the namespace identified with the "ns" prefix.
    Dim outer = <ns:outer>
                  <ns:innerElement></ns:innerElement>
                  <siblingElement></siblingElement>
                  <%= inner %>
                </ns:outer>

    ' Display element to see its final form. 
    Console.WriteLine(outer)
  End Sub

End Module