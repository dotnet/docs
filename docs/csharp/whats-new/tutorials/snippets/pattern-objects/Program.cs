using System;

namespace pattern_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            // <HappyTests>
            // Create a new canal lock:
            var canalGate = new CanalLock();

            // State should be doors closed, water level low:
            Console.WriteLine(canalGate);

            canalGate.SetLowGate(open: true);
            Console.WriteLine($"Open the lower gate:  {canalGate}");

            Console.WriteLine("Boat enters lock from lower gate");

            canalGate.SetLowGate(open: false);
            Console.WriteLine($"Close the lower gate:  {canalGate}");

            canalGate.SetWaterLevel(WaterLevel.High);
            Console.WriteLine($"Raise the water level: {canalGate}");
            Console.WriteLine(canalGate);

            canalGate.SetHighGate(open: true);
            Console.WriteLine($"Open the higher gate:  {canalGate}");

            Console.WriteLine("Boat exits lock at upper gate");
            Console.WriteLine("Boat enters lock from upper gate");

            canalGate.SetHighGate(open: false);
            Console.WriteLine($"Close the higher gate: {canalGate}");

            canalGate.SetWaterLevel(WaterLevel.Low);
            Console.WriteLine($"Lower the water level: {canalGate}");

            canalGate.SetLowGate(open: true);
            Console.WriteLine($"Open the lower gate:  {canalGate}");

            Console.WriteLine("Boat exits lock at upper gate");

            canalGate.SetLowGate(open: false);
            Console.WriteLine($"Close the lower gate:  {canalGate}");
            // </HappyTests>

            // Failure tests:
            // <HighGateSafetyTest>
            Console.WriteLine("=============================================");
            Console.WriteLine("     Test invalid commands");
            // Open "wrong" gate (2 tests)
            try
            {
                canalGate = new CanalLock();
                canalGate.SetHighGate(open: true);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation: Can't open the high gate. Water is low.");
            }
            Console.WriteLine($"Try to open upper gate: {canalGate}");
            // </HighGateSafetyTest>
            // <FinalTestCode>
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                canalGate = new CanalLock();
                canalGate.SetWaterLevel(WaterLevel.High);
                canalGate.SetLowGate(open: true);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("invalid operation: Can't open the lower gate. Water is high.");
            }
            Console.WriteLine($"Try to open lower gate: {canalGate}");
            // change water level with gate open (2 tests)
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                canalGate = new CanalLock();
                canalGate.SetLowGate(open: true);
                canalGate.SetWaterLevel(WaterLevel.High);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("invalid operation: Can't raise water when the lower gate is open.");
            }
            Console.WriteLine($"Try to raise water with lower gate open: {canalGate}");
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                canalGate = new CanalLock();
                canalGate.SetWaterLevel(WaterLevel.High);
                canalGate.SetHighGate(open: true);
                canalGate.SetWaterLevel(WaterLevel.Low);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("invalid operation: Can't lower water when the high gate is open.");
            }
            Console.WriteLine($"Try to lower water with high gate open: {canalGate}");
            // </FinalTestCode>
        }
    }
}
