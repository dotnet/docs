using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mixins_with_interfaces
{
    // <SnippetExtraFancyLight>
    public class ExtraFancyLight : IBlinkingLight, ITimerLight, ILight
    {
        private bool isOn;
        public void SwitchOn() => isOn = true;
        public void SwitchOff() => isOn = false;
        public bool IsOn() => isOn;
        public async Task Blink(int duration, int repeatCount)
        {
            Console.WriteLine("Extra Fancy Light starting the Blink function.");
            await Task.Delay(duration * repeatCount);
            Console.WriteLine("Extra Fancy Light has finished the Blink function.");
        }
        public async Task TurnOnFor(int duration)
        {
            Console.WriteLine("Extra Fancy light starting timer function.");
            await Task.Delay(duration);
            Console.WriteLine("Extra Fancy light finished custom timer function");
        }

        public override string ToString() => $"The light is {(isOn ? "on" : "off")}";
    }
    // </SnippetExtraFancyLight>
}
