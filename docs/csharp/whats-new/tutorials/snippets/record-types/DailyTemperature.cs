namespace record_types
{
    // <TemperatureRecord>
    public record DailyTemperature(double HighTemp, double LowTemp)
    {
        public double Mean => (HighTemp + LowTemp) / 2.0;
    }
    // </TemperatureRecord>
}
