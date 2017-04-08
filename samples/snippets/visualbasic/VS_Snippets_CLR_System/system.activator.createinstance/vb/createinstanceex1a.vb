' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Reflection
Imports System.Runtime.Remoting

Module Example
   Public Sub Main()
      Dim handle As ObjectHandle = Activator.CreateInstance("PersonInfo", "Person")
      Dim p As Object = handle.Unwrap()
      Dim t As Type = p.GetType()
      Dim prop As PropertyInfo = t.GetProperty("Name")
      if Not prop Is Nothing Then
         prop.SetValue(p, "Samuel")
      End If   
      Dim method As MethodInfo = t.GetMethod("ToString")
      Dim retVal As Object = method.Invoke(p, Nothing) 
      If Not retVal Is Nothing Then
         Console.WriteLine(retVal)
      End If
   End Sub
End Module
' The example displays the following output:
'       Samuel
' </Snippet3>
