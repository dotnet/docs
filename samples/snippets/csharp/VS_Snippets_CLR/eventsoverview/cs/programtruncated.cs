using System;

namespace ConsoleApplication2
{
    // <snippet2>
    class ProgramTwo
    {
        static void Main()
        {
            var c = new Counter();
            c.ThresholdReached += c_ThresholdReached;

            // provide remaining implementation for the class
        }

        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
        }
    }
    // </snippet2>

    // <snippet1>
    class Counter
    {
        public event EventHandler ThresholdReached;

        protected virtual void OnThresholdReached(EventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }

        // provide remaining implementation for the class
    }
    // </snippet1>

    // <snippet3>
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
    // </snippet3>

    //<snippet4>
    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);
    //</snippet4>
}
