using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mixins_with_interfaces
{
    // <SnippetLEDLight>
    public class LEDLight : IBlinkingLight, ITimerLight, ILight
    {
        private bool isOn;
        public void SwitchOn() => isOn = true;
        public void SwitchOff() => isOn = false;
        public bool IsOn() => isOn;
        public async Task Blink(int duration, int repeatCount)
        {
            Console.WriteLine("LED Light starting the Blink function.");
            await Task.Delay(duration * repeatCount);
            Console.WriteLine("LED Light has finished the Blink funtion.");
        }

        public override string ToString() => $"The light is {(isOn ? "on" : "off")}";
    }
    // </SnippetLEDLight>
}
