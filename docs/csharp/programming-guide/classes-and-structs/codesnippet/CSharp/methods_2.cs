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