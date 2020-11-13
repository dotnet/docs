using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace record_types
{
    class Program
    {
        // <DeclareData>
        private static DailyTemperature[] data = new DailyTemperature[]
        {
            new DailyTemperature(HighTemp: 57, LowTemp: 30), 
            new DailyTemperature(60, 35),
            new DailyTemperature(63, 33),
            new DailyTemperature(68, 29),
            new DailyTemperature(72, 47),
            new DailyTemperature(75, 55),
            new DailyTemperature(77, 55),
            new DailyTemperature(72, 58),
            new DailyTemperature(70, 47),
            new DailyTemperature(77, 59),
            new DailyTemperature(85, 65),
            new DailyTemperature(87, 65),
            new DailyTemperature(85, 72),
            new DailyTemperature(83, 68),
            new DailyTemperature(77, 65),
            new DailyTemperature(72, 58),
            new DailyTemperature(77, 55),
            new DailyTemperature(76, 53),
            new DailyTemperature(80, 60),
            new DailyTemperature(85, 66) 
        };
        // </DeclareData>

        static void Main(string[] args)
        {
            // <HeatingAndCooling>
            var heatingDegreeDays = new HeatingDegreeDays(65, data);
            Console.WriteLine(heatingDegreeDays);

            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            Console.WriteLine(coolingDegreeDays);
            // </HeatingAndCooling>

            // <GrowingDegreeDays>
            // Growing degree days measure warming to determine plant growing rates
            var growingDegreeDays = coolingDegreeDays with { BaseTemperature = 41 };
            Console.WriteLine(growingDegreeDays);
            // </GrowingDegreeDays>

            // <RunningFiveDayAverage>
            // showing moving average of 5 days using range syntax
            List<CoolingDegreeDays> movingAverage = new();
            for (int start = 0; start < data.Length - 5; start++)
            {
                var fiveDayAverage = growingDegreeDays with { TempRecords = data[start..(start + 5)] };
                movingAverage.Add(fiveDayAverage);
            }
            Console.WriteLine();
            Console.WriteLine("Moving averages");
            foreach(var item in movingAverage)
            {
                Console.WriteLine(item);
            }
            // </RunningFiveDayAverage>
        }
    }
}
