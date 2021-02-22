using System;

namespace ConsoleJson.Example
{
    public record TransientFaultHandlingOptions
    {
        public bool Enabled { get; init; }
        public TimeSpan AutoRetryDelay { get; init; }
    }
}
