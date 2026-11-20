using Microsoft.Testing.Platform.Builder;
using Microsoft.Testing.Platform.Capabilities.TestFramework;
using Microsoft.Testing.Platform.Extensions;
using Microsoft.Testing.Platform.Extensions.TestFramework;
using Microsoft.Testing.Platform.Helpers;

namespace GracefulStopExample;

// <GracefulStop>
public sealed class GracefulStopCapability : IGracefulStopTestExecutionCapability
{
    private int _stopRequested;

    public bool IsStopRequested => Volatile.Read(ref _stopRequested) != 0;

    public Task StopTestExecutionAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Interlocked.Exchange(ref _stopRequested, 1);
        return Task.CompletedTask;
    }
}
// </GracefulStop>

public static class FrameworkRegistration
{
    // <Registration>
    public static void Register(
        ITestApplicationBuilder builder,
        IExtension owner,
        Func<GracefulStopCapability, ITestFramework> createFramework)
    {
        builder.RegisterTestFramework(
            _ => new TestFrameworkCapabilities(new GracefulStopCapability()),
            (capabilities, _) => createFramework(
                capabilities.Capabilities.OfType<GracefulStopCapability>().Single()));
        builder.AddMaximumFailedTestsService(owner);
    }
    // </Registration>
}
