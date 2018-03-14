' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Collections.Generic
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Get a Type object that represents a non-generic type.
      GetAddMethod(GetType(ArrayList))
      
      Dim list As New List(Of String)()
      ' Get a Type object that represents a constructed generic type.
      Dim closed As Type = list.GetType()
      GetAddMethod(closed)
      
      ' Get a Type object that represents an open generic type.
      Dim open As Type = GetType(List(Of))
      GetAddMethod(open)
   End Sub
   
   Private Sub GetAddMethod(typ As Type)
      Dim method As MethodInfo
      ' Determine if this is a generic type.
      If typ.IsGenericType Then
         ' Is it an open generic type?
         If typ.ContainsGenericParameters Then
            method = typ.GetMethod("Add", typ.GetGenericArguments())
         ' Get closed generic type arguments.
         Else
            method = typ.GetMethod("Add", typ.GenericTypeArguments)
         End If
      ' This is not a generic type.
      Else
         method = typ.GetMethod("Add", { GetType(Object) } )
      End If
      ' Test if an Add method was found.
      If method Is Nothing Then 
         Console.WriteLine("No Add method found.")
         Exit Sub
      End If   

      Dim t As Type = method.ReflectedType
      Console.Write("{0}.{1}.{2}(", t.Namespace, t.Name, method.Name)
      Dim params() As ParameterInfo = method.GetParameters()
      For ctr As Integer = 0 To params.Length - 1
         Console.Write("{0}{1}", params(ctr).ParameterType.Name, 
                       If(ctr < params.Length - 1, ", ", ""))
      Next
      Console.WriteLine(")")
   End Sub
End Module
' The example displays the following output:
'       System.Collections.ArrayList.Add(Object)
'       System.Collections.Generic.List`1.Add(String)
'       System.Collections.Generic.List`1.Add(T)
' </Snippet1>
