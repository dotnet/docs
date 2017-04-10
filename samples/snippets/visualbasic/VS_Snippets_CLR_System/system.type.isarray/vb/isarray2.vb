' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim types() As Type = { GetType(String), GetType(Integer()),
                              GetType(ArrayList), GetType(Array),
                              GetType(List(Of String)),
                              GetType(IEnumerable(Of Char)) }
      For Each t In types
         Console.WriteLine("{0,-15} IsArray = {1}", t.Name + ":", t.IsArray)
      Next
   End Sub
End Module
' The example displays the following output:
'       String:         IsArray = False
'       Int32[]:        IsArray = True
'       ArrayList:      IsArray = False
'       Array:          IsArray = False
'       List`1:         IsArray = False
'       IEnumerable`1:  IsArray = False
' </Snippet1>
