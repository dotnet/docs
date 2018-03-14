/**
  *File name: WebManagementEvent.cs
  *Purpose: Implements a custom WebManagementEvent type
  **/
  
// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace Samples.AspNet.Management
{
    // Implements a custom 
    // WebManagementEvent class. 
    public class SampleWebManagementEvent : 
        WebManagementEvent
    {
        private StringBuilder eventInfo;

        // <Snippet2>
        // Invoked in case of events 
        // identified only by their event code.
        public SampleWebManagementEvent(string msg, 
            object eventSource, int eventCode):
        base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: ", 
                EventTime.ToString()));
        }
        // </Snippet2>


        // <Snippet3>
        // Invoked in case of events identified 
        // by their event code.and related 
        // event detailed code.
        public SampleWebManagementEvent(string msg, 
            object eventSource, int eventCode, 
            int eventDetailCode):
          base(msg, eventSource, 
            eventCode, eventDetailCode)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: ", 
                EventTime.ToString()));
        }

        // </Snippet3>

        // <Snippet4>
        // Raises the SampleWebRequestEvent.
        public override void Raise()
        {
            // Perform custom processing. 
            eventInfo.Append(string.Format(
                "Event raised at: ", 
                EventTime.ToString()));
            // Raise the event.
            base.Raise();
        }
        // </Snippet4>


        // <Snippet5>
        // Obtains the current process information.
        public string GetProcessInfo()
        {
            StringBuilder tempPi = new StringBuilder();
            WebProcessInformation pi = ProcessInformation;
            tempPi.Append(
                pi.ProcessName + Environment.NewLine);
            tempPi.Append(
                pi.ProcessID.ToString() + Environment.NewLine);
            tempPi.Append(
                pi.AccountName + Environment.NewLine);
            return tempPi.ToString();
        }
        // </Snippet5>


        // <Snippet6>
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine(
                "** SampleWebManagementEvent Start **");
          
            // Add custom data.
            formatter.AppendLine(eventInfo.ToString());

            formatter.AppendLine(
                      "** SampleWebManagementEvent End **");
          
        }
        // </Snippet6>
    }

}
// </Snippet1>

