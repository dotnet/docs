' Visual Basic .NET Document
Option Strict On

' <Snippet29>
<Assembly:CLSCompliant(True)>

Public Class Outer(Of T)
   Dim value As T
   
   Public Sub New(value As T)
      Me.value = value
   End Sub
   
   Public Class Inner1A : Inherits Outer(Of T)
      Public Sub New(value As T)
         MyBase.New(value)
      End Sub
   End Class
   
   Public Class Inner1B(Of U) : Inherits Outer(Of T)
      Dim value2 As U
      
      Public Sub New(value1 As T, value2 As U)
         MyBase.New(value1)
         Me.value2 = value2
      End Sub
   End Class
End Class

Public Module Example
   Public Sub Main()
      Dim inst1 As New Outer(Of String)("This")
      Console.WriteLine(inst1)
      
      Dim inst2 As New Outer(Of String).Inner1A("Another")
      Console.WriteLine(inst2)
      
      Dim inst3 As New Outer(Of String).Inner1B(Of Integer)("That", 2)
      Console.WriteLine(inst3)
   End Sub
End Module
' The example displays the following output:
'       Outer`1[System.String]
'       Outer`1+Inner1A[System.String]
'       Outer`1+Inner1B`1[System.String,System.Int32]
' </Snippet29>
