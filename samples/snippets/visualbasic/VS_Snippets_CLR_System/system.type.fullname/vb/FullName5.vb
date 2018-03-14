' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Reflection

Public Class Base(Of T)
End Class

Public Class Derived(Of T) : Inherits Base(Of T)
End Class

Module Example
   Public Sub Main()
      Dim t As Type = GetType(Derived(Of ))
      Console.WriteLine("Generic Class: {0}", t.FullName)
      Console.WriteLine("   Contains Generic Paramters: {0}",
                        t.ContainsGenericParameters)
      Console.WriteLine("   Generic Type Definition: {0}",
                        t.IsGenericTypeDefinition)                 
      Console.WriteLine()
      
      Dim baseType As Type = t.BaseType
      Console.WriteLine("Its Base Class: {0}", 
                        If(baseType.FullName,  
                        "(unassigned) " + baseType.ToString()))
      Console.WriteLine("   Contains Generic Paramters: {0}",
                        baseType.ContainsGenericParameters)
      Console.WriteLine("   Generic Type Definition: {0}",
                        baseType.IsGenericTypeDefinition)                 
      Console.WriteLine("   Full Name: {0}", 
                        baseType.GetGenericTypeDefinition().FullName)
      Console.WriteLine()
      
      t = GetType(Base(Of ))
      Console.WriteLine("Generic Class: {0}", t.FullName)
      Console.WriteLine("   Contains Generic Paramters: {0}",
                        t.ContainsGenericParameters)
      Console.WriteLine("   Generic Type Definition: {0}",
                        t.IsGenericTypeDefinition)                 
   End Sub
End Module
' The example displays the following output:
'       Generic Class: Derived`1
'          Contains Generic Paramters: True
'          Generic Type Definition: True
'       
'       Its Base Class: (unassigned) Base`1[T]
'          Contains Generic Paramters: True
'          Generic Type Definition: False
'          Full Name: Base`1
'       
'       Generic Class: Base`1
'          Contains Generic Paramters: True
'          Generic Type Definition: True
' </Snippet5>
