    public static void OpenResourceForWriting2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the OpenWriteCallback method gets called
        // when the writeable stream is available.
        client.OpenWriteCompleted += new OpenWriteCompletedEventHandler (OpenWriteCallback2);
        client.OpenWriteAsync (uri, "POST");
        // Applications can perform other tasks
        // while waiting for the upload to complete.
    }
