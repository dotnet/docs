
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
    protected virtual void OnRaiseSampleEvent()
    {
        // Raise the event by using the () operator.
        SampleEvent?.Invoke(this, new SampleEventArgs("Hello"));
    }
