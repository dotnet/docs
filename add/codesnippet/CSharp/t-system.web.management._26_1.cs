using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
    // Implements a custom WebBaseEvent that uses
    // WebApplicationInformation.
    public class SampleWebApplicationInformation :
        WebBaseEvent
    {
        private StringBuilder eventInfo;

        // Instantiate SampleWebGet    
        public SampleWebApplicationInformation(string msg,
            object eventSource, int eventCode):
        base(msg, eventSource, eventCode)
        {
            
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: {0}",
                EventTime.ToString()));

        }

        // Raises the event.
        public override void Raise()
        {
            // Perform custom processing. 
            eventInfo.Append(string.Format(
            "Event raised at: {0}",
            EventTime.ToString()));

            // Raise the event.
            base.Raise();
        }
        public string GetApplicationDomain()
        {
            // Get the name of the application domain.
            return (string.Format(
                "Application domain: {0}",
                ApplicationInformation.ApplicationDomain));
        }
        public string GetApplicationPath()
        {
            // Get the name of the application  path.
            return (string.Format(
                "Application path: {0}",
                ApplicationInformation.ApplicationPath));
        }
        public string GetApplicationVirtualPath()
        {
            // Get the name of the application virtual path.
            return (string.Format(
                "Application virtual path: {0}",
                ApplicationInformation.ApplicationVirtualPath));
        }
        public string GetApplicationMachineName()
        {
            // Get the name of the application machine name.
            return (string.Format(
                "Application machine name: {0}",
                ApplicationInformation.MachineName));
        }
        public string GetApplicationTrustLevel()
        {
            // Get the name of the application trust level.
            return (string.Format(
                "Application trust level: {0}",
                ApplicationInformation.TrustLevel));
        }
        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");
            formatter.AppendLine(
            "Custom Application Information:");
            formatter.IndentationLevel += 1;

            // Display the application information.
            formatter.AppendLine(GetApplicationDomain());
            formatter.AppendLine(GetApplicationPath());
            formatter.AppendLine(GetApplicationVirtualPath());
            formatter.AppendLine(GetApplicationMachineName());
            formatter.AppendLine(GetApplicationTrustLevel());
            formatter.IndentationLevel -= 1;
            formatter.AppendLine(eventInfo.ToString());
        }
    }
}