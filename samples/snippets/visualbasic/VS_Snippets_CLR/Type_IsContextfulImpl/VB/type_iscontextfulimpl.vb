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
    ' Override IsContextfulImpl.
    Protected Overrides Function IsContextfulImpl() As Boolean
        ' Check whether the type is contextful.
        If myType.IsContextful Then
            myElementType = " is contextful "
            Return True
        End If
        Return False
    End Function 'IsContextfulImpl
End Class 'MyTypeDelegatorClass
Public Class MyTypeDemoClass
    Public Shared Sub Main()
        Try
            Dim myType As MyTypeDelegatorClass
            Console.WriteLine("Check whether MyContextBoundClass can be hosted in a context.")
            ' Check whether MyContextBoundClass is contextful.
            myType = New MyTypeDelegatorClass(GetType(MyContextBoundClass))
            If myType.IsContextful Then
                Console.WriteLine(GetType(MyContextBoundClass).ToString() + " can be hosted in a context.")
            Else
                Console.WriteLine(GetType(MyContextBoundClass).ToString() + " cannot be hosted in a context.")
            End If
            ' Check whether the int type is contextful.
            myType = New MyTypeDelegatorClass(GetType(MyTypeDemoClass))
            Console.WriteLine(ControlChars.NewLine + "Check whether MyTypeDemoClass can be hosted in a context.")
            If myType.IsContextful Then
                Console.WriteLine(GetType(MyTypeDemoClass).ToString() + " can be hosted in a context.")
            Else
                Console.WriteLine(GetType(MyTypeDemoClass).ToString() + " cannot be hosted in a context.")
            End If
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyTypeDemoClass
' This class demonstrates the IsContextfulImpl method.
Public Class MyContextBoundClass
    Inherits ContextBoundObject
    Public myString As String = "This class is used to demonstrate members of the Type class."
End Class 'MyContextBoundClass
' </Snippet1>
