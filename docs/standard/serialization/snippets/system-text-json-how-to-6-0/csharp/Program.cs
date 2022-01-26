namespace SystemTextJsonSamples
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("\n============================= Round trip to JsonElementAndNode\n");
            RoundtripJsonElementAndNode.Program.Main();
            Console.WriteLine("\n============================= Serialize and IgnoreCycles\n");
            SerializeIgnoreCycles.Program.Main();
            Console.WriteLine("\n============================= Callbacks / Notifications\n");
            Callbacks.Program.Main();
            Console.WriteLine("\n============================= Set property order\n");
            PropertyOrder.Program.Main();
        }
    }
}
