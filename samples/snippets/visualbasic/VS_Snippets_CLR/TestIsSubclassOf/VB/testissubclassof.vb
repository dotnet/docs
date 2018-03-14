' <Snippet1>
Public Class Class1
End Class

Public Class DerivedC1 : Inherits Class1
End Class

Public Module Example
   Public Sub Main()
      Console.WriteLine("DerivedC1 subclass of Class1: {0}",
                         GetType(DerivedC1).IsSubClassOf(GetType(Class1)))
   End Sub
End Module
' The example displays the following output:
'       DerivedC1 subclass of Class1: True
' </Snippet1>