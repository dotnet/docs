        Private Shared Sub UploadProgressCallback(ByVal sender As Object, ByVal e As UploadProgressChangedEventArgs)

            '  Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", _
             CStr(e.UserState), e.BytesSent, e.TotalBytesToSend, e.ProgressPercentage)
        End Sub
        Private Shared Sub DownloadProgressCallback(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

            '  Displays the operation identifier, and the transfer progress.
            Console.WriteLine("0}    downloaded 1} of 2} bytes. 3} % complete...", _
             CStr(e.UserState), e.BytesReceived, e.TotalBytesToReceive, e.ProgressPercentage)
        End Sub