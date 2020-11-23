using System;
using System.Collections.Generic;

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

            // <RunningFiveDayTotal>
            // showing moving accumulation of 5 days using range syntax
            List<CoolingDegreeDays> movingAccumulation = new();
            int rangeSize = (data.Length > 5) ? 5 : data.Length;
            for (int start = 0; start < data.Length - rangeSize; start++)
            {
                var fiveDayTotal = growingDegreeDays with { TempRecords = data[start..(start + rangeSize)] };
                movingAccumulation.Add(fiveDayTotal);
            }
            Console.WriteLine();
            Console.WriteLine("Total degree days in the last five days");
            foreach(var item in movingAccumulation)
            {
                Console.WriteLine(item);
            }
            // </RunningFiveDayTotal>
        }
    }
}
