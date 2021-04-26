using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    public class ConsoleLogger
    {
        public Severity SeverityFilter { get; set; }

        // <TypeExample>
        public void WriteLog(LogMessage msg, 
            [CallerFilePathAttribute] string? path = default, [CallerLineNumber] int line = default)
        {
            if (msg is null)
            {
                Console.WriteLine($"Null message logged from file {path}, line {line}");
            }
            else if (msg.MessageCode is int code)
            {
                Console.WriteLine($"{msg.Level}: From {msg.Component}, {code}. {msg.Message}");
            }
            else
            {
                Console.WriteLine($"{msg.Level}: From {msg.Component}. {msg.Message}");
            }
        }
        // </TypeExample>

        // <SecondTypeExample>
        public void WriteLogMessage(object msg,
            [CallerFilePathAttribute] string? path = default, [CallerLineNumber] int line = default)
        {
            string output = msg switch
            {
                null => $"Null message logged from file {path}, line {line}",
                string s => s,
                LogMessage m => $"{m.Level}: From {m.Component}, {m.MessageCode}. {m.Message}",
                var obj => obj.ToString()
            };
            Console.WriteLine(output);
        }
        // </SecondTypeExample>

        // <ValueExample>
        private string SeverityText(Severity s) =>
            s switch
            {
                Severity.Critical => "!!!CRITICAL!!!",
                Severity.Error => "ERROR",
                Severity.Warning => "\tWarning",
                Severity.Information => "\tInformation",
                Severity.Debug => "\t\tDetails",
                Severity.Trace => "\t\tDebug Tracing",
                var number => "Unknown Severity Value: {number}",
            };
        // </ValueExample>

        // <RelationalExample>
        public void WriteFormattedLogMessage(object msg,
            [CallerFilePathAttribute] string? path = default, [CallerLineNumber] int line = default)
        {
            string output = msg switch
            {
                null => $"Null message logged from file {path}, line {line}",
                string s => s,
                LogMessage m => m.Message.Length switch
                {
                    < 40 => $"{m.Level}: From {m.Component}, {m.MessageCode}. {m.Message}",
                    < 100 => $"{m.Level}: From {m.Component}, {m.MessageCode}:\n\t{m.Message}",
                    _ => $"{m.Level}: From {m.Component}, {m.MessageCode}:\n{m.Message}\n\n",
                },
                var obj => obj.ToString()
            };
            Console.WriteLine(output);
        }
        // </RelationalExample>

        // <PropertyDeconstructionExample>
        public void WriteDeconstructedLogMessage(LogMessage msg,
            [CallerFilePathAttribute] string? path = default, [CallerLineNumber] int line = default)
        {
            string output = msg switch
            {
                null => $"Null message logged from file {path}, line {line}",
                (_, not null, _, text ) => 
                LogMessage m => m.Message.Length switch
                {
                    < 40 => $"{m.Level}: From {m.Component}, {m.MessageCode}. {m.Message}",
                    < 100 => $"{m.Level}: From {m.Component}, {m.MessageCode}:\n\t{m.Message}",
                    _ => $"{m.Level}: From {m.Component}, {m.MessageCode}:\n{m.Message}\n\n",
                },
                var obj => obj.ToString()
            };
            Console.WriteLine(output);
        }
        // </PropertyDeconstructionExample>
    }
}
