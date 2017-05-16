' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Class Example
   Public Name As String
   
   Public Sub New(name As String)
      Me.Name = name
   End Sub
   
   Public Overrides Function ToString() As String
      Return Me.Name
   End Function
End Class

' Define a class to contain information about each Example instance.
Public Class ExampleInfo
   Public Name As String
   Public Methods As Integer
   Public Properties As Integer
   
   Public Overrides Function ToString() As String
      Return String.Format("{0}: {1} Methods, {2} Properties", _
                           Me.Name, Me.Methods, Me.Properties)
   End Function
End Class

Module TestExample

   Private flags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance

   Public Sub Main()
      Dim ex1 As New Example("ex1")
      Dim ex2 As New Example("ex2")
      Dim ex3 As New Example("ex3")
      
      Dim exInfo1 As New ExampleInfo() 
      exInfo1.Name = ex1.ToString()
      exInfo1.Methods = ex1.GetType().GetMethods(flags).Count
      exInfo1.Properties = ex1.GetType().GetProperties(flags).Count
      
      Dim exInfo3 As New ExampleInfo() 
      exInfo3.Name = ex3.ToString()
      exInfo3.Methods = ex3.GetType().GetMethods(flags).Count
      exInfo3.Properties = ex3.GetType().GetProperties(flags).Count

      Dim attached As New ConditionalWeakTable(Of Example, ExampleInfo)
      Dim value As ExampleInfo = Nothing

      ' Attach a property to ex1 using the Add method, then retrieve it.
      attached.Add(ex1, exInfo1)
      If attached.TryGetValue(ex1, value) Then
         Console.WriteLine("{0}, {1}", ex1, value)
      Else
         Console.WriteLine("{0} does not have an attached property.", ex1)
      End If

      ' Attempt to retrieve the value attached to ex2.
      value = attached.GetValue(ex2, AddressOf TestExample.CreateAttachedValue)      
      If attached.TryGetValue(ex2, value) Then
         Console.WriteLine("{0}, {1}", ex2, value)
      Else 
         Console.WriteLine("{0} does not have an attached property.", ex2)
      End If
      
      ' Atttempt to retrieve the value attached to ex3.
      value = attached.GetOrCreateValue(ex3)
      Console.WriteLine("{0}, {1}", ex3, value)
   End Sub
   
   Public Function CreateAttachedValue(ex As Example) As ExampleInfo
      Dim info As New ExampleInfo()
      info.Name = ex.ToString()
      info.Methods = ex.GetType().GetMethods(flags).Count
      info.Properties = ex.GetType().GetProperties(flags).Count
      Return info
   End Function
End Module
' The example displays the following output:
'       ex1, ex1: 4 Methods, 0 Properties
'       ex2, ex2: 4 Methods, 0 Properties
'       ex3, : 0 Methods, 0 Properties
' </Snippet1>
