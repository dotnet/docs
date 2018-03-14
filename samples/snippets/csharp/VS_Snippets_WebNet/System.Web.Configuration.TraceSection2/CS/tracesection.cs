// <Snippet1>
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
    // Accesses the System.Web.Configuration.TraceSection members
    // selected by the user.
    class UsingTraceSection
    {
        public static void Main()
        {
            // Process the System.Web.Configuration.TraceSectionobject.
            try
            {
                // Get the Web application configuration.
                System.Configuration.Configuration configuration = 
                    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/aspnet");
                
                // Get the section.
                System.Web.Configuration.TraceSection traceSection = 
                    (System.Web.Configuration.TraceSection) 
                    configuration.GetSection("system.web/trace");
// <Snippet2>

// Get the current PageOutput property value.
Boolean pageOutputValue = traceSection.PageOutput;

// Set the PageOutput property to true.
traceSection.PageOutput = true;

// </Snippet2>
                
// <Snippet3>

// Get the current WriteToDiagnosticsTrace property value.
Boolean writeToDiagnosticsTraceValue = traceSection.WriteToDiagnosticsTrace;

// Set the WriteToDiagnosticsTrace property to true.
traceSection.WriteToDiagnosticsTrace = true;

// </Snippet3>
                
// <Snippet4>

// Get the current MostRecent property value.
Boolean mostRecentValue = traceSection.MostRecent;

// Set the MostRecent property to true.
traceSection.MostRecent = true;

// </Snippet4>
                
// <Snippet5>

// Get the current RequestLimit property value.
Int32 requestLimitValue = traceSection.RequestLimit;

// Set the RequestLimit property to 256.
traceSection.RequestLimit = 256;

// </Snippet5>
                
// <Snippet6>

// Get the current LocalOnly property value.
Boolean localOnlyValue = traceSection.LocalOnly;

// Set the LocalOnly property to false.
traceSection.LocalOnly = false;

// </Snippet6>
                
// <Snippet7>

// Get the current Enabled property value.
Boolean enabledValue = traceSection.Enabled;

// Set the Enabled property to false.
traceSection.Enabled = false;

// </Snippet7>
                
// <Snippet8>

// Get the current Mode property value.
// TraceDisplayMode modeValue = traceSection.TraceMode;

// Set the Mode property to TraceDisplayMode.SortyByTime.
// traceSection.Mode = TraceDisplayMode.SortByTime;

// </Snippet8>
                
                // Update if not locked.
                if (! traceSection.SectionInformation.IsLocked)
                {
                    configuration.Save();
                    Console.WriteLine("** Configuration updated.");
                }
                else
                    Console.WriteLine("** Could not update, section is locked.");
            }
            catch (System.ArgumentException e)
            {
                // Unknown error.
                Console.WriteLine(
                    "A invalid argument exception detected in UsingTraceSection Main. Check your");
                Console.WriteLine("command line for errors.");
            }
        }
    } // UsingTraceSection class end.
    
} // Samples.Aspnet.SystemWebConfiguration namespace end.

// </Snippet1>
