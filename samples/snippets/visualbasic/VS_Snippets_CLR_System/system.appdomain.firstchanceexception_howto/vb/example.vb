'<Snippet1>
Imports System.Reflection
Imports System.Runtime.ExceptionServices

Class Example
    Shared Sub Main()
    
        ' To receive first chance notifications of exceptions in 
        ' an application domain, handle the FirstChanceException
        ' event in that application domain.
        '<Snippet2>
        Dim ad As AppDomain = AppDomain.CreateDomain("AD1")
        AddHandler ad.FirstChanceException, AddressOf FirstChanceHandler
        '</Snippet2>

        
        ' Create a worker object in the application domain.
        '<Snippet4>
        Dim w As Worker = CType(ad.CreateInstanceAndUnwrap(
                                    GetType(Worker).Assembly.FullName, "Worker"),
                                Worker)
        '</Snippet4>

        '<Snippet6>
        ' The worker throws an exception and catches it.
        w.Thrower(true)

        Try
            ' The worker throws an exception and doesn't catch it.
            w.Thrower(false)

        Catch ex As ArgumentException
        
            Console.WriteLine("ArgumentException caught in {0}: {1}", 
                AppDomain.CurrentDomain.FriendlyName, ex.Message)
        End Try
        '</Snippet6>
    End Sub

    '<Snippet3>
    Shared Sub FirstChanceHandler(ByVal source As Object, 
                                  ByVal e As FirstChanceExceptionEventArgs)
    
        Console.WriteLine("FirstChanceException event raised in {0}: {1}",
            AppDomain.CurrentDomain.FriendlyName, e.Exception.Message)
    End Sub
    '</Snippet3>
End Class

Public Class Worker
    Inherits MarshalByRefObject

    Public Sub Thrower(ByVal catchException As Boolean)
    
        '<Snippet5>
        If catchException
        
            Try
                Throw New ArgumentException("Thrown in " & AppDomain.CurrentDomain.FriendlyName)

            Catch ex As ArgumentException
            
                Console.WriteLine("ArgumentException caught in {0}: {1}", 
                    AppDomain.CurrentDomain.FriendlyName, ex.Message)
            End Try
        Else
        
            Throw New ArgumentException("Thrown in " & AppDomain.CurrentDomain.FriendlyName)
        End If
        '</Snippet5>
    End Sub
End Class

' This example produces output similar to the following:
'
'FirstChanceException event raised in AD1: Thrown in AD1
'ArgumentException caught in AD1: Thrown in AD1
'FirstChanceException event raised in AD1: Thrown in AD1
'ArgumentException caught in Example.exe: Thrown in AD1
'</Snippet1>
