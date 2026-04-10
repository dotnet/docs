' <LinkedTokens>
Imports System.Threading

Module Program
    Sub Main()
        ' Create the parent CancellationTokenSource.
        Using parentCts As New CancellationTokenSource()
            Dim parentToken As CancellationToken = parentCts.Token

            ' Create a linked child CancellationTokenSource.
            ' The child token is cancelled when the parent token is cancelled.
            Using childCts As CancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(parentToken)
                Dim childToken As CancellationToken = childCts.Token

                Console.WriteLine($"Parent is cancelled: {parentToken.IsCancellationRequested}")
                Console.WriteLine($"Child is cancelled: {childToken.IsCancellationRequested}")

                ' Cancel the parent.
                parentCts.Cancel()

                Console.WriteLine($"Parent is cancelled: {parentToken.IsCancellationRequested}")
                Console.WriteLine($"Child is cancelled: {childToken.IsCancellationRequested}")
            End Using
        End Using
    End Sub
End Module
' Output:
' Parent is cancelled: False
' Child is cancelled: False
' Parent is cancelled: True
' Child is cancelled: True
' </LinkedTokens>
