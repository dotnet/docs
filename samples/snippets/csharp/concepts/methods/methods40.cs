namespace MotorCycleExample
{
    //<Snippet40>
    using System;

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
    //</Snippet40>

    namespace Invocation
    {
        //<Snippet41>
        class TestMotorcycle : Motorcycle
        {
            public override double GetTopSpeed()
            {
                return 108.4;
            }

            static void Main()
            {

                TestMotorcycle moto = new TestMotorcycle();

                moto.StartEngine();
                moto.AddGas(15);
                moto.Drive(5, 20);
                double speed = moto.GetTopSpeed();
                Console.WriteLine("My top speed is {0}", speed);
            }
        }
        //</Snippet41>
    }
}
