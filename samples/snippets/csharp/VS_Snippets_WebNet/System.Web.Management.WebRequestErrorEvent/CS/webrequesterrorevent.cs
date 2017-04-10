/**
  *File name: WebRequestErrorEvent.cs
  *Purpose: Implements a custom WebRequestErrorEvent type
  *by inheriting from the System.Web.Management.WebRequestErrorEvent.
  **/
  
// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace Samples.AspNet.Management
{
  // Implements a custom WebRequestErrorEvent class. 
    public class SampleWebRequestErrorEvent : 
        WebRequestErrorEvent
    {
        private StringBuilder eventInfo;

        // <Snippet2>
        // Invoked in case of events 
        // identified only by their event code.
        public SampleWebRequestErrorEvent(string msg, 
            object eventSource, int eventCode, 
            Exception e):
          base(msg, eventSource, eventCode, e)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: ", EventTime.ToString()));
        }
        // </Snippet2>


        // <Snippet3>
        // Invoked in case of events identified 
        // by their event code.and related event 
        // detailed code.
        public SampleWebRequestErrorEvent(
            string msg, object eventSource, 
            int eventCode, int detailedCode, 
            Exception e):
          base(msg, eventSource, 
            eventCode, detailedCode, e)
        {
            // Perform custom initialization.
            eventInfo = new StringBuilder();
            eventInfo.Append(string.Format(
                "Event created at: ", EventTime.ToString()));
        }

        // </Snippet3>

        // <Snippet4>
        // Raises the SampleWebRequestErrorEvent.
        public override void Raise()
        {
            // Perform custom processing. 
            eventInfo.Append(string.Format(
                "Event raised at: ", EventTime.ToString()));
            // Raise the event.
            base.Raise();
        }
        // </Snippet4>

        // <Snippet5>
        // Obtains the current request information.
        public string GetRequestInfo()
        {
            string reqInfo = GetRequestInfo();
            return reqInfo;
        }
        // </Snippet5>


        // <Snippet6>
        // Obtains the current thread information.
        public string GetThreadInfo()
        {
            string threadInfo = GetThreadInfo();
            return threadInfo;
        }
        // </Snippet6>


        // <Snippet7>
        // Obtains the current process information.
        public string GetProcessInfo()
        {
            string procInfo = GetProcessInfo();
            return procInfo;
        }
        // </Snippet7>


        // <Snippet8>
        //Formats Web request event information.
        public override void FormatCustomEventDetails(
               WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine(
                "** SampleWebRequestEvent Start **");

            // Add custom data.
            formatter.AppendLine(eventInfo.ToString());

            formatter.AppendLine(
                      "** SampleWebRequestEvent End **");

        }
        // </Snippet8>
    }

}
// </Snippet1>

