' <Snippet1>
Imports System.Reflection

Public Class MyTypeDelegator
    Inherits TypeDelegator
    Public myElementType As String = Nothing
    Public myType As Type
    Public Sub New(ByVal myType As Type)
        MyBase.New(myType)
        Me.myType = myType
    End Sub
    ' Override IsArrayImpl().
    Protected Overrides Function IsArrayImpl() As Boolean
        ' Determine whether the type is an array.
        If myType.IsArray Then
            myElementType = "array"
            Return True
        End If
        ' Return false if the type is not an array.
        Return False
    End Function 'IsArrayImpl
End Class

Public Class Type_IsArrayImpl
    Public Shared Sub Main()
        Try
            Dim myInt As Integer = 0
            ' Create an instance of an array element.
            Dim myArray(4) As Integer
            Dim myType As New MyTypeDelegator(myArray.GetType())
            Console.WriteLine(ControlChars.NewLine + "Determine whether the variable is an array." + ControlChars.NewLine)
            ' Determine whether 'myType' is an array type.  
            If myType.IsArray Then
                Console.WriteLine("The type of myArray is {0}.", myType.myElementType)
            Else
                Console.WriteLine("myArray is not an array.")
            End If
            myType = New MyTypeDelegator(myInt.GetType())
            ' Determine whether myType is an array type. 
            If myType.IsArray Then
                Console.WriteLine("The type of myInt is {0}.", myType.myElementType)
            Else
                Console.WriteLine("myInt is not an array.")
            End If
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
