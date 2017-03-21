        private static void UploadProgressCallback(object sender, UploadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", 
                (string)e.UserState, 
                e.BytesSent, 
                e.TotalBytesToSend,
                e.ProgressPercentage);
        }
        private static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", 
                (string)e.UserState, 
                e.BytesReceived, 
                e.TotalBytesToReceive,
                e.ProgressPercentage);
        }