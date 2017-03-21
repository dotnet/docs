  static void UploadProgressCallback(Object^ sender, 
            UploadProgressChangedEventArgs^ e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console::WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...", 
                (String ^)e->UserState, 
                e->BytesSent, 
                e->TotalBytesToSend,
                e->ProgressPercentage);
        }
  static void DownloadProgressCallback(Object^ sender, 
            DownloadProgressChangedEventArgs^ e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console::WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", 
                (String ^)e->UserState, 
                e->BytesReceived, 
                e->TotalBytesToReceive,
                e->ProgressPercentage);
        }