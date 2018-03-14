' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public MustInherit Class AbstractClass
End Class

Public Class DerivedClass : Inherits AbstractClass
End Class

Public NotInheritable Class SingleClass
End Class

Public Interface ITypeInfo
   Function GetName() As String
End Interface

Public Class ImplementingClass : Implements ITypeInfo
   Public Function GetName() As String _
          Implements ITypeInfo.GetName
      Return Me.GetType().FullName
   End Function
End Class

Delegate Function InputOutput(inp As String) As String

Module Example
   Public Sub Main()
      Dim types() As Type = { GetType(AbstractClass),
                              GetType(DerivedClass),
                              GetType(ITypeInfo),
                              GetType(SingleClass),
                              GetType(ImplementingClass),
                              GetType(InputOutput) }
      For Each type In types
         Console.WriteLine("{0} is abstract: {1}",
                           type.Name, type.IsAbstract)
      Next
   End Sub
End Module
' The example displays the following output:
'       AbstractClass is abstract: True
'       DerivedClass is abstract: False
'       ITypeInfo is abstract: True
'       SingleClass is abstract: False
'       ImplementingClass is abstract: False
'       InputOutput is abstract: False
' </Snippet1>
