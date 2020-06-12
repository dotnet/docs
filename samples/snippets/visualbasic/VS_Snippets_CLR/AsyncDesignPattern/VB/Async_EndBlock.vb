' AsynchSampler
'<Snippet1>
' The following example demonstrates using asynchronous methods to
' get Domain Name System information for the specified host computer.

Imports System.Net
Imports System.Net.Sockets

Namespace Examples.AdvancedProgramming.AsynchronousOperations
    Public Class BlockUntilOperationCompletes
        Public Shared Sub Main(args() as String)
            ' Make sure the caller supplied a host name.
            If (args.Length = 0)
                ' Print a message and exit.
                Console.WriteLine("You must specify the name of a host computer.")
                End
            End If
            ' Start the asynchronous request for DNS information.
            ' This example does not use a delegate or user-supplied object
            ' so the last two arguments are Nothing.
            Dim result as IAsyncResult = Dns.BeginGetHostEntry(args(0), Nothing, Nothing)
            Console.WriteLine("Processing your request for information...")
            ' Do any additional work that can be done here.
            Try
                ' EndGetHostByName blocks until the process completes.
                Dim host as IPHostEntry = Dns.EndGetHostEntry(result)
                Dim aliases() as String = host.Aliases
                Dim addresses() as IPAddress = host.AddressList
                Dim i as Integer
                If aliases.Length > 0
                    Console.WriteLine("Aliases")
                    For i = 0 To aliases.Length - 1
                        Console.WriteLine("{0}", aliases(i))
                    Next i
                End If
                If addresses.Length > 0
                    Console.WriteLine("Addresses")
                    For i = 0 To addresses.Length - 1
                        Console.WriteLine("{0}", addresses(i).ToString())
                    Next i
                End If
            Catch e as SocketException
                Console.WriteLine("An exception occurred while processing the request: {0}", e.Message)
            End Try
        End Sub
    End Class
End Namespace
'</Snippet1>
