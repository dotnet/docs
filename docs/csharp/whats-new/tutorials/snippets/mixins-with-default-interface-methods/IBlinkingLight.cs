using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mixins_with_interfaces
{
    // <SnippetBlinkingLight>
    public interface IBlinkingLight : ILight
    {
        public async Task Blink(int duration, int repeatCount)
        {
            Console.WriteLine("Using the default interface method for IBlinkingLight.Blink.");
            for (int count = 0; count < repeatCount; count++)
            {
                SwitchOn();
                await Task.Delay(duration);
                SwitchOff();
                await Task.Delay(duration);
            }
            Console.WriteLine("Done with the default interface method for IBlinkingLight.Blink.");
        }
    }
    // </SnippetBlinkingLight>
}
