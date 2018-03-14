/**
  *File name: WebprocessStatistics.cs
  *Purpose: Implements a custom WebBaseEvent type 
  *to use the System.Web.Management helper classes.
  **/

// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
    // Implements a custom WebBaseEvent type that 
    // uses the WebProcessStatistics.
    public class SampleWebProcessStatistics :
      WebBaseEvent
    {
        private StringBuilder eventInfo;
        private static WebProcessStatistics processStatistics;

        // <Snippet2>
        // Instantiate the SampleWebProcessStatistics
        // type.
        public SampleWebProcessStatistics(string msg, 
            object eventSource, int eventCode):
          base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            string customMsg = 
                string.Format("Event created at: {0}", 
                EventTime.ToString());

            eventInfo = new StringBuilder();
            eventInfo.AppendLine(customMsg);
            
            // Instantiate the WebProcessStatistics 
            // type.
            processStatistics = new WebProcessStatistics();
            
        }
        // </Snippet2>


        // <Snippet3>


        // </Snippet3>

        // <Snippet4>
        // Raises the event.
        public override void Raise()
        {
            // Perform custom processing. 
            eventInfo.Append(
                string.Format(
                "Event raised at: {0}\n", EventTime.ToString()));
            // Raise the event.
            base.Raise();
        }
        // </Snippet4>

        // <Snippet5>
        public string GetAppDomainCount()
        {
            // Get the app domain count.
            return (string.Format(
                "Application domain count: {0}",
                processStatistics.AppDomainCount.ToString()));
        }

        // </Snippet5>

        // <Snippet6>
        public string GetManagedHeapSize()
        {
            // Get the mamaged heap size.
            return (string.Format(
                "Managed heap size: {0}",
                processStatistics.ManagedHeapSize.ToString()));
        }

        // </Snippet6>

        // <Snippet7>
        public string GetPeakWorkingSet()
        {
            // Get the peak working set.
            return (string.Format(
                "Peak working set: {0}",
                processStatistics.PeakWorkingSet.ToString()));
        }

        // </Snippet7>

        // <Snippet8>
        public string GetProcessStartTime()
        {
            // Get the process start time.
            return (string.Format(
                "Process start time: {0}",
                processStatistics.ProcessStartTime.ToString()));
        }

        // </Snippet8>

        // <Snippet9>
        public string GetRequestsExecuting()
        {
            // Get the requests in execution.
            return (string.Format(
                "Requests executing: {0}",
                processStatistics.RequestsExecuting.ToString()));
        }

        // </Snippet9>


        // <Snippet10>
        public string GetRequestsQueued()
        {
            // Get the requests queued.
            return (string.Format(
                "Requests queued: {0}",
                processStatistics.RequestsQueued.ToString()));
        }

        // </Snippet10>

        // <Snippet11>
        public string GetRequestsRejected()
        {
            // Get the requests rejected.
            return (string.Format(
                "Requests rejected: {0}",
                processStatistics.RequestsRejected.ToString()));
        }

        // </Snippet11>

        // <Snippet12>
        public string GetThreadCount()
        {
            // Get the thread count.
            return (string.Format(
                "Thread count: {0}",
                processStatistics.ThreadCount.ToString()));
        }

        // </Snippet12>

        // <Snippet13>
        public string GetWorkingSet()
        {
            // Get the working set.
            return (string.Format(
                "Working set: {0}",
                processStatistics.WorkingSet.ToString()));
        }

        // </Snippet13>


        // <Snippet14>
        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.

            formatter.AppendLine("");
            formatter.AppendLine(
                "Custom Process Statistics:");

            formatter.IndentationLevel += 1;

            // Get the process statistics.
            formatter.AppendLine(GetAppDomainCount());
            formatter.AppendLine(GetManagedHeapSize());
            formatter.AppendLine(GetPeakWorkingSet());
            formatter.AppendLine(GetProcessStartTime());
            formatter.AppendLine(GetRequestsExecuting());
            formatter.AppendLine(GetRequestsQueued());
            formatter.AppendLine(GetRequestsRejected());
            formatter.AppendLine(GetThreadCount());
            formatter.AppendLine(GetWorkingSet());

            formatter.IndentationLevel -= 1;

            formatter.AppendLine(eventInfo.ToString());

        }
        // </Snippet14>


    }

}
// </Snippet1>

