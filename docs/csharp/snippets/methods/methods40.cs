//<Snippet40>
namespace MotorCycleExample
{
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
            public override double GetTopSpeed() => 108.4;

            static void Main()
            {
                var moto = new TestMotorcycle();

                moto.StartEngine();
                moto.AddGas(15);
                _ = moto.Drive(5, 20);
                double speed = moto.GetTopSpeed();
                Console.WriteLine($"My top speed is {speed}");
            }
        }
        //</Snippet41>
    }
}
