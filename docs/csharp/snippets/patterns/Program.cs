using System;

namespace patterns
{
    public enum Severity
    {
        Critical,
        Error,
        Warning,
        Information,
        Debug,
        Trace
    }
    // Severity: Severity
    // MessageCode: Code for searching by component.
    // Component: Name of library, etc.
    // Message: Duh.
    public record LogMessage(Severity Level, int? MessageCode, string Component, string Message);
    class Program
    {
        static void Main(string[] args)
        {
            // Scenarios we need:
            var log = new ConsoleLogger();



            // 1. Type test var is some type.
                // nullable value type (Message code.)
                // is null (msg)
            var msg = new LogMessage(Severity.Error, 12, "Testing", "This is a test message");
            log.WriteLog(msg);

            // different code for different types.... Not sure yet....
            log.WriteLogMessage("This is a message");

            // 2. Enum values. (Easy for logging)
            // var and discard (missing enum or invalid value)
            // See value example. ValueExample
            // 3. Relational patterns. RelationalExample (This is getting ugly. Probably better to reorder)
            log.WriteFormattedLogMessage(msg);

            // 4. Properties (back to log)
            // 5. Deconstruction (Format string for message code & component)
            // 6. Tuples (log: message type & filter)
            // 7. and, or, not (along with tuples.)


            Console.WriteLine("Hello World!");
        }
    }
}
