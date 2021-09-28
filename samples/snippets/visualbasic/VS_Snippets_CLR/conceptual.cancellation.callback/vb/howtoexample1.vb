Imports System.Net
Imports System.Threading

Friend Class CancelWithCallback
    Private Shared Sub Main()
        Using cts = New CancellationTokenSource()
            Dim token = cts.Token
            Task.Run(
                Async Function()
                    Using client As New WebClient()
                        AddHandler client.DownloadDataCompleted,
                        Sub(__, args)
                            If args.Cancelled Then
                                Console.WriteLine("The download was canceled.")
                            Else
                                Console.WriteLine($"The download has completed:{vbLf}")
                                Console.WriteLine($"{args.Result}{vbLf}{vbLf}Press any key to continue.")
                            End If
                        End Sub

                        If Not token.IsCancellationRequested Then
                            Dim ctr As CancellationTokenRegistration = token.Register(Sub() client.CancelAsync())
                            Console.WriteLine($"Starting request{vbLf}")
                            Await client.DownloadStringTaskAsync(New Uri("http://www.contoso.com"))
                        End If
                    End Using

                End Function, token)

            Console.WriteLine($"Press 'c' to cancel.{vbLf}{vbLf}")

            If Console.ReadKey().KeyChar = "c"c Then
                cts.Cancel()
            End If

            Console.WriteLine($"{vbLf}Press any key to exit.")
            Console.ReadKey()

        End Using
    End Sub
End Class