Sensor sensor = new Sensor();
// <SubscribeEvent>
sensor.TemperatureChanged += Sensor_TemperatureChanged;
// </SubscribeEvent>

// <HandleEvent>
static void Sensor_TemperatureChanged(object? sender, SensorEventArgs e) =>
    Console.WriteLine($"Sensor {e.SensorId}: temperature changed to {e.Value}.");
// </HandleEvent>

