using System;

namespace ConsoleXml.Example
{
    public record TransientFaultHandlingOptions(
        bool Enabled, TimeSpan AutoRetryDelay);
}
