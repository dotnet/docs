// NCLWebClientAsync
using System;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
 namespace Examples.WebClientSnippets
{
public class Test
{
    //<Snippet1>
    public static void UploadString (string address)
    {
        string data = "Time = 12:00am temperature = 50";
        WebClient client = new WebClient ();
        // Optionally specify an encoding for uploading and downloading strings.
        client.Encoding = System.Text.Encoding.UTF8;
        // Upload the data.
        string reply = client.UploadString (address, data);
        // Disply the server's response.
        Console.WriteLine (reply);
    }

    //</Snippet1>
    //<Snippet2>
    public static void PostString (string address)
    {
        string data = "Time = 12:00am temperature = 50";
        string method = "POST";
        WebClient client = new WebClient ();
        string reply = client.UploadString (address, method, data);

        Console.WriteLine (reply);
    }

    //</Snippet2>
    //<Snippet3>
    // Sample call: UploadFileInBackground3("http://www.contoso.com/fileUpload.aspx", "data.txt")
    public static void UploadFileInBackground3 (string address, string fileName)
    {
//<Snippet43>
        WebClient client = new WebClient ();

        Uri uri = new Uri(address);

        client.UseDefaultCredentials = true;
//</Snippet43>
        client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback2);
        client.UploadFileAsync (uri, fileName);
        Console.WriteLine ("File upload started.");
    }

    //</Snippet3>
    //<Snippet4>
    // Sample call: UploadFileInBackground2("http://www.contoso.com/fileUpload.aspx", "data.txt")
    public static void UploadFileInBackground2 (string address, string fileName)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback2);

	 // Specify a progress notification handler.
	 client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
        client.UploadFileAsync (uri, "POST", fileName);
        Console.WriteLine ("File upload started.");
    }

    //</Snippet4>
    //<Snippet5>
    private static void UploadFileCallback2 (Object sender, UploadFileCompletedEventArgs e)
    {
        string reply = System.Text.Encoding.UTF8.GetString (e.Result);
        Console.WriteLine (reply);
    }

    //</Snippet5>
    //<Snippet6>
    // Sample call: UploadFileInBackground("http://www.contoso.com/fileUpload.aspx", "data.txt")
    public static void UploadFileInBackground (string address, string fileName)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string method = "POST";

        // Specify that that UploadFileCallback method gets called
        // when the file upload completes.
        client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback);
        client.UploadFileAsync (uri, method, fileName, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the upload to complete.
        waiter.WaitOne ();
        Console.WriteLine ("File upload is complete.");
    }

    //</Snippet6>
    //<Snippet7>
    private static void UploadFileCallback (Object sender, UploadFileCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;;
        try
        {
            string reply = System.Text.Encoding.UTF8.GetString (e.Result);

            Console.WriteLine (reply);
        }
        finally
        {
            // If this thread throws an exception, make sure that
            // you let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet7>
    //<Snippet8>
    public static void UploadStringInBackground (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string data = "Time = 12:00am temperature = 50";
        string method = "POST";

        client.UploadStringCompleted += new UploadStringCompletedEventHandler (UploadStringCallback);
        client.UploadStringAsync (uri, method, data, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the upload to complete.
        waiter.WaitOne ();
        Console.WriteLine ("String upload is complete.");
    }

    //</Snippet8>
    //<Snippet9>
    private static void UploadStringCallback (Object sender, UploadStringCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;

        try
        {
            string reply = (string)e.Result;

            Console.WriteLine (reply);
        }
        finally
        {
            // If this thread throws an exception, make sure that
            // you let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet9>
    //<Snippet10>
    public static void OpenResourceForReading (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        client.OpenReadCompleted += new OpenReadCompletedEventHandler (OpenReadCallback);
        client.OpenReadAsync (uri, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the upload to complete.
        waiter.WaitOne ();
    }

    //</Snippet10>
    //<Snippet11>
    private static void OpenReadCallback (Object sender, OpenReadCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;
        Stream reply = null;
        StreamReader s = null;

        try
        {
            reply = (Stream)e.Result;
            s = new StreamReader (reply);
            Console.WriteLine (s.ReadToEnd ());
        }
        finally
        {
            if (s != null)
            {
                s.Close ();
            }

            if (reply != null)
            {
                reply.Close ();
            }

            // If this thread throws an exception, make sure that
            // you let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet11>
    //<Snippet12>
    public static void OpenResourceForWriting (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the OpenWriteCallback method gets called
        // when the writeable stream is available.
        client.OpenWriteCompleted += new OpenWriteCompletedEventHandler (OpenWriteCallback);
        client.OpenWriteAsync (uri, "POST", waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the upload to complete.
        waiter.WaitOne ();
    }

    //</Snippet12>
    //<Snippet13>
    private static void OpenWriteCallback (Object sender, OpenWriteCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;
        Stream body = null;
        StreamWriter s = null;

        try
        {
            body = (Stream)e.Result;
            s = new StreamWriter (body);
            s.AutoFlush = true;
            s.Write ("This is content data to be sent to the server.");
        }
        finally
        {
            if (s != null)
            {
                s.Close ();
            }

            if (body != null)
            {
                body.Close ();
            }

            // If this thread throws an exception, make sure that
            // you let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet13>
    //<Snippet14>
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

    //</Snippet14>
    //<Snippet15>
    private static void OpenWriteCallback2 (Object sender, OpenWriteCompletedEventArgs e)
    {
        Stream body = null;
        StreamWriter s = null;

        try
        {
            body = (Stream)e.Result;
            s = new StreamWriter (body);
            s.AutoFlush = true;
            s.Write ("This is content data to be sent to the server.");
        }
        finally
        {
            if (s != null)
            {
                s.Close ();
            }

            if (body != null)
            {
                body.Close ();
            }
        }
    }

    //</Snippet15>
    //<Snippet16>
    public static void OpenResourceForPosting (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the OpenWriteCallback method gets called
        // when the writeable stream is available.
        client.OpenWriteCompleted += new OpenWriteCompletedEventHandler (OpenWriteCallback2);
        client.OpenWriteAsync (uri);
        // Applications can perform other tasks
        // while waiting for the upload to complete.
    }

    //</Snippet16>
    //<Snippet17>
    // Sample call : DownLoadFileInBackground ("http://www.contoso.com/logs/January.txt");
    public static void DownLoadFileInBackground (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadFileCallback method gets called
        // when the download completes.
        client.DownloadFileCompleted += new AsyncCompletedEventHandler (DownloadFileCallback);

        client.DownloadFileAsync (uri, "serverdata.txt", waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the download to complete.
        waiter.WaitOne ();
    }

    //</Snippet17>
    //<Snippet18>
    private static void DownloadFileCallback (Object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            Console.WriteLine ("File download cancelled.");
        }

        if (e.Error != null)
        {
            Console.WriteLine (e.Error.ToString ());
        }

        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;

        // Let the main application thread resume.
        waiter.Set ();
    }

    //</Snippet18>
    //<Snippet19>
    // Sample call : DownLoadFileInBackground2 ("http://www.contoso.com/logs/January.txt");
    public static void DownLoadFileInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadFileCallback method gets called
        // when the download completes.
        client.DownloadFileCompleted += new AsyncCompletedEventHandler (DownloadFileCallback2);
        // Specify a progress notification handler.
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
        client.DownloadFileAsync (uri, "serverdata.txt");
    }

    //</Snippet19>
    //<Snippet20>
    private static void DownloadFileCallback2 (Object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            Console.WriteLine ("File download cancelled.");
        }

        if (e.Error != null)
        {
            Console.WriteLine (e.Error.ToString ());
        }
    }

    //</Snippet20>
    //<Snippet21>
    // Sample call : DownLoadDataInBackground ("http://www.contoso.com/GameScores.html");
    public static void DownloadDataInBackground (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadDataCallback method gets called
        // when the download completes.
        client.DownloadDataCompleted += new DownloadDataCompletedEventHandler (DownloadDataCallback);
        client.DownloadDataAsync (uri, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the download to complete.
        waiter.WaitOne ();
    }

    //</Snippet21>
    //<Snippet22>
    private static void DownloadDataCallback (Object sender, DownloadDataCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;

        try
        {
            // If the request was not canceled and did not throw
            // an exception, display the resource.
            if (!e.Cancelled && e.Error == null)
            {
                byte[] data = (byte[])e.Result;
                string textData = System.Text.Encoding.UTF8.GetString (data);

                Console.WriteLine (textData);
            }
        }
        finally
        {
            // Let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet22>
    //<Snippet23>
    // Sample call : DownloadDataInBackground2 ("http://www.contoso.com/GameScores.html");
    public static void DownloadDataInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadDataCallback2 method gets called
        // when the download completes.
        client.DownloadDataCompleted += new DownloadDataCompletedEventHandler (DownloadDataCallback2);
        client.DownloadDataAsync (uri);
    }

    //</Snippet23>
    //<Snippet24>
    private static void DownloadDataCallback2 (Object sender, DownloadDataCompletedEventArgs e)
    {
        // If the request was not canceled and did not throw
        // an exception, display the resource.
        if (!e.Cancelled && e.Error == null)
        {
            byte[] data = (byte[])e.Result;
            string textData = System.Text.Encoding.UTF8.GetString (data);

            Console.WriteLine (textData);
        }
    }

    //</Snippet24>
    //<Snippet25>
    public static void DownloadString (string address)
    {
        WebClient client = new WebClient ();
        string reply = client.DownloadString (address);

        Console.WriteLine (reply);
    }

    // </Snippet25>
    //<Snippet26>
    // Sample call : DownLoadStringInBackground ("http://www.contoso.com/GameScores.html");
    public static void DownloadStringInBackground (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadStringCallback method gets called
        // when the download completes.
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler (DownloadStringCallback);
        client.DownloadStringAsync (uri, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the download to complete.
        waiter.WaitOne ();
    }

    //</Snippet26>
    //<Snippet27>
    private static void DownloadStringCallback (Object sender, DownloadStringCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;

        try
        {
            // If the request was not canceled and did not throw
            // an exception, display the resource.
            if (!e.Cancelled && e.Error == null)
            {
                string textString = (string)e.Result;

                Console.WriteLine (textString);
            }
        }
        finally
        {
            // Let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet27>
    //<Snippet28>
    // Sample call : DownloadStringInBackground2 ("http://www.contoso.com/GameScores.html");
    public static void DownloadStringInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        // Specify that the DownloadStringCallback2 method gets called
        // when the download completes.
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler (DownloadStringCallback2);
        client.DownloadStringAsync (uri);
    }

    //</Snippet28>
    //<Snippet29>
    private static void DownloadStringCallback2 (Object sender, DownloadStringCompletedEventArgs e)
    {
        // If the request was not canceled and did not throw
        // an exception, display the resource.
        if (!e.Cancelled && e.Error == null)
        {
            string textString = (string)e.Result;

            Console.WriteLine (textString);
        }
    }

    //</Snippet29>
    //<Snippet30>
    public static void OpenResourceForReading2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);

        client.OpenReadCompleted += new OpenReadCompletedEventHandler(OpenReadCallback2);
        client.OpenReadAsync (uri);
    }

    //</Snippet30>
    //<Snippet31>
    private static void OpenReadCallback2 (Object sender, OpenReadCompletedEventArgs e)
    {
        Stream reply = null;
        StreamReader s = null;

        try
        {
            reply = (Stream)e.Result;
            s = new StreamReader (reply);
            Console.WriteLine (s.ReadToEnd ());
        }
        finally
        {
            if (s != null)
            {
                s.Close ();
            }

            if (reply != null)
            {
                reply.Close ();
            }
        }
    }

    //</Snippet31>
    //<Snippet32>
    public static void UploadDataInBackground (string address)
    {
        System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent (false);
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string text = "Time = 12:00am temperature = 50";
        byte[] data = System.Text.Encoding.UTF8.GetBytes (text);
        string method = "POST";

        client.UploadDataCompleted += new UploadDataCompletedEventHandler (UploadDataCallback);
        client.UploadDataAsync (uri, method, data, waiter);

        // Block the main application thread. Real applications
        // can perform other tasks while waiting for the upload to complete.
        waiter.WaitOne ();
        Console.WriteLine ("Data upload is complete.");
    }

    //</Snippet32>
    //<Snippet33>
    private static void UploadDataCallback (Object sender, UploadDataCompletedEventArgs e)
    {
        System.Threading.AutoResetEvent waiter = (System.Threading.AutoResetEvent)e.UserState;

        try
        {
            byte[] data = (byte[])e.Result;
            string reply = System.Text.Encoding.UTF8.GetString (data);

            Console.WriteLine (reply);
        }
        finally
        {
            // If this thread throws an exception, make sure that
            // you let the main application thread resume.
            waiter.Set ();
        }
    }

    //</Snippet33>
    //<Snippet34>
    public static void UploadDataInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string text = "Time = 12:00am temperature = 50";
        byte[] data = System.Text.Encoding.UTF8.GetBytes (text);
        string method = "POST";

        client.UploadDataCompleted += new UploadDataCompletedEventHandler (UploadDataCallback2);
        client.UploadDataAsync (uri, method, data);
    }

    //</Snippet34>
    //<Snippet35>
    private static void UploadDataCallback2 (Object sender, UploadDataCompletedEventArgs e)
    {
        byte[] data = (byte[])e.Result;
        string reply = System.Text.Encoding.UTF8.GetString (data);

        Console.WriteLine (reply);
    }

    //</Snippet35>
    //<Snippet36>
    public static void UploadDataInBackground3 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string text = "Time = 12:00am temperature = 50";
        byte[] data = System.Text.Encoding.UTF8.GetBytes (text);

        client.UploadDataCompleted += new UploadDataCompletedEventHandler (UploadDataCallback3);
        client.UploadDataAsync (uri, data);
    }

    //</Snippet36>
    //<Snippet37>
    private static void UploadDataCallback3 (Object sender, UploadDataCompletedEventArgs e)
    {
        byte[] data = (byte[])e.Result;
        string reply = System.Text.Encoding.UTF8.GetString (data);

        Console.WriteLine (reply);
    }

    //</Snippet37>

    //<Snippet38>
    public static void UploadStringInBackground2 (string address)
    {
        WebClient client = new WebClient ();
        Uri uri = new Uri(address);
        string data = "Time = 12:00am temperature = 50";
        client.UploadStringCompleted += new UploadStringCompletedEventHandler (UploadStringCallback2);
        client.UploadStringAsync (uri, data);
    }

    //</Snippet38>
    //<Snippet39>
    private static void UploadStringCallback2 (Object sender, UploadStringCompletedEventArgs e)
    {
            string reply = (string)e.Result;
            Console.WriteLine (reply);
    }
    //</Snippet39>

        //<Snippet40>
        public static void UploadStringInBackground3 (string address)
        {
            WebClient client = new WebClient ();
            Uri uri = new Uri(address);
            string data = "Time = 12:00am temperature = 50";
            string method = "POST";
            client.UploadStringCompleted += new UploadStringCompletedEventHandler (UploadStringCallback2);
            client.UploadStringAsync (uri, method, data);
        }
        //</Snippet40>
        //<Snippet41>

        // Sample call : DownLoadFileWithProgressNotify ("http://www.contoso.com/logs/January.txt");
        public static void DownLoadFileWithProgressNotify(string address)
        {
            WebClient client = new WebClient ();
            Uri uri = new Uri(address);

            // Specify that the DownloadFileCallback method gets called
            // when the download completes.
            client.DownloadFileCompleted += new AsyncCompletedEventHandler (DownloadFileCallback2);
            // Specify a progress notification handler.
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);

            // The user token, shown here as ID 1234, is used to uniquely
            // identify notification events raised for this data transfer operation.
            client.DownloadFileAsync (uri, "serverdata.txt", "ID 1234");
        }
                //</Snippet41>
                //<Snippet42>
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
        //</Snippet42>
        // nothing below this line appears in the docs.
//[System.Security.Permissions.FileIOPermissionAttribute(System.Security.Permissions.SecurityAction.Deny, Write=@"c:\whidbeycode\ncl.xml")]

    public static void Main (string[] args)
    {
        // OpenResourceForReading ("http://google.com");
         //OpenResourceForReading2("http://google.com");
         //  System.Threading.Thread.Sleep (10000);

         UploadDataInBackground2 ("http://JOHNALLRED-0/test/postaccepter.aspx");
		  
         // DownloadString ("http://google.com");
   /*
        UploadDataInBackground ("http://sharriso1/test/postaccepter.aspx");
        
        System.Threading.Thread.Sleep (1000);
        UploadDataInBackground3 ("http://sharriso1/test/postaccepter.aspx");
        System.Threading.Thread.Sleep (1000);
  
        UploadStringInBackground ("http://sharriso1/test/postaccepter.aspx");
        UploadStringInBackground2 ("http://sharriso1/test/postaccepter.aspx");
        System.Threading.Thread.Sleep (1000);
        UploadStringInBackground3 ("http://sharriso1/test/postaccepter.aspx");
        System.Threading.Thread.Sleep (1000);
    */
        // OpenResourceForWriting2("http://sharriso1/test/postaccepter.aspx");
        // DownloadDataInBackground ("http://google.com");
        //System.Threading.Thread.Sleep (10000);
        // DownloadString ("http://google.com");
        //  DownloadStringInBackground ("http://google.com");
        //  DownloadStringInBackground2 ("http://google.com");
        //  System.Threading.Thread.Sleep (1000); 
         //  DownLoadFileInBackground2 ("http://sharriso1/test/uploadedFiles/onesandtwos.txt");
         DownLoadFileWithProgressNotify("http://JOHNALLRED-0/test/uploadedFiles/onesandtwos.txt");
        //System.Threading.Thread.Sleep (10000);
        // UploadString ();
        //   UploadStringInBackground ("http://sharriso1/test/fileUploadercs.aspx");
        //   UploadFileInBackground2 ("http://sharriso1/test/fileUploadercs.aspx", "onesandtwos.txt");

      //  UploadFileInBackground3 ("http://sharriso1/test/fileUploadercs.aspx", "onesandtwos.txt");
         System.Threading.Thread.Sleep (1000);

    }
}
    }
