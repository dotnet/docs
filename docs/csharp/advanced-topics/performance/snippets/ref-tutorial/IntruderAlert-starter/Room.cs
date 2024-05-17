namespace IntruderAlert;

public enum IntruderRisk
{
    None,
    Low,
    Medium,
    High,
    Extreme
}

// <RoomClass>
public class Room
{
    public AverageMeasurement Average { get; } = new ();
    public DebounceMeasurement Debounce { get; } = new ();
    public string Name { get; }

    public IntruderRisk RiskStatus
    {
        get
        {
            var CO2Variance = (Debounce.CO2 - Average.CO2) > 10.0 / 4;
            var O2Variance = (Average.O2 - Debounce.O2) > 0.005 / 4.0;
            var TempVariance = (Debounce.Temperature - Average.Temperature) > 0.05 / 4.0;
            var HumidityVariance = (Debounce.Humidity - Average.Humidity) > 0.20 / 4;
            IntruderRisk risk = IntruderRisk.None;
            if (CO2Variance) { risk++; }
            if (O2Variance) { risk++; }
            if (TempVariance) { risk++; }
            if (HumidityVariance) { risk++; }
            return risk;
        }
    }

    public int Intruders { get; set; }

    
    public Room(string name)
    {
        Name = name;
    }

    // <InitialTakeMeasurement>
    public void TakeMeasurements(Func<SensorMeasurement, bool> MeasurementHandler)
    {
        SensorMeasurement? measure = default;
        do {
            measure = SensorMeasurement.TakeMeasurement(Name, Intruders);
            Average.AddMeasurement(measure);
            Debounce.AddMeasurement(measure);
        } while (MeasurementHandler(measure));
    }
    // </InitialTakeMeasurement>
}
// </RoomClass>