' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim names As List(Of String)
      names.Add("Major Major Major")       
   End Sub
End Module
' Compilation displays a warning like the following:
'    Example1.vb(10) : warning BC42104: Variable 'names' is used before it 
'    has been assigned a value. A null reference exception could result 
'    at runtime.
'    
'          names.Add("Major Major Major")
'          ~~~~~
' The example displays output like the following output:
'    Unhandled Exception: System.NullReferenceException: Object reference 
'    not set to an instance of an object.
'       at Example.Main()
' </Snippet1>

