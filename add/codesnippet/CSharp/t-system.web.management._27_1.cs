
using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
  // Implements a custom WebBaseEvent class. 
    public class SampleWebBaseEvent :
        System.Web.Management.WebBaseEvent, IWebEventCustomEvaluator
    {
        private string customCreatedMsg, customRaisedMsg;

        // Store firing record info.
        private static string firingRecordInfo;


        // Implements the IWebEventCustomEvaluator.CanFire 
        // method. It is called by the ASP.NET if this custom
        // type is configured in the profile
        // element of the healthMonitoring section.
        public bool CanFire(
            System.Web.Management.WebBaseEvent e, 
            RuleFiringRecord rule)
        {

            bool fireEvent;
            string lastFired = rule.LastFired.ToString();
            string timesRaised = rule.TimesRaised.ToString();

            // Fire every other event raised.
            fireEvent =
                (rule.TimesRaised % 2 == 0) ? true : false;

            if (fireEvent)
            {
                firingRecordInfo =
                    string.Format("Event last fired: {0}",
                    lastFired) +
                    string.Format(". Times raised: {0}",
                    timesRaised);
            }
            else
                firingRecordInfo =
                  string.Format(
                   "Event not fired. Times raised: {0}",
                   timesRaised);

            return fireEvent;

        }


        // Invoked in case of events identified only by 
        // their event code.
        public SampleWebBaseEvent(string msg, 
            object eventSource, int eventCode):
          base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
            string.Format("Event created at: {0}",
            EventTime.ToString());
        }


        // Invoked in case of events identified by their 
        // event code.and related event detailed code.
        public SampleWebBaseEvent(string msg, object eventSource, 
            int eventCode, int eventDetailCode):
          base(msg, eventSource, eventCode, eventDetailCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
             string.Format("Event created at: {0}",
             EventTime.ToString());
        }


        // Raises the SampleWebBaseEvent.
        public override void Raise()
        {
            // Perform custom processing. 
            customRaisedMsg =
              string.Format("Event raised at: {0}",
              EventTime.ToString());

            // Raise the event.
            base.Raise();
        }


        // Raises the SampleWebBaseEvent.
        public void CustomRaise(
            System.Web.Management.WebBaseEvent evnt)
        {
            
            // Raise the event.
            Raise(evnt);
        }


        // Gets the event code.
        public int GetEventCode(bool detail)
        {
            int eCode;

            if (!detail)
                // Get the event code.
                eCode = EventCode;

            else
                // Get the detail event code.
                eCode = EventDetailCode;

            return eCode;

        }

        // Gets the event sequence.
        public long GetEventSequence()
        {
            // Get the event sequence.
            long eventSequence = EventSequence;
            return eventSequence;
        }



        // Gets the event source.
        public Object GetEventSource()
        {
            // Get the event source.
            Object source = this.EventSource;
            return source;
        }

        // Gets the event time.
        public DateTime GetEventTime()
        {
            // Get the event source.
            DateTime eTime = EventTime;
            return eTime;
        }

        // Gets the event time.
        public DateTime GetEventTimeUtc()
        {
            // Get the event source.
            DateTime eTime = EventTimeUtc;
            return eTime;
        }

        // Gets the event sequence.
        public string GetEventMessage()
        {
            // Get the event message.
            string eventMsg = Message;
            return eventMsg;
        }

        // Gets the current application information.
        public WebApplicationInformation GetEventAppInfo()
        {
            // Get the event message.
            WebApplicationInformation appImfo = 
                ApplicationInformation;
            return appImfo;
        }

        // Implements the ToString() method.
        public override string ToString()
        {
            return base.ToString();
        }

        // Implements the ToString(bool, bool) method.
        public string customToString(bool includeAppInfo, 
            bool includeCustomInfo)
        {
            return (
                base.ToString(includeAppInfo, 
                includeCustomInfo));
        }

        // Gets the event identifier.
        public Guid GetEventId()
        {
            Guid evId =  EventID;
            return evId;
        }

        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;

            formatter.TabSize = 4;

            formatter.AppendLine(
                 "*SampleWebBaseEvent Start *");

            // Display custom event information.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);
            formatter.AppendLine(firingRecordInfo);

            formatter.AppendLine(
          "* SampleWebBaseEvent End *");


            formatter.IndentationLevel -= 1;

        }
            
    }

}