using System;

namespace ConsoleApplication1
{
    // <snippet2>
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter();
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
            EventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
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
    public delegate void ThresholdReachedEventHandler(ThresholdReachedEventArgs e);
    //</snippet4>
}
