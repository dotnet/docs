//NCLCustomWebClient

using System;
using System.Net;

namespace Examples.DerivedWebClient
{
    public class Test
    {
        public static void Main ()
        {
            CustomWebClient newClient = new CustomWebClient ();
        }
    }
    public class CustomWebClient:WebClient
    {
        //<snippet1>
        protected override WebRequest GetWebRequest (Uri address)
        {
            WebRequest request = (WebRequest) base.GetWebRequest (address);

            // Perform any customizations on the request.
            // This version of WebClient always preauthenticates.
            request.PreAuthenticate = true;
            return request;
        }
        //</snippet1>
       // <snippet2>
        protected override WebResponse GetWebResponse (WebRequest request)
        {
            WebResponse response = base.GetWebResponse (request);
            // Perform any custom actions with the response ...
            return response;
        }
       // </snippet2>
       // <snippet3>
        protected override WebResponse GetWebResponse (WebRequest request, IAsyncResult result)
        {
            WebResponse response = base.GetWebResponse (request, result);
            // Perform any custom actions with the response ...
            return response;
        }
       // </snippet3>
       // <snippet4>
        protected override void OnDownloadDataCompleted (DownloadDataCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnDownloadDataCompleted(e);

            // Here you can perform any post event actions...
        }
        // </snippet4>
        // <snippet5>
        protected  override void OnDownloadFileCompleted (System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnDownloadFileCompleted(e);

            // Here you can perform any post event actions...
        }
        // </snippet5>
        // <snippet6>
        protected override void OnDownloadStringCompleted (DownloadStringCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnDownloadStringCompleted (e);
 
            // Here you can perform any post event actions...
        }
        // </snippet6>
        // <snippet7>
        protected override void OnOpenReadCompleted (OpenReadCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnOpenReadCompleted (e);

            // Here you can perform any post event actions...
        }
        // </snippet7>
        // <snippet8>
        protected override void OnOpenWriteCompleted (OpenWriteCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnOpenWriteCompleted (e);

            // Here you can perform any post event actions...
        }
        // </snippet8>
        // <snippet9>
        protected override void OnUploadDataCompleted (UploadDataCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnUploadDataCompleted (e);

            // Here you can perform any post event actions...
        }
        // </snippet9>
        // <snippet10>
        protected override void OnUploadFileCompleted (UploadFileCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnUploadFileCompleted (e);

            // Here you can perform any post event actions...
        }
        // </snippet10>
        // <snippet11>
        protected override void OnUploadStringCompleted (UploadStringCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnUploadStringCompleted (e);

            // Here you can perform any post event actions...
        }
        // </snippet11>

	// <snippet12>
        protected override void OnDownloadProgressChanged (DownloadProgressChangedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnDownloadProgressChanged (e);

            // Here you can perform any post event actions...
        }
        // </snippet12>

	// <snippet13>
        protected override void OnUploadProgressChanged (UploadProgressChangedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnUploadProgressChanged (e);

            // Here you can perform any post event actions...
        }
        // </snippet13>

		// <snippet14>
        protected override void OnUploadValuesCompleted (UploadValuesCompletedEventArgs e)
        {
            // Here you can perform any custom actions before the event is raised
            // and event handlers are called...

            base.OnUploadValuesCompleted (e);

            // Here you can perform any post event actions...
        }
        // </snippet14>
    }
}