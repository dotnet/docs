
    public class SampleEventArgs
    {
        public SampleEventArgs(string s) { Text = s; }
        public String Text {get; private set;} // readonly
    }
    public class Publisher
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        // Declare the event.
        public event SampleEventHandler SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
    protected virtual void RaiseSampleEvent()
    {
        //Create a temporary reference to guard against a race condition
        //in case the last subscriber unsubscribes causing SampleEvent to become null
        SampleEventHandler handler = SampleEvent;
        // Raise the event by using the () operator.
        if (handler != null)
            SampleEvent(this, new SampleEventArgs("Hello"));
    }
