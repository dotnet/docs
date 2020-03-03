using System;

namespace SystemDateTimeReference
{
    public static class Resolution
    {
        public static void Snippets()
        {
            DemonstrateResolution();
        }

        private static void DemonstrateResolution()
        {
            // <Snippet1>
            string output = "";
            for (int ctr = 0; ctr <= 20; ctr++)
            {
                output += String.Format($"{DateTime.Now.Millisecond}\n");
                // Introduce a delay loop.
                for (int delay = 0; delay <= 1000; delay++)
                { }

                if (ctr == 10)
                {
                    output += "Thread.Sleep called...\n";
                    System.Threading.Thread.Sleep(5);
                }
            }
            Console.WriteLine(output);
            // Press "Run" to see the output.
            // </Snippet1>
        }
    }
}
