        ' Receive data using the BufferedStream.
        Console.WriteLine("Receiving data using BufferedStream.")
        bytesReceived = 0
        startTime = DateTime.Now

        Dim numBytesToRead As Integer = receivedData.Length
        Dim n As Integer
        Do While numBytesToRead > 0

            'Read my return anything from 0 to numBytesToRead
            n = bufStream.Read(receivedData, 0, receivedData.Length)
            'The end of the file is reached.
            If n = 0 Then
                Exit Do
            End If

            bytesReceived += n
            numBytesToRead -= n
        Loop

        bufferedTime = DateTime.Now.Subtract(startTime).TotalSeconds
        Console.WriteLine("{0} bytes received in {1} " & _
            "seconds." & vbCrLf, _
            bytesReceived.ToString(), _
            bufferedTime.ToString("F1"))