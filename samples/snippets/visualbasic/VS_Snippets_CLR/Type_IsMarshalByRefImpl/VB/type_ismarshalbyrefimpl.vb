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

    ' Override IsMarshalByRefImpl.
    Protected Overrides Function IsMarshalByRefImpl() As Boolean
        ' Determine whether the type is marshalled by reference.
        If myType.IsMarshalByRef Then
            myElementType = " marshalled by reference"
            Return True
        End If
        Return False
    End Function 'IsMarshalByRefImpl
End Class 'MyTypeDelegatorClass

Public Class MyTypeDemoClass

    Public Shared Sub Main()
        Try
            Dim myType As MyTypeDelegatorClass
            Console.WriteLine("Determine whether MyContextBoundClass is marshalled by reference.")
            ' Determine whether MyContextBoundClass is marshalled by reference.
            myType = New MyTypeDelegatorClass(GetType(MyContextBoundClass))
            If myType.IsMarshalByRef Then
                Console.WriteLine(GetType(MyContextBoundClass).ToString() + " is marshalled by reference.")
            Else
                Console.WriteLine(GetType(MyContextBoundClass).ToString() + " is not marshalled by reference.")
            End If

            ' Determine whether int is marshalled by reference.
            myType = New MyTypeDelegatorClass(GetType(Integer))
            Console.WriteLine(ControlChars.NewLine + "Determine whether int is marshalled by reference.")
            If myType.IsMarshalByRef Then
                Console.WriteLine(GetType(Integer).ToString() + " is marshalled by reference.")
            Else
                Console.WriteLine(GetType(Integer).ToString() + " is not marshalled by reference.")
            End If
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyTypeDemoClass

' This class is used to demonstrate 'IsMarshalByRefImpl' method.
Public Class MyContextBoundClass
    Inherits ContextBoundObject
    Public myString As String = "This class is used to demonstrate members of the Type class."
End Class 'MyContextBoundClass
' </Snippet1>
