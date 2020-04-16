using System;
using System.Threading.Tasks;

namespace mixins_with_interfaces
{
    class Program
    {
        // <SnippetMainMethod>
        static async Task Main(string[] args)
        {
            Console.WriteLine("Testing the overhead light");
            var overhead = new OverheadLight();
            await TestLightCapabilities(overhead);
            Console.WriteLine();

            Console.WriteLine("Testing the halogen light");
            var halogen = new HalogenLight();
            await TestLightCapabilities(halogen);
            Console.WriteLine();

            Console.WriteLine("Testing the LED light");
            var led = new LEDLight();
            await TestLightCapabilities(led);
            Console.WriteLine();

            Console.WriteLine("Testing the fancy light");
            var fancy = new ExtraFancyLight();
            await TestLightCapabilities(fancy);
            Console.WriteLine();
        }
        // </  SnippetMainMethod>

        // <SnippetTestLightFunctions>
        private static async Task TestLightCapabilities(ILight light)
        {
            // Perform basic tests:
            light.SwitchOn();
            Console.WriteLine($"\tAfter switching on, the light is {(light.IsOn() ? "on" : "off")}");
            light.SwitchOff();
            Console.WriteLine($"\tAfter switching off, the light is {(light.IsOn() ? "on" : "off")}");

            if (light is ITimerLight timer)
            {
                Console.WriteLine("\tTesting timer function");
                await timer.TurnOnFor(1000);
                Console.WriteLine("\tTimer function completed");
            }
            else
            {
                Console.WriteLine("\tTimer function not supported.");
            }

            if (light is IBlinkingLight blinker)
            {
                Console.WriteLine("\tTesting blinking function");
                await blinker.Blink(500, 5);
                Console.WriteLine("\tBlink function completed");
            }
            else
            {
                Console.WriteLine("\tBlink function not supported.");
            }
        }
        // </SnippetTestLightFunctions>
    }
}
