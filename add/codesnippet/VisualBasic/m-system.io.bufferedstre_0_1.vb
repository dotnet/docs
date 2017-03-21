        ' Send the data using the BufferedStream.
        Console.WriteLine("Sending data using BufferedStream.")
        startTime = DateTime.Now
        For i As Integer = 1 To numberOfLoops
            bufStream.Write(dataToSend, 0, dataToSend.Length)
        Next i
        
        bufStream.Flush()
        bufferedTime = DateTime.Now.Subtract(startTime).TotalSeconds
        Console.WriteLine("{0} bytes sent In {1} seconds." & vbCrLf, _
            numberOfLoops * dataToSend.Length, _
            bufferedTime.ToString("F1"))