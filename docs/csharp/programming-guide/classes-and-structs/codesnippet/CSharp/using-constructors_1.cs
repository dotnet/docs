    public class Taxi
    {
        public bool isInitialized;
        public Taxi()
        {
            isInitialized = true;
        }
    }

    class TestTaxi
    {
        static void Main()
        {
            Taxi t = new Taxi();
            Console.WriteLine(t.isInitialized);
        }
    }