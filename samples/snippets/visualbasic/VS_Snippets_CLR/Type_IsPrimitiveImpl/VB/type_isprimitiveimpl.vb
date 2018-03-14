' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic
Public Class MyTypeDelegatorClass
    Inherits TypeDelegator
    Public myElementType As String = Nothing
    Private myType As Type = Nothing
    Public Sub New(ByVal myType As Type)
        MyBase.New(myType)
        Me.myType = myType
    End Sub 'New
    ' Override the IsPrimitiveImpl method.
    Protected Overrides Function IsPrimitiveImpl() As Boolean
        ' Determine whether the type is a primitive type.
        If myType.IsPrimitive Then
            myElementType = "primitive"
            Return True
        End If
        Return False
    End Function 'IsPrimitiveImpl
End Class 'MyTypeDelegatorClass
Public Class MyTypeDemoClass
    Public Shared Sub Main()
        Try
            Console.WriteLine("Determine whether int is a primitive type.")
            Dim myType As MyTypeDelegatorClass
            myType = New MyTypeDelegatorClass(GetType(Integer))
            ' Determine whether int is a primitive type.
            If myType.IsPrimitive Then
                Console.WriteLine(GetType(Integer).ToString() + " is a primitive type.")
            Else
                Console.WriteLine(GetType(Integer).ToString() + " is not a primitive type.")
            End If
            Console.WriteLine(ControlChars.NewLine + "Determine whether string is a primitive type.")
            myType = New MyTypeDelegatorClass(GetType(String))
            ' Determine whether string is a primitive type.
            If myType.IsPrimitive Then
                Console.WriteLine(GetType(String).ToString() + " is a primitive type.")
            Else
                Console.WriteLine(GetType(String).ToString() + " is not a primitive type.")
            End If
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyTypeDemoClass
' </Snippet1>
