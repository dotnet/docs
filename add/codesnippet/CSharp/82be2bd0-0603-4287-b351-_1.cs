    static void EndWriteCallback(IAsyncResult asyncResult)
    {
        State tempState = (State)asyncResult.AsyncState;
        FileStream fStream = tempState.FStream;
        fStream.EndWrite(asyncResult);

        // Asynchronously read back the written data.
        fStream.Position = 0;
        asyncResult = fStream.BeginRead(
            tempState.ReadArray, 0 , tempState.ReadArray.Length, 
            new AsyncCallback(EndReadCallback), tempState);

        // Concurrently do other work, such as 
        // logging the write operation.
    }