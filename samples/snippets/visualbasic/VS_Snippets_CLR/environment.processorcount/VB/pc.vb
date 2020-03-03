'<snippet1>
' This example demonstrates the 
'     Environment.ProcessorCount property.
Class Sample
   Public Shared Sub Main()
      Console.WriteLine("The number of processors " & _
                        "on this computer is {0}.", _
                        Environment.ProcessorCount)
   End Sub
End Class
'
'This example produces the following results:
'
'The number of processors on this computer is 1.
'
'</snippet1>