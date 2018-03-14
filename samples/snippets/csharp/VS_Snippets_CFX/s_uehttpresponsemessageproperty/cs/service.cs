// S_UEHttpResponseMessageProperty/cs/Service.cs snippet file
// based on
// \dd\Indigo_WAP\ndp\indigo\samples\internal\ChannelSDK\Samples\AlternateChannelDispatcher\Service\Service.cs:
// 
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Net;

namespace Microsoft.ServiceModel.Samples
{
    public class SnippetClass
    {
        public static void Main()
        {
	    // <Snippet0>
		HttpResponseMessageProperty responseProperty =
			new HttpResponseMessageProperty();
		responseProperty.StatusCode = HttpStatusCode.OK;
		responseProperty.Headers.Add(
					     HttpResponseHeader.ContentType,
					     "text/html; charset=UTF-8");
	    // </Snippet0>
		
	    // <Snippet1>
            WebHeaderCollection whCollection =
			responseProperty.Headers;
	    // </Snippet1>

	    // <Snippet2>
	    String name = HttpResponseMessageProperty.Name;
	    // </Snippet2>

	    // <Snippet3>
	    HttpStatusCode httpStatusCode =
	        responseProperty.StatusCode;
	    // </Snippet3>

	    // <Snippet4>
	    string statusDescription =
		responseProperty.StatusDescription;
	    // </Snippet4>

	    // <Snippet5>
	    // A value of true suppresses the message body.
	    responseProperty.SuppressEntityBody =  true;
	    // </Snippet5>


        }
    }
}
