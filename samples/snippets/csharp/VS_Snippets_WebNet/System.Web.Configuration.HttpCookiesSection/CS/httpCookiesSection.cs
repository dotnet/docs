using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
    // Accesses the System.Web.Configuration.HttpCookiesSection
    // members selected by the user.
  class UsingHttpCookiesSection
  {
    public static void Main()
    {

// <Snippet1>
    
      // Get the Web application configuration.
      System.Configuration.Configuration webConfig =
      WebConfigurationManager.OpenWebConfiguration("/aspnetTest");


      // Get the section.
      string configPath = "system.web/httpCookies";
      System.Web.Configuration.HttpCookiesSection httpCookiesSection =
      (System.Web.Configuration.HttpCookiesSection)webConfig.GetSection(
      configPath);

// </Snippet1>

// <Snippet5>
      System.Web.Configuration.HttpCookiesSection cookiesSection =
        new System.Web.Configuration.HttpCookiesSection();
// </Snippet5>


// <Snippet2>

      // Get the current Domain.
      string domainValue = 
          httpCookiesSection.Domain;

      // Set the Domain.
      httpCookiesSection.Domain = 
          string.Empty;

// </Snippet2>

 
// <Snippet3>

      // Get the current RequireSSL.
      Boolean requireSSLValue = 
          httpCookiesSection.RequireSSL;

      // Set the RequireSSL.
      httpCookiesSection.RequireSSL = 
          false;

// </Snippet3>
 
               
// <Snippet4>

      // Get the current HttpOnlyCookies.
      Boolean httpOnlyCookiesValue = 
          httpCookiesSection.HttpOnlyCookies;

      // Set the HttpOnlyCookies.
      httpCookiesSection.HttpOnlyCookies = 
          false;

// </Snippet4>

      }
 
    } // UsingHttpCookiesSection class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.