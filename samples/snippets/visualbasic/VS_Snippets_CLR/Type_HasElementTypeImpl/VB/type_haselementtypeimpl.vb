' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic
Public Class MyTypeDelegator
    Inherits TypeDelegator
    Public myElementType As String = Nothing
    Private myType As Type = Nothing
    Public Sub New(ByVal myType As Type)
        MyBase.New(myType)
        Me.myType = myType
    End Sub 'New
    ' Override Type.HasElementTypeImpl().
    Protected Overrides Function HasElementTypeImpl() As Boolean
        ' Determine whether the type is an array.
        If myType.IsArray Then
            myElementType = "array"
            Return True
        End If
        ' Determine whether the type is a reference.
        If myType.IsByRef Then
            myElementType = "reference"
            Return True
        End If
        ' Determine whether the type is a pointer.
        If myType.IsPointer Then
            myElementType = "pointer"
            Return True
        End If
        ' The type is not a reference, array, or pointer type.
        Return False
    End Function 'HasElementTypeImpl
End Class 'MyTypeDelegator
Public Class Type_HasElementTypeImpl
    Public Shared Sub Main()
        Try
            Dim myInt As Integer = 0
            Dim myArray(4) As Integer
            Dim myType As New MyTypeDelegator(myArray.GetType())
            Console.WriteLine(ControlChars.NewLine + "Determine whether a variable refers to an array or pointer or reference type." + ControlChars.NewLine)
            ' Determine whether myType is an array, pointer, reference type.  
            If myType.HasElementType Then
                Console.WriteLine("The type of myArray is {0}.", myType.myElementType.ToString())
            Else
                Console.WriteLine("myArray is not an array, pointer, or reference type.")
            End If
            myType = New MyTypeDelegator(myInt.GetType())
            ' Determine whether myType is an array, pointer, reference type. 
            If myType.HasElementType Then
                Console.WriteLine("The type of myInt is {0}.", myType.myElementType.ToString())
            Else
                Console.WriteLine("myInt is not an array, pointer, or reference type.")
            End If
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'Type_HasElementTypeImpl
' </Snippet1>