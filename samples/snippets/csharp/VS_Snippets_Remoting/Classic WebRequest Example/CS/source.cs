using System;
using System.Net;

public class Sample {

    private void sampleFunction() {
// <Snippet1>
// Initialize the WebRequest.
WebRequest myRequest = WebRequest.Create("http://www.contoso.com");

// Return the response. 
WebResponse myResponse = myRequest.GetResponse();

// Code to use the WebResponse goes here.

// Close the response to free resources.
myResponse.Close();

// </Snippet1>
        }
}
