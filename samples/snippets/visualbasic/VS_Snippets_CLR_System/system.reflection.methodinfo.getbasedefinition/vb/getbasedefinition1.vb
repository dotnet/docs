' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System
Imports System.Reflection

Interface Interf
   Function InterfaceImpl(n As Integer) As String
End Interface

Public Class BaseClass
   Public Overrides Function ToString() As String
      Return "Base"
   End Function

   Public Overridable Sub Method1()
      Console.WriteLine("Method1")
   End Sub

   Public Overridable Sub Method2()
      Console.WriteLine("Method2")
   End Sub

   Public Overridable Sub Method3()
      Console.WriteLine("Method3")
   End Sub
End Class

Public Class DerivedClass : Inherits BaseClass : Implements Interf
   Public Function InterfaceImpl(n As Integer) As String _
                   Implements Interf.InterfaceImpl
      Return n.ToString("N")
   End Function

   Public Overrides Sub Method2()
      Console.WriteLine("Derived.Method2")
   End Sub

   Public Shadows Sub Method3()
      Console.WriteLine("Derived.Method3")
   End Sub
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(DerivedClass)
      Dim m, mb As MethodInfo
      Dim methodNames() As String = { "ToString", "Equals",
                                      "InterfaceImpl", "Method1",
                                      "Method2", "Method3" }

      For Each methodName In methodNames
         m = t.GetMethod(methodName)
         mb = m.GetBaseDefinition()
         Console.WriteLine("{0}.{1} --> {2}.{3}", m.ReflectedType.Name,
                           m.Name, mb.ReflectedType.Name, mb.Name)
      Next
   End Sub
End Module
' The example displays the following output:
'       DerivedClass.ToString --> Object.ToString
'       DerivedClass.Equals --> Object.Equals
'       DerivedClass.InterfaceImpl --> DerivedClass.InterfaceImpl
'       DerivedClass.Method1 --> BaseClass.Method1
'       DerivedClass.Method2 --> BaseClass.Method2
'       DerivedClass.Method3 --> DerivedClass.Method3
' </Snippet1>
