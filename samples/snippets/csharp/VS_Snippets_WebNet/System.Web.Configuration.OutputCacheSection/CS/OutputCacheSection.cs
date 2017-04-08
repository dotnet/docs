using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
 
    class UsingOutputCacheSection
    {
      public static void Main()
      {

// <Snippet1>
     
       // Get the Web application configuration.
       System.Configuration.Configuration webConfig =
       WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

       // Get the section.
       string configPath = "system.web/caching/outputCache";
       System.Web.Configuration.OutputCacheSection outputCacheSection =
       (System.Web.Configuration.OutputCacheSection)webConfig.GetSection(
       configPath);

// </Snippet1>


                

// <Snippet3>

    // Get the current EnabledOutputCache.
    Boolean enabledOutputCache = 
        outputCacheSection.EnableOutputCache;

    // Set the EnabledOutputCache.
    outputCacheSection.EnableOutputCache = false;

// </Snippet3>

    // <Snippet4>

    // Get the current EnabledFragmentCache.
    Boolean enabledFragmentCache =
        outputCacheSection.EnableFragmentCache;

    // Set the EnabledFragmentCache.
    outputCacheSection.EnableFragmentCache = false;

    // </Snippet4>

    // <Snippet5>

    // Get the current OmitVaryStar.
    Boolean omitVaryStar =
        outputCacheSection.OmitVaryStar;

    // Set the OmitVaryStar.
    outputCacheSection.OmitVaryStar = false;

    // </Snippet5>


    // <Snippet6>

    // Get the current SendCacheControlHeader.
    Boolean sendCacheControlHeaderValue = 
        outputCacheSection.SendCacheControlHeader;

    // Set the SendCacheControlHeader.
    outputCacheSection.SendCacheControlHeader = false;

    // </Snippet6>

// <Snippet7>
    // Create a .OutputCacheSection object.
    System.Web.Configuration.OutputCacheSection outputCache = 
      new System.Web.Configuration.OutputCacheSection();

// </Snippet7>
      
  }
    } // UsingOutputCacheSection class end.

} // Samples.Aspnet.SystemWebConfiguration namespace end.

