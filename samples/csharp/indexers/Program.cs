using System;
using System.Linq;

using IndexersSamples.Common;
using IndexersSamples.SampleOne;
using IndexersSamples.SampleTwo;
using IndexersSamples.SampleThree;
using IndexersSamples.SampleFour;

namespace IndexersSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SampleOne();
            SampleTwo(args);
            SampleThree();
            SampleFour();
        }
        
        private static void SampleOne()
        {
            // Create a store:
            var store = new DataSamples(500000);

            // Access:
            var measure = store[3];
            Console.WriteLine(measure.HiTemp);

            // Update:
            store[80] = measure;
            Console.WriteLine(store[80].HiTemp);

            // Load a new page:
            var measure2 = store[2020];
            Console.WriteLine(measure2.LoTemp);

            // Load another new page:
            store[3547] = measure2;
            Console.WriteLine(store[3547].LoTemp);

            // Make sure pages rotate in and out of memory:
            for (int j = 5; j < 500000; j += 1100)
            {
                var item = store[j];
                Console.WriteLine(item.AirPressure);
            }

            // Check for valid arguments:
            try
            {
                var item = store[2000000];
                Console.WriteLine("Didn't check bounds");
            }
            catch (IndexOutOfRangeException)
            {
                // empty catch block. Above code should fail.
            }
        }

        private static void SampleTwo(string[] args)
        {
            var argThings = new ArgsActions();
            argThings.SetOption("-a", () => Console.WriteLine("-a option selected"));
            argThings.SetOption("-e", () => Console.WriteLine("-e option selected"));

            var processor = new ArgsProcessor(argThings);
            processor.Process(args);
        }

        private static void SampleThree()
        {
            var generator = new Mandelbrot(256);
            var item = generator[0, 0];
            Console.WriteLine(item);
            item = generator[5, 5];
            Console.WriteLine(item);
            item = generator[0.30, 0.0001];
            Console.WriteLine(item);
        }
        
        private static void SampleFour()
        {
            var data = new HistoricalWeatherData();

            data["Chicago", new DateTime(1970, 6, 6)] = new Measurements
            {
                HiTemp = 75,
                LoTemp = 58,
                AirPressure = 30.2
            };

            var item = data["Chicago", new DateTime(1970, 6, 6)];
            Console.WriteLine(item.HiTemp);
            item = data["Chicago", new DateTime(1970, 6, 6, 12, 30, 2)];
            Console.WriteLine(item.LoTemp);

            data["Chicago", new DateTime(1970, 6, 6)] = new Measurements
            {
                HiTemp = 85,
                LoTemp = 38,
                AirPressure = 30.2
            };

            item = data["Chicago", new DateTime(1970, 6, 6)];
            Console.WriteLine(item.HiTemp);
            item = data["Chicago", new DateTime(1970, 6, 6, 12, 30, 2)];
            Console.WriteLine(item.LoTemp);

            try
            {
                item = data["New York", new DateTime(1980, 5, 12)];
                Console.WriteLine("Didn't get expected exception");
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            try
            {
                item = data["Chicago", new DateTime(1980, 5, 12)];
                Console.WriteLine("Didn't get expected exception");
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
    }
}
