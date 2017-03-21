    Private Shared Sub EndWriteCallback(asyncResult As IAsyncResult)
        Dim tempState As State = _
            DirectCast(asyncResult.AsyncState, State)
        Dim fStream As FileStream = tempState.FStream
        fStream.EndWrite(asyncResult)

        ' Asynchronously read back the written data.
        fStream.Position = 0
        asyncResult = fStream.BeginRead( _ 
            tempState.ReadArray, 0 , tempState.ReadArray.Length, _
            AddressOf EndReadCallback, tempState)

        ' Concurrently do other work, such as 
        ' logging the write operation.
    End Sub