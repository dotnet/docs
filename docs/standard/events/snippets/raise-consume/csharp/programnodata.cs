namespace ConsoleApplication1
{
    // <snippet5>
    class ProgramOne
    {
        static void Main()
        {
            Counter c = new(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object? sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
            Environment.Exit(0);
        }
    }

    class Counter(int passedThreshold)
    {
        private readonly int _threshold = passedThreshold;
        private int _total;

        public void Add(int x)
        {
            _total += x;
            if (_total >= _threshold)
            {
                ThresholdReached?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? ThresholdReached;
    }
    // </snippet5>
}
