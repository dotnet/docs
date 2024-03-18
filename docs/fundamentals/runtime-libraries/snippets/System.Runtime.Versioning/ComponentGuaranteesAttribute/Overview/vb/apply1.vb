' Visual Basic .NET Document
Option Strict On

Imports System.Reflection
Imports System.Runtime.Versioning

<Assembly:ComponentGuaranteesAttribute(ComponentGuaranteesOptions.None)>
Namespace MyLibrary
   <ComponentGuaranteesAttribute(ComponentGuaranteesOptions.Stable)> Public Class MyLibraryClass
      Public Function GetName() As String
         Return "My Library" 
      End Function
   End Class
   
   <ComponentGuaranteesAttribute(ComponentGuaranteesOptions.Exchange)> Public Class MyPrimitiveClass

   End Class
   
   <ComponentGuaranteesAttribute(ComponentGuaranteesOptions.None)> Public Class MyChurningClass

   End Class
End Namespace

Public Module Example
   Public Sub Main()
      Dim assem As Assembly = GetType(Example).Assembly
      For Each typ As Type In assem.GetTypes()
         Dim typeAttribs() As Object = typ.GetCustomAttributes(GetType(ComponentGuaranteesAttribute), True)
         If typeAttribs.Length > 0 Then
            Dim guaranteeAttrib As ComponentGuaranteesAttribute = DirectCast(typeAttribs(0), ComponentGuaranteesAttribute)
            Dim guarantee = guaranteeAttrib.Guarantees
            ' Test whether guarantee is Exchange.
            If (guarantee And ComponentGuaranteesOptions.Exchange) = ComponentGuaranteesOptions.Exchange Then
               Console.WriteLine("{0} is marked as {1}.", typ.Name, guarantee)
            End If
            ' <Snippet1>   
            ' Test whether guarantee is Stable.
            If (guarantee And ComponentGuaranteesOptions.Stable) = ComponentGuaranteesOptions.Stable Then
               Console.WriteLine("{0} is marked as {1}.", typ.Name, guarantee)
            End If
            ' </Snippet1>
            ' <Snippet2>
            ' Test whether guarantee is Stable or Exchange.
            If (guarantee And (ComponentGuaranteesOptions.Stable Or ComponentGuaranteesOptions.Exchange)) > 0 Then
               Console.WriteLine("{0} is marked as Stable or Exchange.", typ.Name, guarantee)
            End If
            ' </Snippet2>
            ' <Snippet3>
            ' Test whether there is no guarantee (neither Stable nor Exchange).
            If (guarantee And (ComponentGuaranteesOptions.Stable Or ComponentGuaranteesOptions.Exchange)) = 0 Then
               Console.WriteLine("{0} has no compatibility guarantee.", typ.Name, guarantee)
            End If      
            ' </Snippet3>            
         End If
      Next
   End Sub
End Module
