using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpBrowserCapabilities bc = Request.Browser;
Response.Write("<p>Browser Capabilities:</p>");
Response.Write("Type = " + bc.Type + "<br>");
Response.Write("Name = " + bc.Browser + "<br>");
Response.Write("Version = " + bc.Version + "<br>");
Response.Write("Major Version = " + bc.MajorVersion + "<br>");
Response.Write("Minor Version = " + bc.MinorVersion + "<br>");
Response.Write("Platform = " + bc.Platform + "<br>");
Response.Write("Is Beta = " + bc.Beta + "<br>");
Response.Write("Is Crawler = " + bc.Crawler + "<br>");
Response.Write("Is AOL = " + bc.AOL + "<br>");
Response.Write("Is Win16 = " + bc.Win16 + "<br>");
Response.Write("Is Win32 = " + bc.Win32 + "<br>");
Response.Write("Supports Frames = " + bc.Frames + "<br>");
Response.Write("Supports Tables = " + bc.Tables + "<br>");
Response.Write("Supports Cookies = " + bc.Cookies + "<br>");
Response.Write("Supports VB Script = " + bc.VBScript + "<br>");
Response.Write("Supports JavaScript = " + bc.JavaScript + "<br>");
Response.Write("Supports Java Applets = " + bc.JavaApplets + "<br>");
Response.Write("Supports ActiveX Controls = " + bc.ActiveXControls + "<br>");
Response.Write("CDF = " + bc.CDF + "<br>");
    
// </Snippet1>
 }
}
