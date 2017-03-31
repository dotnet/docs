using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web;
using System.Web.Services;

public class Form1: Form
{
 public void Method(Uri myUri)
 {
// <Snippet1>
ServicePointManager.CertificatePolicy = new MyCertificatePolicy();
 
       // Create the request and receive the response
       try
       {
       WebRequest myRequest = WebRequest.Create(myUri);
       WebResponse myResponse = myRequest.GetResponse();
       ProcessResponse(myResponse);
       myResponse.Close();
       }
       // Catch any exceptions
       catch(WebException e)
       {
       if (e.Status == WebExceptionStatus.TrustFailure)
       {
       // Code for handling security certificate problems goes here.
       }
       // Other exception handling goes here
       }
   
// </Snippet1>
 }

    // Method added so sample will compile
    public void ProcessResponse(WebResponse resp)
    {}
}


// Class added so sample will compile
public class MyCertificatePolicy : ICertificatePolicy
{
    public bool CheckValidationResult(System.Net.ServicePoint srvPoint, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Net.WebRequest request, int certificateProblem)
    {
        return true;
    }
}