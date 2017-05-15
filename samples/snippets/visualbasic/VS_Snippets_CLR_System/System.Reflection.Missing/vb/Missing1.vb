' Visual Basic .NET Document

Option Strict On


' <Snippet1>
Imports System.Reflection

<Assembly:CLSCompliant(True)>

Public Class MissingClass
   Public Shared Sub MethodWithDefault(Optional value As Integer = 33)
      Console.WriteLine("value = {0}", value)
   End Sub 
End Class   

Public Module Example
   Public Sub Main()
      ' Invoke without reflection.
      MissingClass.MethodWithDefault()
      
      ' Invoke by using reflection.
      Dim t As Type = GetType(MissingClass)
      Dim mi As MethodInfo = t.GetMethod("MethodWithDefault")
      mi.Invoke(Nothing, { Missing.Value })
   End Sub
End Module
' The example displays the following output:
'       value = 33 
'       value = 33 
' </Snippet1>
