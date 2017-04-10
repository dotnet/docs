using System;

namespace guids
{
    class Program
    {
        // <Snippet1>
        static void Main(string[] args)
        {
            Guid GStart = Guid.NewGuid();
            string guidB = GStart.ToString("B");

            Guid GCurrent = Guid.Parse(guidB);
            string guidX = GCurrent.ToString("X");

            if (Guid.TryParse(guidX, out GCurrent))
                Console.WriteLine(GCurrent.ToString("X"));
            else
                Console.WriteLine("Last parse operation unsuccessful.");

            if (Guid.TryParseExact(guidX, "X", out GCurrent))
                Console.WriteLine(GCurrent.ToString("X"));
            else
                Console.WriteLine("Last parse operation unsuccessful.");
        }
        // </Snippet1>
    }
}
