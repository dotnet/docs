using System.Collections.Generic;
using System.Linq;

namespace InterimSteps
{
    // <DailyRecord>
    public readonly record struct DailyTemperature(double HighTemp, double LowTemp);
    // </DailyRecord>

}

namespace InterimSteps2
{
    public readonly record struct DailyTemperature(double HighTemp, double LowTemp)
    {
        public double Mean => (HighTemp + LowTemp) / 2.0;
    }

    // <DegreeDaysRecords>
    public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords);

    public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        : DegreeDays(BaseTemperature, TempRecords)
    {
        public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
    }

    public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        : DegreeDays(BaseTemperature, TempRecords)
    {
        public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
    }
    // </DegreeDaysRecords>
}
