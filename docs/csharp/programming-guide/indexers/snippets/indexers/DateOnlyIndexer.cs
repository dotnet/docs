using System;
using System.Collections.Generic;

namespace Indexers;

public class DailyTemperatureData
{
    private readonly Dictionary<DateOnly, (double High, double Low)> _temperatureData = new();

    // Indexer using DateOnly for date-only scenarios
    public (double High, double Low) this[DateOnly date]
    {
        get
        {
            if (_temperatureData.TryGetValue(date, out var temp))
            {
                return temp;
            }
            throw new KeyNotFoundException($"No temperature data available for {date:yyyy-MM-dd}");
        }
        set
        {
            _temperatureData[date] = value;
        }
    }

    // Overload using DateTime for convenience, but only uses the date part
    public (double High, double Low) this[DateTime dateTime]
    {
        get => this[DateOnly.FromDateTime(dateTime)];
        set => this[DateOnly.FromDateTime(dateTime)] = value;
    }

    public bool HasDataFor(DateOnly date) => _temperatureData.ContainsKey(date);

    public IEnumerable<DateOnly> AvailableDates => _temperatureData.Keys;
}