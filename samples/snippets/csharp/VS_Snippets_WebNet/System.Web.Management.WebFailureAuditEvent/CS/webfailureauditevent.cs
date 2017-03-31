/**
  *File name: WebFailureAuditEvent.cs
  *Purpose: Implements a custom WebFailureAuditEvent type
  *by inheriting from the System.Web.Management.WebFailureAuditEvent class
  **/

// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
    // Implements a custom WebFailureAuditEvent class. 
    public class SampleWebFailureAuditEvent : 
        System.Web.Management.WebFailureAuditEvent
    {
        private string customCreatedMsg, customRaisedMsg;


        // <Snippet2>
        // Invoked in case of events identified only by their event code.
        public SampleWebFailureAuditEvent(string msg, object eventSource,
            int eventCode):
        base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
                string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }
        // </Snippet2>


        // <Snippet3>
        // Invoked in case of events identified by their event code and 
        // event detailed code.
        public SampleWebFailureAuditEvent(string msg, object eventSource,
            int eventCode, int detailedCode):
        base(msg, eventSource, eventCode, detailedCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
            string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }

        // </Snippet3>


        // <Snippet4>
        // Raises the SampleWebFailureAuditEvent.
        public override void Raise()
        {
            // Perform custom processing.
            customRaisedMsg =
                string.Format("Event raised at: {0}", 
                DateTime.Now.TimeOfDay.ToString());

            // Raise the event.
            WebBaseEvent.Raise(this);
        }
        // </Snippet4>


        // <Snippet5>
        // Obtains the current thread information.
        public WebRequestInformation GetRequestInformation()
        {
            // No customization is allowed.
            return RequestInformation;
        }
        // </Snippet5>


        // <Snippet6>
        //Formats Web request event information.
        //This method is invoked indirectly by the provider 
        //using one of the overloaded ToString methods.
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine(
                "******** SampleWebFailureAuditEvent Start ********");
            formatter.AppendLine(string.Format("Request path: {0}",
                RequestInformation.RequestPath));
            formatter.AppendLine(string.Format("Request Url: {0}",
                RequestInformation.RequestUrl));

            // Display custom event timing.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);

            formatter.AppendLine(
                "******** SampleWebFailureAuditEvent End ********");

            formatter.IndentationLevel -= 1;

        }
        // </Snippet6>
    }

}
// </Snippet1>

