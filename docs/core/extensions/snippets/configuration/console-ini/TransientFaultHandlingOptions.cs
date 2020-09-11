using System;

namespace ConsoleIni.Example
{
    public record TransientFaultHandlingOptions(
        bool Enabled, TimeSpan AutoRetryDelay);
}
