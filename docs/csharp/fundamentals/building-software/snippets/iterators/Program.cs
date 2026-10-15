// <IteratorMethod>
int[] readings = [21, 27, 24, -1, 19];

IEnumerable<int> acceptedReadings =
    SelectTemperatures(readings, maximum: 25);

Console.WriteLine("Sequence created.");

foreach (int temperature in acceptedReadings)
{
    Console.WriteLine($"Accepted: {temperature}°C");
}

static IEnumerable<int> SelectTemperatures(
    IEnumerable<int> readings,
    int maximum)
{
    foreach (int reading in readings)
    {
        Console.WriteLine($"Checking {reading}°C");

        if (reading == -1)
        {
            yield break;
        }

        if (reading <= maximum)
        {
            yield return reading;
        }
    }
}
// </IteratorMethod>
