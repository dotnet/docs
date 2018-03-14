    interface ISampleInterface
    {
        void SampleMethod();
    }

    class ImplementationClass : ISampleInterface
    {
        // Explicit interface member implementation: 
        void ISampleInterface.SampleMethod()
        {
            // Method implementation.
        }

        static void Main()
        {
            // Declare an interface instance.
            ISampleInterface obj = new ImplementationClass();

            // Call the member.
            obj.SampleMethod();
        }
    }