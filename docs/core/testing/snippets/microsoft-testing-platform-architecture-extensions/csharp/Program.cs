using System.Globalization;
using System.Text.Json;
using Microsoft.Testing.Platform.Builder;
using Microsoft.Testing.Platform.Capabilities.TestFramework;
using Microsoft.Testing.Platform.CommandLine;
using Microsoft.Testing.Platform.Configurations;
using Microsoft.Testing.Platform.Extensions.Messages;
using Microsoft.Testing.Platform.Extensions.OutputDevice;
using Microsoft.Testing.Platform.Extensions.TestFramework;
using Microsoft.Testing.Platform.Extensions.TestHost;
using Microsoft.Testing.Platform.Messages;
using Microsoft.Testing.Platform.OutputDevice;
using Microsoft.Testing.Platform.Requests;
using Microsoft.Testing.Platform.Services;

var builder = await TestApplication.CreateBuilderAsync(args);
builder.RegisterTestFramework(
    _ => new TestFrameworkCapabilities(),
    (_, _) => new SampleFramework());

// <RegisterCoverage>
builder.TestHost.AddTestSessionLifetimeHandler(
    services => new CoverageExtension(
        services.GetMessageBus(),
        services.GetConfiguration(),
        services.GetCommandLineOptions(),
        services.GetRequiredPlatformService<ITestCoverageCapabilities>(),
        services.GetOutputDevice()));
builder.TestHost.AddTestHostApplicationLifetime(
    services => new CoverageResultReporter(
        services.GetRequiredPlatformService<ITestCoverageResult>(),
        services.GetCommandLineOptions(),
        services.GetOutputDevice()));
// </RegisterCoverage>

using ITestApplication application = await builder.BuildAsync();
try
{
    return await application.RunAsync();
}
catch (ArgumentException exception)
{
    Console.Error.WriteLine($"Invalid sample coverage configuration: {exception.Message}");
    return 4;
}
catch (FormatException exception)
{
    Console.Error.WriteLine($"Invalid sample coverage configuration: {exception.Message}");
    return 4;
}
catch (OverflowException exception)
{
    Console.Error.WriteLine($"Invalid sample coverage configuration: {exception.Message}");
    return 4;
}

internal sealed class CoverageExtension : IDataProducer, ITestSessionLifetimeHandler, IOutputDeviceDataProducer
{
    private readonly IMessageBus _messageBus;
    private readonly ICommandLineOptions _options;
    private readonly ITestCoverageCapabilities _capabilities;
    private readonly IOutputDevice _outputDevice;
    private readonly long _covered;
    private readonly long _coverable;
    private readonly double _required;
    private readonly bool _treatNoDataAsFailure;

    public CoverageExtension(
        IMessageBus messageBus,
        IConfiguration configuration,
        ICommandLineOptions options,
        ITestCoverageCapabilities capabilities,
        IOutputDevice outputDevice)
    {
        long coveredCount = long.Parse(
            configuration["sampleCoverage:covered"] ?? "8", CultureInfo.InvariantCulture);
        long coverableCount = long.Parse(
            configuration["sampleCoverage:coverable"] ?? "10", CultureInfo.InvariantCulture);
        double requiredPercentage = double.Parse(
            configuration["sampleCoverage:requiredPercentage"] ?? "75", CultureInfo.InvariantCulture);
        ArgumentOutOfRangeException.ThrowIfNegative(coverableCount);
        ArgumentOutOfRangeException.ThrowIfNegative(coveredCount);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(coveredCount, coverableCount);
        if (!double.IsFinite(requiredPercentage) || requiredPercentage < 0 || requiredPercentage > 100)
        {
            throw new ArgumentException(
                "The sampleCoverage:requiredPercentage setting must be finite and between 0 and 100.",
                nameof(configuration));
        }

        _messageBus = messageBus;
        _options = options;
        _capabilities = capabilities;
        _outputDevice = outputDevice;
        _covered = coveredCount;
        _coverable = coverableCount;
        _required = requiredPercentage;
        _treatNoDataAsFailure = bool.Parse(
            configuration["sampleCoverage:treatNoDataAsFailure"] ?? "true");
    }

    public string Uid => nameof(CoverageExtension);
    public string Version => "1.0.0";
    public string DisplayName => "Sample coverage extension";
    public string Description => "Publishes synthetic coverage measurements.";

    // <CoverageDataTypes>
    public Type[] DataTypesProduced =>
    [
        typeof(TestCoverageMessage),
        typeof(TestCoverageThresholdMessage),
        typeof(TestCoverageReportMessage),
        typeof(SessionFileArtifact)
    ];
    // </CoverageDataTypes>

    public Task<bool> IsEnabledAsync() => Task.FromResult(!_options.IsOptionSet("list-tests"));

    // <ReadCoverageCapabilities>
    public Task OnTestSessionStartingAsync(ITestSessionContext context)
        => _outputDevice.DisplayAsync(this, new TextOutputDeviceData(
            $"Coverage messages supported: {_capabilities.SupportsTestCoverageMessages}. " +
            $"Enabled producers: {string.Join(", ", _capabilities.EnabledProducerUids)}."),
            context.CancellationToken);
    // </ReadCoverageCapabilities>

    public async Task OnTestSessionFinishingAsync(ITestSessionContext context)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        string resultsDirectory = _options.TryGetOptionArgumentList("results-directory", out string[]? arguments)
            ? arguments[0]
            : Path.Combine(AppContext.BaseDirectory, "TestResults");
        var report = new FileInfo(Path.Combine(resultsDirectory, "sample-coverage.json"));
        report.Directory!.Create();
        await File.WriteAllTextAsync(
            report.FullName,
            JsonSerializer.Serialize(new { covered = _covered, coverable = _coverable }),
            context.CancellationToken);

        // <PublishCoverage>
        var measurement = new TestCoverageMessage(
            context.SessionUid, CoverageScope.Overall, CoverageMetric.Line,
            _covered, _coverable, producerId: Uid);
        await _messageBus.PublishAsync(this, measurement);

        var threshold = new TestCoverageThresholdMessage(
            context.SessionUid, CoverageScope.Overall, CoverageMetric.Line,
            CoverageAggregation.None, measurement.Percentage, _required,
            measurement.HasCoverableData, producerId: Uid,
            treatNoDataAsFailure: _treatNoDataAsFailure);
        await _messageBus.PublishAsync(this, threshold);

        await _messageBus.PublishAsync(this, new TestCoverageReportMessage(
            context.SessionUid, report.FullName, CoverageReportFormat.Custom,
            producerId: Uid, customFormatName: "sample-json"));
        await _messageBus.PublishAsync(this, new SessionFileArtifact(
            context.SessionUid, report, "Sample coverage", "Synthetic coverage counts."));
        // </PublishCoverage>
    }
}

internal sealed class CoverageResultReporter(
    ITestCoverageResult result, ICommandLineOptions options, IOutputDevice outputDevice)
    : ITestHostApplicationLifetime, IOutputDeviceDataProducer
{
    public string Uid => nameof(CoverageResultReporter);
    public string Version => "1.0.0";
    public string DisplayName => "Sample coverage result reporter";
    public string Description => "Reads coverage results after the test session.";
    public Task<bool> IsEnabledAsync() => Task.FromResult(!options.IsOptionSet("list-tests"));
    public Task BeforeRunAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    // <ReadCoverageResult>
    public async Task AfterRunAsync(int exitCode, CancellationToken cancellationToken)
    {
        foreach (CoverageScopeSummary scope in result.Scopes)
        {
            foreach (CoverageMetricResult metric in scope.Metrics)
            {
                string text = string.Create(CultureInfo.InvariantCulture,
                    $"Coverage result: {metric.CoveredCount}/{metric.CoverableCount} " +
                    $"{metric.Metric} ({metric.Percentage:F1}%). Producer: {metric.ProducerId}.");
                await outputDevice.DisplayAsync(
                    this, new TextOutputDeviceData(text), cancellationToken);
            }
        }

        await outputDevice.DisplayAsync(this, new TextOutputDeviceData(
            $"Coverage threshold failure: {result.HasThresholdFailure}. " +
            $"Coverage reports: {result.Reports.Count}. Exit code: {exitCode}."),
            cancellationToken);
    }
    // </ReadCoverageResult>
}

internal sealed class SampleFramework : ITestFramework, IDataProducer
{
    public string Uid => nameof(SampleFramework);
    public string Version => "1.0.0";
    public string DisplayName => "Coverage sample framework";
    public string Description => "Supplies one test for the coverage extension example.";
    public Type[] DataTypesProduced => [typeof(TestNodeUpdateMessage)];

    public Task<bool> IsEnabledAsync() => Task.FromResult(true);

    public Task<CreateTestSessionResult> CreateTestSessionAsync(CreateTestSessionContext context)
        => Task.FromResult(new CreateTestSessionResult { IsSuccess = true });

    public Task<CloseTestSessionResult> CloseTestSessionAsync(CloseTestSessionContext context)
        => Task.FromResult(new CloseTestSessionResult { IsSuccess = true });

    public async Task ExecuteRequestAsync(ExecuteRequestContext context)
    {
        if (context.Request is not DiscoverTestExecutionRequest
            and not RunTestExecutionRequest)
        {
            throw new NotSupportedException("The request type isn't supported.");
        }

        var request = (TestExecutionRequest)context.Request;
        bool selected = request.Filter switch
        {
            NopFilter => true,
            TestNodeUidListFilter filter => filter.TestNodeUids.Any(
                uid => string.Equals(uid.Value, "coverage.test", StringComparison.Ordinal)),
            _ => throw new NotSupportedException("The filter type isn't supported.")
        };
        if (selected)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            TestNodeStateProperty state = request is DiscoverTestExecutionRequest
                ? DiscoveredTestNodeStateProperty.CachedInstance
                : PassedTestNodeStateProperty.CachedInstance;
            await context.MessageBus.PublishAsync(this, new TestNodeUpdateMessage(
                request.Session.SessionUid,
                new TestNode
                {
                    Uid = "coverage.test",
                    DisplayName = "CoverageTest",
                    Properties = new PropertyBag(state)
                }));
        }

        context.Complete();
    }
}
