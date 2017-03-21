
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

        public string GetAppDomainCount()
        {
            // Get the app domain count.
            return (string.Format(
                "Application domain count: {0}",
                processStatistics.AppDomainCount.ToString()));
        }


        public string GetManagedHeapSize()
        {
            // Get the mamaged heap size.
            return (string.Format(
                "Managed heap size: {0}",
                processStatistics.ManagedHeapSize.ToString()));
        }


        public string GetPeakWorkingSet()
        {
            // Get the peak working set.
            return (string.Format(
                "Peak working set: {0}",
                processStatistics.PeakWorkingSet.ToString()));
        }


        public string GetProcessStartTime()
        {
            // Get the process start time.
            return (string.Format(
                "Process start time: {0}",
                processStatistics.ProcessStartTime.ToString()));
        }


        public string GetRequestsExecuting()
        {
            // Get the requests in execution.
            return (string.Format(
                "Requests executing: {0}",
                processStatistics.RequestsExecuting.ToString()));
        }



        public string GetRequestsQueued()
        {
            // Get the requests queued.
            return (string.Format(
                "Requests queued: {0}",
                processStatistics.RequestsQueued.ToString()));
        }


        public string GetRequestsRejected()
        {
            // Get the requests rejected.
            return (string.Format(
                "Requests rejected: {0}",
                processStatistics.RequestsRejected.ToString()));
        }


        public string GetThreadCount()
        {
            // Get the thread count.
            return (string.Format(
                "Thread count: {0}",
                processStatistics.ThreadCount.ToString()));
        }


        public string GetWorkingSet()
        {
            // Get the working set.
            return (string.Format(
                "Working set: {0}",
                processStatistics.WorkingSet.ToString()));
        }



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


    }

}