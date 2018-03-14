/**
  *File name: WebBaseEventCollection.cs
  *Purpose:   This little contrived example shows how to use the 
  *           WebBaseEventCollection. 
  **/
  
// <Snippet1>

using System;
using System.Text;
using System.Web;
using System.Web.Management;
using System.Collections;

namespace SamplesAspNet
{
    // Implements a custom WebBaseEvent class. 
    // Everytime this class is instantiated a WebBaseEvent is 
    // created. This event object is then added to the static 
    // simulatedEvents array list.
    public class SampleWebBaseEventCollection : System.Web.Management.WebBaseEvent
    {
        private string customCreatedMsg;

        private static ArrayList simulatedEvents = new ArrayList();
        private static System.Web.Management.WebBaseEventCollection events;

        // Create a new WebBaseEvent and add it to the 
        // static array list simulatedEvents.
        public SampleWebBaseEventCollection(
        string msg, object eventSource, int eventCode):
        base(msg, eventSource, eventCode)
        {

            customCreatedMsg =
              string.Format("Event created at: {0}", 
              DateTime.Now.TimeOfDay.ToString());

            simulatedEvents.Add(this);

        }

        // <Snippet3>
        // Get the event with the specified index.
        public static WebBaseEvent GetItem(int index)
        {
            return events[index];
        }
        // </Snippet3>

        // <Snippet4>
        // Get the index of the specified event.
        public static int GetIndexOf(WebBaseEvent ev)
        {
            return events.IndexOf(ev);
        }
        // </Snippet4>

        // <Snippet5>
        // Check if the specified event is in the collection.
        public static bool ContainsEvent(WebBaseEvent ev)
        {
            return events.Contains(ev);
        }
        // </Snippet5>

        // <Snippet2>

        // Create an event collection.
        // Add to it the created simulatedEvents.
        public static void AddEvents()
        {
            events = 
            new System.Web.Management.WebBaseEventCollection(
            simulatedEvents);
        }

        // </Snippet2>

        // Display the events contained in the collection.
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);
            // Add custom data.
            formatter.AppendLine("");

            formatter.IndentationLevel += 1;
            formatter.AppendLine(
                "**SampleWebBaseEventCollection Data Start **");
            foreach (WebBaseEvent ev in events)
            {
                formatter.AppendLine(string.Format(
                    "Message:   {0}", ev.Message));
                formatter.AppendLine(string.Format(
                    "Source:    {0}", ev.EventSource.ToString()));
                formatter.AppendLine(string.Format(
                    "Code:      {0}", ev.EventCode.ToString()));
            }

            formatter.AppendLine(
                "**SampleWebBaseEventCollection Data End **");

            formatter.IndentationLevel -= 1;

        }

    }
}
// </Snippet1>

