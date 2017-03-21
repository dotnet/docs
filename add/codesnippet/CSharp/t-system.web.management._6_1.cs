
using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
    // Implements a custom WebAuthenticationFailureAuditEvent class. 
    public class SampleWebAuthenticationFailureAuditEvent : 
        System.Web.Management.WebAuthenticationFailureAuditEvent
    {
        private string customCreatedMsg, customRaisedMsg;


        // Invoked in case of events identified only by 
        // their event code.
        public SampleWebAuthenticationFailureAuditEvent(
            string msg, object eventSource, 
            int eventCode, string userName):
        base(msg, eventSource, eventCode, userName)
        {
            // Perform custom initialization.
            customCreatedMsg =
                string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }


        // Invoked in case of events identified by their event code.and 
        // event detailed code.
        public SampleWebAuthenticationFailureAuditEvent(
            string msg, object eventSource,
            int eventCode, int detailedCode, string userName):
        base(msg, eventSource, eventCode, detailedCode, userName)
        {
            // Perform custom initialization.
            customCreatedMsg =
            string.Format("Event created at: {0}",
                DateTime.Now.TimeOfDay.ToString());
        }



        // Raises the SampleWebAuthenticationFailureAuditEvent.
        public override void Raise()
        {
            // Perform custom processing.
            customRaisedMsg =
                string.Format("Event raised at: {0}", 
                DateTime.Now.TimeOfDay.ToString());

            // Raise the event.
            WebBaseEvent.Raise(this);
        }


        // Obtains the current thread information.
        public WebRequestInformation GetRequestInformation()
        {
            // No customization is allowed.
            return RequestInformation;
        }


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
                "* SampleWebAuthenticationFailureAuditEvent Start *");
            formatter.AppendLine(string.Format("Request path: {0}",
                RequestInformation.RequestPath));
            formatter.AppendLine(string.Format("Request Url: {0}",
                RequestInformation.RequestUrl));

            // Display custom event timing.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);

            formatter.AppendLine(
                "* SampleWebAuthenticationFailureAuditEvent End *");

            formatter.IndentationLevel -= 1;

        }
    }

}