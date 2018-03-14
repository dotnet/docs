' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim t As Type = GetType(Integer)
      Dim obj1 As Object = GetType(Integer).GetTypeInfo()
      IsEqualTo(t, obj1)

      Dim obj2 As Object = GetType(String)
      IsEqualTo(t, obj2)
      
      t = GetType(Object)
      Dim obj3 As Object = GetType(Object)
      IsEqualTo(t, obj3)
      
      t = GetType(List(Of ))
      Dim obj4 As Object = (New List(Of String())).GetType()
      IsEqualTo(t, obj4)
      
      t = GetType(Type)
      Dim obj5 As Object = Nothing
      IsEqualTo(t, obj5)
   End Sub
   
   Private Sub IsEqualTo(t As Type, inst As Object)
      Dim t2 As Type = TryCast(inst, Type)
      If t2 IsNot Nothing Then
         Console.WriteLine("{0} = {1}: {2}", t.Name, t2.Name,
                           t.Equals(t2))
      Else
         Console.WriteLine("Cannot cast the argument to a type.")
      End If
      Console.WriteLine()                        
   End Sub
End Module
' The example displays the following output:
'       Int32 = Int32: True
'       
'       Int32 = String: False
'       
'       Object = Object: True
'       
'       List`1 = List`1: False
'       
'       Cannot cast the argument to a type.
' </Snippet1>
