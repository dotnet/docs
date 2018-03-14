using System;
using System.Collections.Specialized;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Microsoft.WebProgrammingModel.Samples
{
    class Snippets
    {
        public static void Snippet1()
        {
        }

        public static void Snippet2()
        {
            // <Snippet2>
            WebOperationContext current = WebOperationContext.Current;
            WebHeaderCollection headers = current.IncomingRequest.Headers;

            foreach (string name in headers)
            {
                Console.WriteLine(name + " " + headers.Get(name));
            }
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            WebOperationContext current = WebOperationContext.Current;
            Console.WriteLine("Incoming Response");
            Console.WriteLine("ContentLength: " + current.IncomingResponse.ContentLength);
            Console.WriteLine("ContentType: " + current.IncomingResponse.ContentType);
            Console.WriteLine("StatusCode: " + current.IncomingResponse.StatusCode);
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            WebOperationContext.Current.OutgoingRequest.Headers.Add("Slug", "title");
            WebOperationContext.Current.OutgoingRequest.Method = "GET";
            WebOperationContext.Current.OutgoingRequest.ContentType = "application/octet-stream";
            // </Snippet4>
        }
    }
}
