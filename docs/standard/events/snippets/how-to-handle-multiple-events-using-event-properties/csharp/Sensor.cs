// <EventProperties>
using System.ComponentModel;

// <SensorEventArgs>
public class SensorEventArgs(string sensorId, double value) : EventArgs
{
    public string SensorId { get; } = sensorId;
    public double Value { get; } = value;
}
// </SensorEventArgs>

// Sensor defines 10 event properties backed by a single EventHandlerList.
// EventHandlerList is memory-efficient for classes with many events: it only
// allocates storage for events that have active subscribers.
class Sensor
{
    // <EventHandlerListField>
    protected EventHandlerList listEventDelegates = new();
    // </EventHandlerListField>

    // <EventKeys>
    static readonly object temperatureChangedKey = new();
    static readonly object humidityChangedKey = new();
    static readonly object pressureChangedKey = new();
    static readonly object batteryLowKey = new();
    static readonly object signalLostKey = new();
    static readonly object signalRestoredKey = new();
    static readonly object thresholdExceededKey = new();
    static readonly object calibrationRequiredKey = new();
    static readonly object dataReceivedKey = new();
    static readonly object errorDetectedKey = new();
    // </EventKeys>

    // <SingleEventProperty>
    public event EventHandler<SensorEventArgs> TemperatureChanged
    {
        add    { listEventDelegates.AddHandler(temperatureChangedKey, value); }
        remove { listEventDelegates.RemoveHandler(temperatureChangedKey, value); }
    }
    protected virtual void OnTemperatureChanged(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[temperatureChangedKey])?.Invoke(this, e);
    // </SingleEventProperty>

    public event EventHandler<SensorEventArgs> HumidityChanged
    {
        add    { listEventDelegates.AddHandler(humidityChangedKey, value); }
        remove { listEventDelegates.RemoveHandler(humidityChangedKey, value); }
    }
    protected virtual void OnHumidityChanged(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[humidityChangedKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> PressureChanged
    {
        add    { listEventDelegates.AddHandler(pressureChangedKey, value); }
        remove { listEventDelegates.RemoveHandler(pressureChangedKey, value); }
    }
    protected virtual void OnPressureChanged(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[pressureChangedKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> BatteryLow
    {
        add    { listEventDelegates.AddHandler(batteryLowKey, value); }
        remove { listEventDelegates.RemoveHandler(batteryLowKey, value); }
    }
    protected virtual void OnBatteryLow(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[batteryLowKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> SignalLost
    {
        add    { listEventDelegates.AddHandler(signalLostKey, value); }
        remove { listEventDelegates.RemoveHandler(signalLostKey, value); }
    }
    protected virtual void OnSignalLost(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[signalLostKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> SignalRestored
    {
        add    { listEventDelegates.AddHandler(signalRestoredKey, value); }
        remove { listEventDelegates.RemoveHandler(signalRestoredKey, value); }
    }
    protected virtual void OnSignalRestored(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[signalRestoredKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> ThresholdExceeded
    {
        add    { listEventDelegates.AddHandler(thresholdExceededKey, value); }
        remove { listEventDelegates.RemoveHandler(thresholdExceededKey, value); }
    }
    protected virtual void OnThresholdExceeded(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[thresholdExceededKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> CalibrationRequired
    {
        add    { listEventDelegates.AddHandler(calibrationRequiredKey, value); }
        remove { listEventDelegates.RemoveHandler(calibrationRequiredKey, value); }
    }
    protected virtual void OnCalibrationRequired(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[calibrationRequiredKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> DataReceived
    {
        add    { listEventDelegates.AddHandler(dataReceivedKey, value); }
        remove { listEventDelegates.RemoveHandler(dataReceivedKey, value); }
    }
    protected virtual void OnDataReceived(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[dataReceivedKey])?.Invoke(this, e);

    public event EventHandler<SensorEventArgs> ErrorDetected
    {
        add    { listEventDelegates.AddHandler(errorDetectedKey, value); }
        remove { listEventDelegates.RemoveHandler(errorDetectedKey, value); }
    }
    protected virtual void OnErrorDetected(SensorEventArgs e) =>
        ((EventHandler<SensorEventArgs>?)listEventDelegates[errorDetectedKey])?.Invoke(this, e);
}
// </EventProperties>
