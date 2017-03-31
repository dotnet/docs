' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Reflection

Public Class Person
   Public FirstName As String
   Public LastName As String
   
   Public Overrides Function ToString() As String
      Return (FirstName + " " + LastName).Trim()
   End Function
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(Person)
      RetrieveMethod(t, "ToString")
      
      t = GetType(Int32)
      RetrieveMethod(t, "ToString")
   End Sub
   
   Private Sub RetrieveMethod(t As Type, name As String)   
      Try
         Dim m As MethodInfo = t.GetMethod(name)
         If m IsNot Nothing Then
            Console.WriteLine("{0}.{1}: {2} method", m.ReflectedType.Name,
                              m.Name, If(m.IsStatic, "Static", "Instance"))    
         Else
            Console.WriteLine("{0}.ToString method not found", t.Name)
         End If   
      Catch e As AmbiguousMatchException
         Console.WriteLine("{0}.{1} has multiple public overloads.", 
                           t.Name, name)
      End Try
   End Sub
End Module
' The example displays the following output:
'       Person.ToString: Instance method
'       Int32.ToString has multiple public overloads.
' </Snippet3>

