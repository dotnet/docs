/**
  *File name: WebAuditEvent.cs
  *Purpose: Implements a custom WebAuditEvent type
  *by inheriting from the System.Web.Management.WebAuditEvent class.
  **/
  
// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
    // Implements a custom WebAuditEvent class. 
    public class SampleWebAuditEvent : System.Web.Management.WebAuditEvent
    {
        private string customCreatedMsg, customRaisedMsg;

        // <Snippet2>
        // Invoked in case of events identified only by their event code.
        public SampleWebAuditEvent(string msg, object eventSource, 
            int eventCode): base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
              string.Format("Event created at: {0}", 
              DateTime.Now.TimeOfDay.ToString());
        }
        // </Snippet2>


        // <Snippet3>
        // Invoked in case of events identified by their event code.and 
        // event detailed code.
        public SampleWebAuditEvent(string msg, object eventSource, 
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
        // Raises the SampleWebAuditEvent.
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
            // Obtain the Web request information.
            // No customization is allowed here.
            return RequestInformation;
        }
        // </Snippet5>


        // <Snippet6>
        //Formats Web request event information.
        //This method is invoked indirectly by the provider 
        // using one of the overloaded ToString() methods.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine(
                "******** SampleWebAuditEvent Information Start ********");
            formatter.AppendLine(string.Format("Request path: {0}",
              RequestInformation.RequestPath));
            formatter.AppendLine(string.Format("Request Url: {0}",
              RequestInformation.RequestUrl));

            // Display custom event timing.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);

            formatter.AppendLine(
                "******** SampleWebAuditEvent Information End ********");

            formatter.IndentationLevel -= 1;

        }
        // </Snippet6>
    }

}
// </Snippet1>

