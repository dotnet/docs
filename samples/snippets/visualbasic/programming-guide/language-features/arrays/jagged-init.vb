
Module Example
   Public Sub Main()
      CompileBad()
      CompileGood()
   End Sub
   
   Private Sub CompileBad      
      #If compileall Then
         ' <Snippet1>
         Dim valuesjagged =  {{1, 2}, {2, 3, 4}}
         ' </Snippet1>
      #End If
   End Sub
   
   Private Sub CompileGood
      ' <Snippet1>
      Dim valuesjagged = {({1, 2}), ({2, 3, 4})}
      ' </Snippet2>
   End Sub
End Module

