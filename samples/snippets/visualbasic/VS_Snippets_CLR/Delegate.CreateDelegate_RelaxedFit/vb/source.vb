' <Snippet1>
Imports System.Reflection

' Define two classes to use in the demonstration, a base class and 
' a class that derives from it.
'
Public Class Base
End Class

Public Class Derived
    Inherits Base

    ' Define a Shared method to use in the demonstration. The method 
    ' takes an instance of Base and returns an instance of Derived.  
    ' For the purposes of the demonstration, it is not necessary for 
    ' the method to do anything useful. 
    '
    Public Shared Function MyMethod(ByVal arg As Base) As Derived
        Dim dummy As Base = arg
        Return New Derived()
    End Function

End Class

' Define a delegate that takes an instance of Derived and returns an
' instance of Base.
'
Public Delegate Function Example(ByVal arg As Derived) As Base

Module Test

    Sub Main()

        ' The binding flags needed to retrieve MyMethod.
        Dim flags As BindingFlags = _
            BindingFlags.Public Or BindingFlags.Static

        ' Get a MethodInfo that represents MyMethod.
        Dim minfo As MethodInfo = _
            GetType(Derived).GetMethod("MyMethod", flags)

        ' Demonstrate contravariance of parameter types and covariance
        ' of return types by using the delegate Example to represent
        ' MyMethod. The delegate binds to the method because the
        ' parameter of the delegate is more restrictive than the 
        ' parameter of the method (that is, the delegate accepts an
        ' instance of Derived, which can always be safely passed to
        ' a parameter of type Base), and the return type of MyMethod
        ' is more restrictive than the return type of Example (that
        ' is, the method returns an instance of Derived, which can
        ' always be safely cast to type Base). 
        '
        Dim ex As Example = CType( _
            [Delegate].CreateDelegate(GetType(Example), minfo), _
            Example _
        )

        ' Execute MyMethod using the delegate Example.
        '        
        Dim b As Base = ex(New Derived())
    End Sub
End Module
' </Snippet1>
