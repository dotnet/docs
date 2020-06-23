'<Snippet1>
Imports System.Reflection
Imports System.Runtime.ExceptionServices

Class Example

    Shared Sub Main()

        AddHandler AppDomain.CurrentDomain.FirstChanceException, AddressOf FirstChanceHandler

        ' Create a set of application domains, with a Worker object in each one.
        ' Each Worker object creates the next application domain.
        Dim ad As AppDomain = AppDomain.CreateDomain("AD0")
        Dim w As Worker = CType(ad.CreateInstanceAndUnwrap(
                                GetType(Worker).Assembly.FullName, "Worker"),
                                Worker)
        w.Initialize(0, 3)

        Console.WriteLine(vbCrLf & "The last application domain throws an exception and catches it:")
        Console.WriteLine()
        w.TestException(true)

        Try
            Console.WriteLine(vbCrLf &
                "The last application domain throws an exception and does not catch it:")
            Console.WriteLine()
            w.TestException(false)

        Catch ex As ArgumentException

            Console.WriteLine("ArgumentException caught in {0}: {1}",
                AppDomain.CurrentDomain.FriendlyName, ex.Message)
        End Try
    End Sub

    Shared Sub FirstChanceHandler(ByVal source As Object,
                                  ByVal e As FirstChanceExceptionEventArgs)

        Console.WriteLine("FirstChanceException event raised in {0}: {1}",
            AppDomain.CurrentDomain.FriendlyName, e.Exception.Message)
    End Sub
End Class

Public Class Worker
    Inherits MarshalByRefObject

    Private ad As AppDomain = Nothing
    Private w As Worker = Nothing

    Public Sub Initialize(ByVal count As Integer, ByVal max As Integer)

        ' Handle the FirstChanceException event in all application domains except
        ' AD1.
        If count <> 1

            AddHandler AppDomain.CurrentDomain.FirstChanceException, AddressOf FirstChanceHandler

        End If

        ' Create another application domain, until the maximum is reached.
        ' Field w remains Nothing in the last application domain, as a signal 
        ' to TestException(). 
        If count < max
            Dim nextAD As Integer = count + 1
            ad = AppDomain.CreateDomain("AD" & nextAD)
            w = CType(ad.CreateInstanceAndUnwrap(
                      GetType(Worker).Assembly.FullName, "Worker"),
                      Worker)
            w.Initialize(nextAD, max)
        End If
    End Sub

    Public Sub TestException(ByVal handled As Boolean)

        ' As long as there is another application domain, call TestException() on
        ' its Worker object. When the last application domain is reached, throw a
        ' handled or unhandled exception.
        If w IsNot Nothing

            w.TestException(handled)

        Else If handled

            Try
                Throw New ArgumentException("Thrown in " & AppDomain.CurrentDomain.FriendlyName)

            Catch ex As ArgumentException

                Console.WriteLine("ArgumentException caught in {0}: {1}",
                    AppDomain.CurrentDomain.FriendlyName, ex.Message)
            End Try
        Else

            Throw New ArgumentException("Thrown in " & AppDomain.CurrentDomain.FriendlyName)
        End If
    End Sub

    Shared Sub FirstChanceHandler(ByVal source As Object,
                                  ByVal e As FirstChanceExceptionEventArgs)

        Console.WriteLine("FirstChanceException event raised in {0}: {1}",
            AppDomain.CurrentDomain.FriendlyName, e.Exception.Message)
    End Sub
End Class

' This example produces output similar to the following:
'
'The last application domain throws an exception and catches it:
'
'FirstChanceException event raised in AD3: Thrown in AD3
'ArgumentException caught in AD3: Thrown in AD3
'
'The last application domain throws an exception and does not catch it:
'
'FirstChanceException event raised in AD3: Thrown in AD3
'FirstChanceException event raised in AD2: Thrown in AD3
'FirstChanceException event raised in AD0: Thrown in AD3
'FirstChanceException event raised in Example.exe: Thrown in AD3
'ArgumentException caught in Example.exe: Thrown in AD3
'</Snippet1>
