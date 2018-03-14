//<snippet1>
using System;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Samples.AspNet.Management
{

    public class CustomWebEvents : Page, IHttpModule
    {

        public override void Dispose()
        {
        }

        // Add event handlers to the HttpApplication.
        public new void Init(HttpApplication httpApp)
        {
            httpApp.BeginRequest +=
                new EventHandler(OnBeginRequest);

            httpApp.EndRequest +=
                new EventHandler(OnEndRequest);

        }

        // Issues a custom begin request event.
        public void OnBeginRequest(Object sender, EventArgs e)
        {

            HttpApplication httpApp = sender as HttpApplication;

            try
            {
                // Make sure to be outside the forbidden range.
                System.Int32 myCode = WebEventCodes.WebExtendedBase + 30;
                SampleWebRequestEvent swre =
                  new SampleWebRequestEvent(
                  "SampleWebRequestEvent Start", this, myCode);
                // Raise the event.
                swre.Raise();
            }
            catch (Exception ex)
            {
                httpApp.Context.Response.Output.WriteLine(
                    ex.ToString());
            }

        }

        // Issues a custom end request event.
        public void OnEndRequest(Object sender, EventArgs e)
        {
            HttpApplication httpApp = sender as HttpApplication;

            try
            {
                // Make sure to be outside the forbidden range.
                System.Int32 myCode = WebEventCodes.WebExtendedBase + 40;
                SampleWebRequestEvent swre =
                  new SampleWebRequestEvent(
                  "SampleWebRequestEvent End", this, myCode);
                // Raise the event.
                swre.Raise();
            }
            catch (Exception ex)
            {
                httpApp.Context.Response.Output.WriteLine(
                    ex.ToString());
            }

        }
    }
    public class SampleWebRequestEvent : System.Web.Management.WebRequestEvent
    {
        private string customCreatedMsg;
        private string customRaisedMsg;

        // Invoked in case of events identified only by their event code.
        public SampleWebRequestEvent(
            string msg,
            object eventSource,
            int eventCode)
            :
            base(msg, eventSource, eventCode)
        {
            // Perform custom initialization.
            customCreatedMsg = string.Format("Event created at: {0}",
                EventTime.ToString());
        }

        // Invoked in case of events identified by their event code and 
        // related event detailed code.
        public SampleWebRequestEvent(
            string msg,
            object eventSource,
            int eventCode,
            int eventDetailCode)
            :
            base(msg, eventSource, eventCode, eventDetailCode)
        {
            // Perform custom initialization.
            customCreatedMsg = string.Format("Event created at: {0}",
                EventTime.ToString());

        }

        // Raises the SampleWebRequestEvent.
        public override void Raise()
        {
            // Perform custom processing.
            customRaisedMsg = string.Format("Event raised at: {0}",
                EventTime.ToString());

            // Raise the event.
            base.Raise();
        }

        //Formats Web request event information.
        public override void FormatCustomEventDetails(
            WebEventFormatter formatter)
        {
            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine("* Custom Request Information Start *");

            // Display custom event timing.
            formatter.AppendLine(customCreatedMsg);
            formatter.AppendLine(customRaisedMsg);

            formatter.AppendLine("* Custom Request Information End *");

            formatter.IndentationLevel -= 1;
        }
    }
}
//</snippet1>