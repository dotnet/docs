using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {

   // <Snippet1>
   HttpClientCertificate cs = Request.ClientCertificate;
 
   Response.Write("ClientCertificate Settings:<br>");
   Response.Write("Certificate = " + cs.Certificate + "<br>");
   Response.Write("Cookie = " + cs.Cookie + "<br>");
   Response.Write("Flags = " + cs.Flags + "<br>");
   Response.Write("IsPresent = " + cs.IsPresent + "<br>");
   Response.Write("Issuer = " + cs.Issuer + "<br>");
   Response.Write("IsValid = " + cs.IsValid + "<br>");
   Response.Write("KeySize = " + cs.KeySize + "<br>");
   Response.Write("SecretKeySize = " + cs.SecretKeySize + "<br>");
   Response.Write("SerialNumber = " + cs.SerialNumber + "<br>");
   Response.Write("ServerIssuer = " + cs.ServerIssuer + "<br>");
   Response.Write("ServerSubject = " + cs.ServerSubject + "<br>");
   Response.Write("Subject = " + cs.Subject + "<br>");
   Response.Write("ValidFrom = " + cs.ValidFrom + "<br>");
   Response.Write("ValidUntil = " + cs.ValidUntil + "<br>");
   Response.Write("What's this = " + cs.ToString() + "<br>");
    
   // </Snippet1>
 }
}
