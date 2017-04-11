/**
  *File name: WebThreadInformation.cs
  *Purpose: Implements a custom type to 
 * access the thread information. 
  **/

// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;


namespace SamplesAspNet
{
    // Implements a custom WebErrorstEvent that uses the 
    // WebThreadInformation. 
    public class SampleWebThreadInformation :
        WebErrorEvent
    {
        private StringBuilder eventInfo;

        // <Snippet2>
        // Instantiate events identified 
        // only by their event code.
        public SampleWebThreadInformation(
            string msg, object eventSource,
            int eventCode, Exception e)
            :
            base(msg, eventSource, eventCode, e)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
            "Event created at: {0}",
            EventTime.ToString()));

        }
        // </Snippet2>


        // <Snippet3>
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
        // </Snippet3>

        // <Snippet4>
        // Get the impersonation mode.
        public string GetThreadImpersonation()
        {
            return (string.Format(
                "Is impersonating: {0}",
                ThreadInformation.IsImpersonating.ToString()));
        }
        // </Snippet4>

        // <Snippet5>
        // Get the stack trace.
        public string GetThreadStackTrace()
        {
            return (string.Format(
                "Stack trace: {0}",
                ThreadInformation.StackTrace));
        }
        // </Snippet5>

        // <Snippet6>
        // Get the account name.
        public string GetThreadAccountName()
        {
            return (string.Format(
                "Request user host address: {0}",
                ThreadInformation.ThreadAccountName));
        }
        // </Snippet6>

        // <Snippet7>
        // Get the task Id.
        public string GetThreadId()
        {
            // Get the request principal.
            return (string.Format(
                "Thread Id: {0}",
                ThreadInformation.ThreadID.ToString()));
        }
        // </Snippet7>

        // <Snippet8>

        // Formats Web request event information.
        public override void FormatCustomEventDetails(
         WebEventFormatter formatter)
        {

            // Add custom data.

            formatter.AppendLine("");
            formatter.AppendLine(
                "Custom Thread Information:");

            formatter.IndentationLevel += 1;

            // Display the thread information obtained 
            formatter.AppendLine(GetThreadImpersonation());
            formatter.AppendLine(GetThreadStackTrace());
            formatter.AppendLine(GetThreadAccountName());
            formatter.AppendLine(GetThreadId());
            formatter.IndentationLevel -= 1;

            formatter.AppendLine(eventInfo.ToString());

        }

        // </Snippet8>
    }
}

// </Snippet1>

