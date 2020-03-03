'<Snippet1>

Namespace UsageLibrary

Public Class BadlyConstructedType
    Protected initialized As String = "No"
    
    
    Public Sub New()
        Console.WriteLine("Calling base ctor.")
        ' Violates rule: DoNotCallOverridableMethodsInConstructors.
        DoSomething()
    End Sub
    
    ' This will be overridden in the derived type.
    Public Overridable Sub DoSomething()
        Console.WriteLine("Base DoSomething")
    End Sub
End Class


Public Class DerivedType
    Inherits BadlyConstructedType
    
    Public Sub New()
        Console.WriteLine("Calling derived ctor.")
        initialized = "Yes"
    End Sub
    
    Public Overrides Sub DoSomething()
        Console.WriteLine("Derived DoSomething is called - initialized ? {0}", initialized)
    End Sub
End Class


Public Class TestBadlyConstructedType
    
    Public Shared Sub Main()
        Dim derivedInstance As New DerivedType()
    End Sub
End Class 
End Namespace
'</Snippet1>
