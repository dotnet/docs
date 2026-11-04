using Microsoft.Testing.Platform.Builder;
using Microsoft.Testing.Platform.Capabilities.TestFramework;
using Microsoft.Testing.Platform.Extensions.Messages;
using Microsoft.Testing.Platform.Extensions.TestFramework;
using Microsoft.Testing.Platform.Requests;

var builder = await TestApplication.CreateBuilderAsync(args);
builder.RegisterTestFramework(
    _ => new TestFrameworkCapabilities(),
    (_, _) => new SampleFramework());
using ITestApplication application = await builder.BuildAsync();
return await application.RunAsync();

internal sealed class SampleFramework : ITestFramework, IDataProducer
{
    private static readonly (string Uid, string Name)[] s_tests =
    [
        ("sample.first", "FirstTest"),
        ("sample.second", "SecondTest")
    ];

    public string Uid => nameof(SampleFramework);
    public string Version => "1.0.0";
    public string DisplayName => "Sample framework";
    public string Description => "Demonstrates UID filters and per-test output.";
    public Type[] DataTypesProduced => [typeof(TestNodeUpdateMessage)];

    public Task<bool> IsEnabledAsync() => Task.FromResult(true);

    public Task<CreateTestSessionResult> CreateTestSessionAsync(CreateTestSessionContext context)
        => Task.FromResult(new CreateTestSessionResult { IsSuccess = true });

    public Task<CloseTestSessionResult> CloseTestSessionAsync(CloseTestSessionContext context)
        => Task.FromResult(new CloseTestSessionResult { IsSuccess = true });

    // <HandleFilters>
    public async Task ExecuteRequestAsync(ExecuteRequestContext context)
    {
        if (context.Request is not DiscoverTestExecutionRequest
            and not RunTestExecutionRequest)
        {
            throw new NotSupportedException("The request type isn't supported.");
        }

        var request = (TestExecutionRequest)context.Request;
        foreach (var test in s_tests)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            var uid = new TestNodeUid(test.Uid);
            if (!MatchesFilter(request.Filter, uid))
            {
                continue;
            }

            if (request is DiscoverTestExecutionRequest)
            {
                await context.MessageBus.PublishAsync(this, new TestNodeUpdateMessage(
                    request.Session.SessionUid,
                    new TestNode
                    {
                        Uid = uid,
                        DisplayName = test.Name,
                        Properties = new PropertyBag(DiscoveredTestNodeStateProperty.CachedInstance)
                    }));
            }
            else
            {
                await PublishResultAsync(context, request, uid, test.Name);
            }
        }

        context.Complete();
    }
    // </HandleFilters>

    // <MatchFilter>
    private static bool MatchesFilter(ITestExecutionFilter filter, TestNodeUid uid)
        => filter switch
        {
            NopFilter => true,
            TestNodeUidListFilter uidFilter => uidFilter.TestNodeUids.Any(
                candidate => string.Equals(candidate.Value, uid.Value, StringComparison.Ordinal)),
            _ => throw new NotSupportedException(
                $"Filter '{filter.GetType().FullName}' isn't supported.")
        };
    // </MatchFilter>

    private async Task PublishResultAsync(
        ExecuteRequestContext context, TestExecutionRequest request, TestNodeUid uid, string name)
    {
        // <CapturedOutput>
        var testNode = new TestNode
        {
            Uid = uid,
            DisplayName = name,
            Properties = new PropertyBag(
                PassedTestNodeStateProperty.CachedInstance,
                new StandardOutputProperty($"Output from {name}."),
                new StandardErrorProperty($"Diagnostic from {name}."))
        };

        await context.MessageBus.PublishAsync(
            this, new TestNodeUpdateMessage(request.Session.SessionUid, testNode));
        // </CapturedOutput>
    }
}
