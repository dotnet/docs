   Private Shared Sub EndReadCallback(asyncResult As IAsyncResult)
        Dim tempState As State = _
            DirectCast(asyncResult.AsyncState, State)
        Dim readCount As Integer = _
            tempState.FStream.EndRead(asyncResult)

        Dim i As Integer = 0
        While(i < readCount)
            If(tempState.ReadArray(i) <> tempState.WriteArray(i))
                Console.WriteLine("Error writing data.")
                tempState.FStream.Close()
                Return
            End If
            i += 1
        End While

        Console.WriteLine("The data was written to {0} and " & _
            "verified.", tempState.FStream.Name)
        tempState.FStream.Close()

        ' Signal the main thread that the verification is finished.
        tempState.ManualEvent.Set()
    End Sub