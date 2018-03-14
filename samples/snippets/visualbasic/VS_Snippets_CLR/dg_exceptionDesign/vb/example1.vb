Imports System
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization
Imports System.Collections.Generic

Namespace Examples.DesignGuidelines.Exceptions


    '<Snippet1>
    Public Class BadExceptionHandlingExample1

        Public Sub DoWork()
            ' Do some work that might throw exceptions.
        End Sub

        Public Sub MethodWithBadHandler()
            Try
                DoWork()
            Catch e As Exception
                ' Handle the exception and 
                ' continue executing.
            End Try
        End Sub
    End Class
    '</Snippet1>

    '<Snippet2>
    Public Class BadExceptionHandlingExample2

        Public Sub DoWork()
            ' Do some work that might throw exceptions.
        End Sub

        Public Sub MethodWithBadHandler()
            Try
                DoWork()
            Catch e As Exception
                If TypeOf e Is StackOverflowException Or _
                   TypeOf e Is OutOfMemoryException Then
                    Throw
                End If
            End Try
        End Sub
    End Class
    '</Snippet2>

    Public Class ThrowExample1

        '<Snippet3>
        Public Sub DoWork(ByVal anObject As Object)
            ' Do some work that might throw exceptions.
            '<Snippet7>
            If (anObject = Nothing) Then
                Throw New ArgumentNullException("anObject", "Specify a non-null argument.")
            End If
            '</Snippet7>
            ' Do work with o.
        End Sub
        '</Snippet3>

        '<Snippet4>
        Public Sub MethodWithBadCatch(ByVal anObject As Object)
            Try
                DoWork(anObject)

            Catch e As ArgumentNullException
                System.Diagnostics.Debug.Write(e.Message)
                ' This is wrong.
                Throw e
                ' Should be this:
                ' throw
            End Try
        End Sub

        '</Snippet4>
        '<Snippet5>
        Public Sub MethodWithBetterCatch()
            Try
                DoWork(Nothing)
            Catch e As ArgumentNullException
                System.Diagnostics.Debug.Write(e.Message)
                Throw
            End Try
        End Sub
        '</Snippet5>
    End Class

    Public Class Wrapper

        Public Sub EstablishConnection()

        End Sub

        '<Snippet6>
        Public Sub SendMessages()
            Try
                EstablishConnection()
            Catch e As System.Net.Sockets.SocketException
                Throw New CommunicationFailureException("Cannot access remote computer.", e)
            End Try
        End Sub
        '</Snippet6>

        Private IPaddr As IPAddress = IPAddress.Loopback

        '<Snippet8>
        Public Property Address() As IPAddress
            Get
                Return IPaddr
            End Get
            Set(ByVal value As IPAddress)
                If IsNothing(value) Then
                    Throw New ArgumentNullException("value")
                End If
                IPaddr = value
            End Set
        End Property
        '</Snippet8>



    End Class

    Public Class CommunicationFailureException
        Inherits Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)

        End Sub

        Public Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message)

        End Sub
    End Class

    Public Class BaseException
        Inherits Exception
    End Class

    '<Snippet9>
    Public Class NewException
        Inherits BaseException
        Implements ISerializable

        Public Sub New()
            MyBase.New()
            ' Add implementation.
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New()
            ' Add implementation.
        End Sub

        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.New()
            ' Add implementation.
        End Sub

        ' This constructor is needed for serialization.
        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New()
            ' Add implementation.
        End Sub
    End Class
    '</Snippet9>

    '<snippet13>
    '<Snippet10>
    Public Class Doer

        ' Method that can potential throw exceptions often.
        Public Shared Sub ProcessMessage(ByVal message As String)
            If (message = Nothing) Then
                Throw New ArgumentNullException("message")
            End If
        End Sub

        ' Other methods...
    End Class
    '</Snippet10>

    '<Snippet11>
    Public Class Tester

        Public Shared Sub TesterDoer(ByVal messages As ICollection(Of String))
            For Each message As String In messages
                ' Test to ensure that the call 
                ' won't cause the exception.
                If (Not (message) Is Nothing) Then
                    Doer.ProcessMessage(message)
                End If
            Next
        End Sub
    End Class
    '</Snippet11>
    '</snippet13>

    Public Class BadParser

        '<Snippet12>
        Private Function ParseUri(ByVal uriValue As String, ByVal throwOnError As Boolean) As Uri
            '</Snippet12>

            Return New Uri("http://contoso.com")
        End Function
    End Class

    Public Class TestMain

        Public Shared Sub Main()
            Dim t As ThrowExample1 = New ThrowExample1
            ' t.MethodWithBadCatch();
            ' t.MethodWithBetterCatch();
        End Sub
    End Class
End Namespace

