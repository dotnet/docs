using System;

namespace ConsoleJson.Example
{
    public record TransientFaultHandlingOptions(
        bool Enabled = false, TimeSpan AutoRetryDelay = default);
}
