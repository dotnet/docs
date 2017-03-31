Imports System
Imports System.Threading

Public Class ClassA

End Class

' <snippet2>
Public Class ClassB
    ' The private field that stores the value for the
    ' ClassA property is intialized to null. It is set
    ' once, from any of several threads. The field must
    ' be of type Object, so that CompareExchange can be
    ' used to assign the value. If the field is used
    ' within the body of class Test, it must be cast to
    ' type ClassA.
    Private classAValue As Object = Nothing
    ' This property can be set once to an instance of
    ' ClassA. Attempts to set it again cause an
    ' exception to be thrown.
    Public Property ClassA() As ClassA
        Get
            Return CType(classAValue, ClassA)
        End Get

        Set
            ' CompareExchange compares the value in classAValue
            ' to null. The new value assigned to the ClassA
            ' property, which is in the special variable 'value',
            ' is placed in classAValue only if classAValue is
            ' equal to null.
            If Not (Nothing Is Interlocked.CompareExchange(classAValue, _
                CType(value, [Object]), Nothing)) Then
                ' CompareExchange returns the original value of
                ' classAValue; if it is not null, then a value
                ' was already assigned, and CompareExchange did not
                ' replace the original value. Throw an exception to
                ' indicate that an error occurred.
                Throw New ApplicationException("ClassA was already set.")
            End If
        End Set
    End Property
End Class
' </snippet2>
