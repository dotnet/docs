using TemperatureSample;

TemperatureMonitor provider = new();
TemperatureReporter observer1 = new();
TemperatureReporter observer2 = new();

observer1.Subscribe(provider);
observer2.Subscribe(provider);

await provider.GetTemperatureAsync();
