using System;

namespace ConsoleJson.Example
{
    public record TransientFaultHandlingOptions(
        bool Enabled, TimeSpan AutoRetryDelay);
}
