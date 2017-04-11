' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Reflection

Public Class GenericType1(Of T)
   Public Sub Display(elements As T())
   End Sub
   
   ' Visual Basic does not support pointer types.
   Public Sub HandleT(obj As T)
   End Sub
   
   
   Public Function ChangeValue(ByRef arg As T) As Boolean
      Return True
   End Function
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(GenericType1(Of ))
      Console.WriteLine("Type Name: {0}", t.FullName)
      Dim methods() As MethodInfo = t.GetMethods(BindingFlags.Instance Or
                                                 BindingFlags.DeclaredOnly Or
                                                 BindingFlags.Public)
      For Each method In methods 
         Console.WriteLine("   Method: {0}", method.Name)
         ' Get method parameters.
         Dim param As ParameterInfo = method.GetParameters()(0)
         Dim paramType As Type = param.ParameterType
         If method.Name = "HandleT" Then
            paramType = paramType.MakePointerType()
         End If
         Console.WriteLine("      Parameter: {0}", 
                           If(paramType.FullName, 
                              paramType.ToString() + " (unassigned)"))
      Next
   End Sub
End Module
' The example displays the following output:
'       Type Name: GenericType1`1
'          Method: Display
'             Parameter: T[] (unassigned)
'          Method: HandleT
'             Parameter: T* (unassigned)
'          Method: ChangeValue
'             Parameter: T& (unassigned)
' </Snippet4>

