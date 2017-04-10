using System;
using System.Configuration;
using System.Web.Configuration;

namespace Samples.AspNet.Configuration
{
    // Accesses the System.Web.Configuration.ProcessModelSection
    // members selected by the user.
    class UsingProcessModelSection
    {
        public static void Main()
        {

            try
            {
                //  <Snippet1>

                // Get the Web application configuration
                System.Configuration.Configuration configuration = 
                    WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

                // Get the section.
                System.Web.Configuration.ProcessModelSection 
                    processModelSection = 
                        (ProcessModelSection)configuration.GetSection(
                        "system.web/processModel");

                // </Snippet1>

                // <Snippet2>

                // Get the current Enable property value.

                bool enable = processModelSection.Enable;

                // Set the Enable property to false.
                processModelSection.Enable = false;

                // </Snippet2>

                // <Snippet3>

                // Get the current MemoryLimit property value.
               int memLimit = processModelSection.MemoryLimit;

                // Set the MemoryLimit property to 50.
                processModelSection.MemoryLimit = 50;

                // </Snippet3>

                // <Snippet4>

                // Get the current MinIOThreads property value.
                int minIOThreads = processModelSection.MinIOThreads;

                // Set the MinIOThreads property to 1.
                processModelSection.MinIOThreads = 1;

                // </Snippet4>

                // <Snippet5>

                // Get the current MaxIOThreads property value.
               int maxIOThreads = 
                   processModelSection.MaxIOThreads;

                // Set the MaxIOThreads property to 64.
                processModelSection.MaxIOThreads = 64;

                // </Snippet5>

                // <Snippet6>

                // Get the current MinWorkerThreads property value.
              int minWorkerThreads = 
                  processModelSection.MinWorkerThreads;

                // Set the MinWorkerThreads property to 2.
                processModelSection.MinWorkerThreads = 2;

                // </Snippet6>

                // <Snippet7>

                // Get the current MaxWorkerThreads property value.
                int maxWorkerThreads = 
                    processModelSection.MaxWorkerThreads;

                // Set the MaxWorkerThreads property to 128.
                processModelSection.MaxWorkerThreads = 128;

                // </Snippet7>

                // <Snippet8>

                // Get the current RequestLimit property value.
                int reqLimit = 
                    processModelSection.RequestLimit;

                // Set the RequestLimit property to 4096.
                processModelSection.RequestLimit = 4096;

                // </Snippet8>

                // <Snippet9>

                // Get the current RestartQueueLimit property value.
                int restartQueueLimit = 
                    processModelSection.RestartQueueLimit;

                // Set the RestartQueueLimit property to 8.
                processModelSection.RestartQueueLimit = 8;

                // </Snippet9>

                // <Snippet10>

                // Get the current RequestQueueLimit property value.
                int requestQueueLimit =
                    processModelSection.RequestQueueLimit;

                // Set the RequestQueueLimit property to 10240.
                processModelSection.RequestQueueLimit = 10240;

                // </Snippet10>

                // <Snippet11>

                // Get the current ResponseRestartDeadlockInterval property
                // value.
                TimeSpan respRestartDeadlock =
                    processModelSection.ResponseRestartDeadlockInterval;

                // Set the ResponseRestartDeadlockInterval property to
                // TimeSpan.Parse("04:00:00").
                processModelSection.ResponseRestartDeadlockInterval = 
                    TimeSpan.Parse("04:00:00");

                // </Snippet11>

                // <Snippet12>

                // Get the current Timeout property value.
                TimeSpan timeout = 
                    processModelSection.Timeout;

                // Set the Timeout property to TimeSpan.Parse("00:00:30").
                processModelSection.Timeout = 
                    TimeSpan.Parse("00:00:30");

                // </Snippet12>

                // <Snippet13>

                // Get the current PingFrequency property value.
                TimeSpan pingFreq = 
                    processModelSection.PingFrequency;

                // Set the PingFrequency property to
                // TimeSpan.Parse("00:01:00").
                processModelSection.PingFrequency = 
                    TimeSpan.Parse("00:01:00");

                // </Snippet13>

                // <Snippet14>

                // Get the current PingTimeout property value.
                TimeSpan pingTimeout = 
                    processModelSection.PingTimeout;

                // Set the PingTimeout property to TimeSpan.Parse("00:00:30").
                processModelSection.PingTimeout = 
                    TimeSpan.Parse("00:00:30");

                // </Snippet14>

                // <Snippet15>

                // Get the current ShutdownTimeout property value.
                TimeSpan shutDownTimeout =
                    processModelSection.ShutdownTimeout;

                // Set the ShutdownTimeout property to
                // TimeSpan.Parse("00:00:30").
                processModelSection.ShutdownTimeout = 
                    TimeSpan.Parse("00:00:30");

                // </Snippet15>

                // <Snippet16>

                // Get the current IdleTimeout property value.
                TimeSpan idleTimeout = 
                    processModelSection.IdleTimeout;

                // Set the IdleTimeout property to TimeSpan.Parse("12:00:00").
                processModelSection.IdleTimeout = 
                    TimeSpan.Parse("12:00:00");

                // </Snippet16>

                // <Snippet17>

                // Get the current ResponseDeadlockInterval property value.
                TimeSpan respDeadlock  = 
                    processModelSection.ResponseDeadlockInterval;

                // Set the ResponseDeadlockInterval property to
                // TimeSpan.Parse("00:05:00").
                processModelSection.ResponseDeadlockInterval = 
                    TimeSpan.Parse("00:05:00");

                // </Snippet17>

                // <Snippet18>

                // Get the current ClientConnectedCheck property value.
                TimeSpan clConnectCheck = 
                 processModelSection.ClientConnectedCheck;

                // Set the ClientConnectedCheck property to
                // TimeSpan.Parse("00:15:00").
                processModelSection.ClientConnectedCheck = 
                    TimeSpan.Parse("00:15:00");

                // </Snippet18>

                // <Snippet19>

                // Get the current UserName property value.
                string userName = 
                  processModelSection.UserName;

                // Set the UserName property to "CustomUser".
                processModelSection.UserName = "CustomUser";

                // </Snippet19>

                // <Snippet20>

                // Get the current Password property value.
                string password = 
                    processModelSection.Password;

                // Set the Password property to "CUPassword".
                processModelSection.Password = "CUPassword";

                // </Snippet20>

                // <Snippet21>

                // Get the current ComAuthenticationLevel property value.
                ProcessModelComAuthenticationLevel comAuthLevel = 
                   processModelSection.ComAuthenticationLevel;

                // Set the ComAuthenticationLevel property to
                // ProcessModelComAuthenticationLevel.Call.
                processModelSection.ComAuthenticationLevel =
                    ProcessModelComAuthenticationLevel.Call;

                // </Snippet21>

                // <Snippet22>

                // Get the current ComImpersonationLevel property value.
                ProcessModelComImpersonationLevel comImpLevel = 
                    processModelSection.ComImpersonationLevel;

                // Set the ComImpersonationLevel property to
                // ProcessModelComImpersonationLevel.Anonymous.
                processModelSection.ComImpersonationLevel = 
                    ProcessModelComImpersonationLevel.Anonymous;

                // </Snippet22>

                // <Snippet23>

                // Get the current LogLevel property value.
                ProcessModelLogLevel comLogLevel = 
                    processModelSection.LogLevel;

                // Set the LogLevel property to ProcessModelLogLevel.All.
                processModelSection.LogLevel = ProcessModelLogLevel.All;

                // </Snippet23>

                // <Snippet24>

                // Get the current WebGarden property value.
                bool webGarden = 
                 processModelSection.WebGarden;

                // Set the WebGarden property to true.
                processModelSection.WebGarden = true;

                // </Snippet24>

                // <Snippet25>

                // Get the current CpuMask property value.
                int cpuMask = 
                 processModelSection.CpuMask;

                // Set the CpuMask property to 0x000000FF.
                processModelSection.CpuMask = 0x000000FF;

                // </Snippet25>

                // <Snippet26>

                // Get the current AsyncOption property value.
                // not in use anymore
                // int asyncOpt = 
                // processModelSection.AsyncOption;

                // Set the AsyncOption property to 0.
                // processModelSection.AsyncOption = 0;

                // </Snippet26>

                // <Snippet27>

                // Get the current MaxAppDomains property value.
                int maxAppdomains = 
                 processModelSection.MaxAppDomains;

                // Set the MaxAppDomains property to 4.
                processModelSection.MaxAppDomains = 4;

                // </Snippet27>

                // <Snippet28>

                // Get the current ServerErrorMessageFile property value.
                string srvErrMsgFile = 
                processModelSection.ServerErrorMessageFile;

                // Set the ServerErrorMessageFile property to
                // "custommessages.log".
                processModelSection.ServerErrorMessageFile = 
                    "custommessages.log";

                // </Snippet28>

                // Update if not locked.
                if (!processModelSection.SectionInformation.IsLocked)
                {
                    configuration.Save();
                }
                
            }
            catch (System.ArgumentException e)
            {
                // Never display this.
                string error = e.ToString();
                // Unknown error.
                
                string msgToDisplay = 
                    "Error detected in UsingProcessModelSection.";
                
            }
        }
    } 
    
} 

