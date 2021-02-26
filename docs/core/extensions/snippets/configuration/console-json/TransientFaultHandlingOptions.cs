using System;

namespace ConsoleJson.Example
{
    public record TransientFaultHandlingOptions
    {
        public bool Enabled { get; set; }
        public TimeSpan AutoRetryDelay { get; set; }
    }
}
