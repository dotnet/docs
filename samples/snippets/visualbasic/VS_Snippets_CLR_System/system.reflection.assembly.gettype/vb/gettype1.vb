' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim assem As Assembly = GetType(Example).Assembly
      Dim t As Type = assem.GetType("Transportation.MeansOfTransportation")
      If Not t Is Nothing Then
         Console.WriteLine("Virtual properties in type {0}:", 
                           t.FullName)
         Dim props() As PropertyInfo = t.GetProperties()
         Dim nVirtual As Integer = 0
         For ctr As Integer = 0 To props.Length - 1
            If props(ctr).GetMethod.IsVirtual Then
               Console.WriteLine("   {0} (type {1})",
                                 props(ctr).Name, 
                                 props(ctr).PropertyType.FullName)
               nVirtual += 1
            End If
         Next
         If nVirtual = 0 Then 
            Console.WriteLine("   No virtual properties")
         End If   
      End If   
   End Sub
End Module

Namespace Transportation
   Public MustInherit Class MeansOfTransportation
      Public MustOverride Property HasWheels As Boolean
      Public MustOverride Property Wheels As Integer
      Public MustOverride Property ConsumesFuel As Boolean
      Public MustOverride Property Living As Boolean
   End Class
End Namespace
' The example displays the following output:
'    Virtual properties in type Transportation.MeansOfTransportation:
'       HasWheels (type System.Boolean)
'       Wheels (type System.Int32)
'       ConsumesFuel (type System.Boolean)
'       Living (type System.Boolean)
' </Snippet1>