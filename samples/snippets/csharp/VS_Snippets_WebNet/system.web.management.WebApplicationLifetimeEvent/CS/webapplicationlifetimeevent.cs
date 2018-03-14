/**
  *File name: WebApplicationLifeTimeEvent.cs
  *Purpose: Implements a custom WebApplicationLifeTimeEvent type
  **/
  
// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
  // Implements a custom WebManagementEvent class. 
    public class SampleWebApplicationLifetimeEvent :
        System.Web.Management.WebApplicationLifetimeEvent
    {
        private string customCreatedMsg, customRaisedMsg;

        // <Snippet2>
        // Invoked in case of events identified only by 
        // their event code.
        public SampleWebApplicationLifetimeEvent(string msg, 
            object eventSource, int eventCode):
          base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
            string.Format("Event created at: {0}",
            DateTime.Now.TimeOfDay.ToString());
        }
        // </Snippet2>


        // <Snippet3>
        // Invoked in case of events identified by their 
        // event code.and related event detailed code.
        public SampleWebApplicationLifetimeEvent(string msg, 
            object eventSource, int eventCode, 
            int eventDetailCode):
          base(msg, eventSource, eventCode, eventDetailCode)
        {
            // Perform custom initialization.
            customCreatedMsg =
             string.Format("Event created at: {0}",
             DateTime.Now.TimeOfDay.ToString());
        }

        // </Snippet3>

        // <Snippet4>
        // Raises the SampleWebRequestEvent.
        public override void Raise()
        {
            // Perform custom processing. 
            customRaisedMsg = string.Format(
                "Event raised at: {0}\n", 
                DateTime.Now.TimeOfDay.ToString());
            // Raise the event.
            base.Raise();
        }
        // </Snippet4>

        // <Snippet5>
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
                 "*SampleWebApplicationLifetimeEvent Start *");
            formatter.AppendLine("Custom information goes here");
            formatter.AppendLine(
                "* SampleWebApplicationLifetimeEvent End *");
            // Display custom event timing.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);
        
            formatter.IndentationLevel -= 1;

        }
        // </Snippet5>
    }

}
// </Snippet1>

