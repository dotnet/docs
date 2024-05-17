namespace IntruderAlert;

public class AverageMeasurement
{
    private double sumCO2;
    private double sumO2;
    private double sumTemperature;
    private double sumHumidity;
    private int totalMeasurements;

    public double CO2 => sumCO2 / totalMeasurements;
    public double O2 => sumO2 / totalMeasurements;
    public double Temperature => sumTemperature / totalMeasurements;
    public double Humidity => sumHumidity / totalMeasurements;

    public void AddMeasurement(SensorMeasurement datum)
    {
        totalMeasurements++;
        sumCO2 += datum.CO2;
        sumO2 += datum.O2;
        sumTemperature += datum.Temperature;
        sumHumidity+= datum.Humidity;

    }

    public override string ToString() => $"""
        Average measurements:
            Temp:      {Temperature:F3}
            Humidity:  {Humidity:P3}
            Oxygen:    {O2:P3}
            CO2 (ppm): {CO2:F3}
        """;
}
