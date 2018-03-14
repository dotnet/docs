'<Snippet1>

Imports System

Namespace UsageLibrary

Public Class BadlyConstructedType
    Protected initialized As String = "No"
    
    
    Public Sub New()
        Console.WriteLine("Calling base ctor.")
        ' Violates rule: DoNotCallOverridableMethodsInConstructors.
        DoSomething()
    End Sub 'New
    
    ' This will be overridden in the derived type.
    Public Overridable Sub DoSomething()
        Console.WriteLine("Base DoSomething")
    End Sub 'DoSomething
End Class 'BadlyConstructedType


Public Class DerivedType
    Inherits BadlyConstructedType
    
    Public Sub New()
        Console.WriteLine("Calling derived ctor.")
        initialized = "Yes"
    End Sub 'New
    
    Public Overrides Sub DoSomething()
        Console.WriteLine("Derived DoSomething is called - initialized ? {0}", initialized)
    End Sub 'DoSomething
End Class 'DerivedType


Public Class TestBadlyConstructedType
    
    Public Shared Sub Main()
        Dim derivedInstance As New DerivedType()
    End Sub 'Main
End Class 
End Namespace
'</Snippet1>
