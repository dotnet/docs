/**
  *File name: WebBaseErrorEvent.cs
  *Purpose: Implements a custom SampleWebBaseErrorEvent type
  *by inheriting from the System.Web.Management.WebBaseErrorEvent class.
  **/

// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;

namespace SamplesAspNet
{
  // Implements a custom WebBaseErrorEvent.
    public class SampleWebBaseErrorEvent :
        System.Web.Management.WebBaseErrorEvent
    {
        private string customCreatedMsg, customRaisedMsg;

        // <Snippet2>
        // Invoked in case of events identified only by their event code.
        public SampleWebBaseErrorEvent(string msg, 
            object eventSource, int eventCode, Exception e):
          base(msg, eventSource, eventCode, e)
        {
            // Perform custom initialization.
            customCreatedMsg =
              string.Format("Event created at: {0}", 
              DateTime.Now.TimeOfDay.ToString());
        }
        // </Snippet2>


        // <Snippet3>
        // Invoked in case of events identified by their event code and 
        // related event detailed code.
        public SampleWebBaseErrorEvent(string msg, object eventSource, 
            int eventCode, int detailedCode, Exception e):
          base(msg, eventSource, eventCode, detailedCode, e)
        {
            // Perform custom initialization.
            customCreatedMsg =
              string.Format("Event created at: {0}", 
              DateTime.Now.TimeOfDay.ToString());
        }

        // </Snippet3>


        // <Snippet4>
        // Raises the SampleWebBaseErrorEvent.
        public override void Raise()
        {
            // Perform custom processing.
            customRaisedMsg =
              string.Format("Event raised at: {0}", 
              DateTime.Now.TimeOfDay.ToString());

            // Raise the event.
            base.Raise();
        }
        // </Snippet4>


        // <Snippet5>
        // Obtains the current thread information.
        public Exception GetErrorException()
        {
            return (ErrorException);
        }
        // </Snippet5>


        // <Snippet6>
        //Formats Web request event information.
        //This method is invoked indirectly by the provider using one of the
        //overloaded ToString methods.
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine(
                "** SampleWebBaseErrrorEvent Information Start **");
            formatter.AppendLine(string.Format(
                "Error message:      {0}", ErrorException.Message));
            formatter.AppendLine(string.Format(
                "Error source:       {0}", ErrorException.Source));

            // Display custom event timing.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);

            formatter.AppendLine(
                "** SampleWebBaseErrrorEvent Information End **");

            formatter.IndentationLevel -= 1;

        }
        // </Snippet6>

    }
}
// </Snippet1>

