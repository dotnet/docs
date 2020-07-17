using System;

// Code section for remarks
namespace EventRemarks
{
    public class AlarmEventArgs : EventArgs
    {
    }
    // <Snippet2>
    public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);
    // </Snippet2>

    public class AlarmClock
    {
        public event AlarmEventHandler Alarm;

        protected virtual void OnAlarm(AlarmEventArgs e)
        {
            AlarmEventHandler handler = Alarm;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    // <Snippet4>
    delegate void EventHandler(object sender, EventArgs e);
    // </Snippet4>
    // <Snippet3>
    public class WakeMeUp
    {
        // AlarmRang has the same signature as AlarmEventHandler.
        public void AlarmRang(object sender, AlarmEventArgs e)
        {
            //...
        }
        //...
    }
    // </Snippet3>

    public class AlarmDriver
    {
        public static void Main()
        {
            // <Snippet5>
            // Create an instance of WakeMeUp.
            WakeMeUp w = new WakeMeUp();

            // Instantiate the event delegate.
            AlarmEventHandler alhandler = new AlarmEventHandler(w.AlarmRang);
            // </Snippet5>

            // <Snippet6>
            // Instantiate the event source.
            AlarmClock clock = new AlarmClock();

            // Add the delegate instance to the event.
            clock.Alarm += alhandler;
            // </Snippet6>
        }
    }
}
