using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
   static void Main(string[] args)
   {
      TemperatureMonitor provider = new TemperatureMonitor();
      TemperatureReporter observer1 = new TemperatureReporter();
      observer1.Subscribe(provider);
      TemperatureReporter observer2 = new TemperatureReporter();
      observer2.Subscribe(provider);
      provider.GetTemperature();
   }
}
