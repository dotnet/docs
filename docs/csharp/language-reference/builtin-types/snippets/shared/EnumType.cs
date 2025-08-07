// <SnippetProgramExample>

namespace builtin_types;

public static class EnumType
{
    public static void Examples()
    {
        FlagsEnumExample.Main();
        EnumConversionExample.Main();
        ZeroConversionExample.Main();
    }

    // <SnippetFlags>
    [Flags]
    public enum Days
    {
        None      = 0b_0000_0000,  // 0
        Monday    = 0b_0000_0001,  // 1
        Tuesday   = 0b_0000_0010,  // 2
        Wednesday = 0b_0000_0100,  // 4
        Thursday  = 0b_0000_1000,  // 8
        Friday    = 0b_0001_0000,  // 16
        Saturday  = 0b_0010_0000,  // 32
        Sunday    = 0b_0100_0000,  // 64
        Weekend   = Saturday | Sunday
    }

    public class FlagsEnumExample
    {
        public static void Main()
        {
            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine(meetingDays);
            // Output:
            // Monday, Wednesday, Friday

            Days workingFromHomeDays = Days.Thursday | Days.Friday;
            Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");
            // Output:
            // Join a meeting by phone on Friday

            bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
            Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
            // Output:
            // Is there a meeting on Tuesday: False

            var a = (Days)37;
            Console.WriteLine(a);
            // Output:
            // Monday, Wednesday, Saturday
        }
    }
    // </SnippetFlags>

    // <SnippetConversions>
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public class EnumConversionExample
    {
        public static void Main()
        {
            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

            var b = (Season)1;
            Console.WriteLine(b);  // output: Summer

            var c = (Season)4;
            Console.WriteLine(c);  // output: 4
        }
    }
    // </SnippetConversions>

    // <SnippetZeroConversions>
    public enum GpioPort
    {
        GpioA = 1,
        GpioB,
        GpioC,
        GpioD
    }

    public class ZeroConversionExample
    {
        public static void Main()
        {
            // This compiles without warning but creates an invalid enum value
            GpioPort port1 = (GpioPort)0;
            Console.WriteLine($"port1: {port1}"); // Output: port1: 0

            // This also compiles due to implicit conversion from zero
            GpioPort port2 = GetPort(0);
            Console.WriteLine($"port2: {port2}"); // Output: port2: 0

            // Check if the enum value is valid
            bool isValid1 = Enum.IsDefined(typeof(GpioPort), port1);
            bool isValid2 = Enum.IsDefined(typeof(GpioPort), port2);
            Console.WriteLine($"port1 is valid: {isValid1}"); // Output: port1 is valid: False
            Console.WriteLine($"port2 is valid: {isValid2}"); // Output: port2 is valid: False

            // Safer approach - validate enum values
            if (Enum.IsDefined(typeof(GpioPort), 0))
            {
                GpioPort safePort = (GpioPort)0;
            }
            else
            {
                Console.WriteLine("Value 0 is not a valid GpioPort");
                // Handle the invalid case appropriately
            }
        }

        public static GpioPort GetPort(GpioPort port)
        {
            return port;
        }
    }
    // </SnippetZeroConversions>
}
