'<Snippet3>

'The following example demonstrates using asynchronous methods to
'get Domain Name System information for the specified host computer.
'This example polls to detect the end of the asynchronous operation.

Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Namespace Examples.AdvancedProgramming.AsynchronousOperations

    Public Class PollUntilOperationCompletes
        Shared Sub UpdateUserInterface()
            ' Print a period to indicate that the application
            ' is still working on the request.
            Console.Write(".")
        End Sub
        Public Shared Sub Main(args() as String)
            ' Make sure the caller supplied a host name.
            If (args.Length = 0)
                ' Print a message and exit.
                Console.WriteLine("You must specify the name of a host computer.")
                End
            End If
            ' Start the asynchronous request for DNS information.
            Dim result as IAsyncResult = Dns.BeginGetHostEntry(args(0), Nothing, Nothing)
            Console.WriteLine("Processing request for information...")

            ' Poll for completion information.
            ' Print periods (".") until the operation completes.
            Do while result.IsCompleted <> True
                UpdateUserInterface()
            Loop
            ' The operation is complete. Process the results.
            ' Print a new line.
            Console.WriteLine()
            Try
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
'</Snippet3>
