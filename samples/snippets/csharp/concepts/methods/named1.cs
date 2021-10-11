namespace NamedMotorCycle
{
    // <Snippet45>
    using System;

    class TestMotorcycle : Motorcycle
    {
        public override int Drive(int miles, int speed)
        {
            return (int)Math.Round(((double)miles) / speed, 0);
        }

        public override double GetTopSpeed()
        {
            return 108.4;
        }

        static void Main()
        {

            TestMotorcycle moto = new TestMotorcycle();
            moto.StartEngine();
            moto.AddGas(15);
            var travelTime = moto.Drive(speed: 60, miles: 170);
            Console.WriteLine("Travel time: approx. {0} hours", travelTime);
        }
    }
    // The example displays the following output:
    //      Travel time: approx. 3 hours
    // </Snippet45>

    abstract class Motorcycle
    {
        // Anyone can call this.
        public void StartEngine() {/* Method statements here */ }

        // Only derived classes can call this.
        protected void AddGas(int gallons) { /* Method statements here */ }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes can override the base class implementation.
        public virtual int Drive(TimeSpan time, int speed) { /* Method statements here */ return 0; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }
}
