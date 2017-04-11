/**
  *File name: WebProcessInformation.cs
  *Purpose: Implements a custom type to acess 
  *the process information.: 
  **/
  
// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
    // Implements a custom WebBaseEvent type that 
    // uses WebProcessInformation.
    public class SampleWebProcessInformation: 
        WebManagementEvent
    {
        private StringBuilder eventInfo;
        // <Snippet2>
        // Instantiate SampleWebProcessInformation.    
        public SampleWebProcessInformation(string msg, 
            object eventSource, int eventCode) : 
        base(msg, eventSource, eventCode)
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
        public string GetAccountName()
        {
            // Get the name of the account.
            return (string.Format(
                "Account name: {0}", 
                ProcessInformation.AccountName));
        }
        // </Snippet4>

        // <Snippet5>
        public string GetProcessId()
        {
            // Get the process identifier.
            return (string.Format(
                "Process Id: {0}", 
                ProcessInformation.ProcessID.ToString()));
        }
        // </Snippet5>

        // <Snippet6>
        public string GetProcessName()
        {
            // Get the requests in execution.
            return (string.Format(
                "Process name: {0}", 
                ProcessInformation.ProcessName));
        }
        // </Snippet6>

        // <Snippet7>
        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("Custom Process Information:");
            formatter.IndentationLevel += 1;

            // Display the process information.
            formatter.AppendLine(GetAccountName());
            formatter.AppendLine(GetProcessId());
            formatter.AppendLine(GetProcessName());
            formatter.IndentationLevel -= 1;
            formatter.AppendLine(eventInfo.ToString());
        }
        // </Snippet7>
    }

}
// </Snippet1>

