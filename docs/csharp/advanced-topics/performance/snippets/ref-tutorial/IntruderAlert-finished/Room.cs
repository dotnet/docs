namespace IntruderAlert;

public enum IntruderRisk
{
    None,
    Low,
    Medium,
    High,
    Extreme
}

public class Room
{
    // <AverageMeasurement>
    private AverageMeasurement average = new();
    public  ref readonly AverageMeasurement Average { get { return ref average; } }
    // </AverageMeasurement>
    
    // <DebounceAsReference>
    private DebounceMeasurement debounce = new();
    public ref readonly DebounceMeasurement Debounce { get { return ref debounce; } }
    // </DebounceAsReference>

    public string Name { get; }

    private IntruderRisk risk;
    public ref readonly IntruderRisk RiskStatus => ref risk;

    public int Intruders { get; set; }
    public Room(string name)
    {
        Name = name;
    }

    public void TakeMeasurements(Func<bool> MeasurementHandler)
    {
        SensorMeasurement measure = default;
        do {
            measure = SensorMeasurement.TakeMeasurement(Name, Intruders);
            average.AddMeasurement(measure);
            debounce.AddMeasurement(measure);
            var CO2Variance = (debounce.CO2 - average.CO2) > 10.0 / 4;
            var O2Variance = (average.O2 - debounce.O2) > 0.005 / 4.0;
            var TempVariance = (debounce.Temperature - average.Temperature) > 0.05 / 4.0;
            var HumidityVariance = (debounce.Humidity - average.Humidity) > 0.20 / 4;
            risk = IntruderRisk.None;
            if (CO2Variance) { risk++; }
            if (O2Variance) { risk++; }
            if (TempVariance) { risk++; }
            if (HumidityVariance) { risk++; }
        } while (MeasurementHandler());
    }

    // <RoomToString>
    public override string ToString() =>
        $"Calculated intruder risk: {RiskStatus switch
        {
            IntruderRisk.None => "None",
            IntruderRisk.Low => "Low",
            IntruderRisk.Medium => "Medium",
            IntruderRisk.High => "High",
            IntruderRisk.Extreme => "Extreme",
            _ => "Error!"
        }}, Current intruders: {Intruders.ToString()}";
    // </RoomToString>
}
