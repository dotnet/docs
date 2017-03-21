
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
    }

}