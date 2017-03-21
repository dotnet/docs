
using System;
using System.Text;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SamplesAspNet
{
    // Implements a custom WebRequestEvent that uses
    // WebRequestInformation. 
    public class SampleWebRequestInformation :
        WebRequestEvent
    {
        private StringBuilder eventInfo;

        // Instantiate events identified 
        // only by their event code.
        public SampleWebRequestInformation(string msg,
            object eventSource, int eventCode):
        base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: {0}",
                EventTime.ToString()));
        }


        // Instantiate events identified by 
        // their event code.and related 
        // event detailed code.
        public SampleWebRequestInformation(string msg,
            object eventSource, int eventCode,
            int eventDetailCode)
            :
            base(msg, eventSource,
            eventCode, eventDetailCode)
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

        // Get the request path.
        public string GetRequestPath()
        {
            // Get the request path.
            return (string.Format(
                "Request path: {0}",
                RequestInformation.RequestPath));
        }

        // Get the request URL.
        public string GetRequestUrl()
        {
            // Get the request URL.
            return (string.Format(
                "Request URL: {0}",
                RequestInformation.RequestUrl));
        }

        // Get the request user host address.
        public string GetRequestUserHostAdddress()
        {
            // Get the request user host address.
            return (string.Format(
                "Request user host address: {0}",
                RequestInformation.UserHostAddress));
        }

        // Get the request principal.
        public string GetRequestPrincipal()
        {
            // Get the request principal.
            return (string.Format(
                "Request principal name: {0}",
                RequestInformation.Principal.Identity.Name));
        }


        // Formats Web request event information.
        public override void FormatCustomEventDetails(
         WebEventFormatter formatter)
        {

            // Add custom data.

            formatter.AppendLine("");
            formatter.AppendLine(
                "Custom Request Information:");

            formatter.IndentationLevel += 1;

            // Display the request information obtained 
            // using the WebRequestInformation object.
            formatter.AppendLine(GetRequestPath());
            formatter.AppendLine(GetRequestUrl());
            formatter.AppendLine(GetRequestUserHostAdddress());
            formatter.AppendLine(GetRequestPrincipal());

            formatter.IndentationLevel -= 1;

            formatter.AppendLine(eventInfo.ToString());

        }


    }
}