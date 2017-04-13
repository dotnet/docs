' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Reflection

Public Class ReflectionUtilities
   Public Shared Function IsOverride(method As MethodInfo) As Boolean
      Return Not method.Equals(method.GetBaseDefinition())
   End Function
End Class

Module Example
   Public Sub Main()
      Dim equals As MethodInfo = GetType(Int32).GetMethod("Equals", 
                                         { GetType(Object) } )
      Console.WriteLine("{0}.{1} is inherited: {2}", 
                        equals.ReflectedType.Name, equals.Name,
                        ReflectionUtilities.IsOverride(equals))
      
      equals = GetType(Object).GetMethod("Equals", { GetType(Object) } )
      Console.WriteLine("{0}.{1} is inherited: {2}", 
                        equals.ReflectedType.Name, equals.Name,
                        ReflectionUtilities.IsOverride(equals))
   End Sub
End Module
' The example displays the following output:
'       Int32.Equals is inherited: True
'       Object.Equals is inherited: False
' </Snippet2>


