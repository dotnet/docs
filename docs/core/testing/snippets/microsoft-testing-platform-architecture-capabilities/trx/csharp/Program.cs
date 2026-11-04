using Microsoft.Testing.Extensions;
using Microsoft.Testing.Extensions.TrxReport.Abstractions;
using Microsoft.Testing.Platform.Builder;
using Microsoft.Testing.Platform.Capabilities.TestFramework;
using Microsoft.Testing.Platform.Extensions.Messages;
using Microsoft.Testing.Platform.Extensions.TestFramework;
using Microsoft.Testing.Platform.Requests;

// <RegisterTrxCapability>
var trxCapability = new TrxCapability();
var builder = await TestApplication.CreateBuilderAsync(args);
builder.RegisterTestFramework(
    _ => new TestFrameworkCapabilities(trxCapability),
    (_, _) => new ReportFramework(trxCapability));
builder.AddTrxReportProvider();
// </RegisterTrxCapability>

using ITestApplication application = await builder.BuildAsync();
return await application.RunAsync();

// <TrxCapability>
internal sealed class TrxCapability : ITrxReportCapability
{
    public bool IsSupported => true;
    public bool IsEnabled { get; private set; }

    public void Enable() => IsEnabled = true;
}
// </TrxCapability>

internal sealed class ReportFramework(TrxCapability trxCapability) : ITestFramework, IDataProducer
{
    private static readonly (string Uid, string Name, Action Body)[] s_tests =
    [
        ("trx.pass", "PassingTest", () => { }),
        ("trx.fail", "FailingTest", () => throw new InvalidOperationException("The sample assertion failed."))
    ];

    public string Uid => nameof(ReportFramework);
    public string Version => "1.0.0";
    public string DisplayName => "TRX sample framework";
    public string Description => "Demonstrates TRX capability activation and metadata.";
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
        foreach (var test in s_tests)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            bool selected = request.Filter switch
            {
                NopFilter => true,
                TestNodeUidListFilter filter => filter.TestNodeUids.Any(
                    uid => string.Equals(uid.Value, test.Uid, StringComparison.Ordinal)),
                _ => throw new NotSupportedException("The filter type isn't supported.")
            };
            if (!selected)
            {
                continue;
            }

            var testNode = new TestNode
            {
                Uid = test.Uid,
                DisplayName = test.Name
            };
            if (request is DiscoverTestExecutionRequest)
            {
                testNode.Properties.Add(DiscoveredTestNodeStateProperty.CachedInstance);
            }
            else
            {
                Exception? failure = null;
                try
                {
                    test.Body();
                }
                catch (InvalidOperationException exception)
                {
                    failure = exception;
                }

                testNode.Properties.Add(failure is null
                    ? PassedTestNodeStateProperty.CachedInstance
                    : new FailedTestNodeStateProperty(failure));

                // <EnrichTrxResult>
                if (trxCapability.IsEnabled)
                {
                    testNode.Properties.Add(
                        new TrxFullyQualifiedTypeNameProperty("Contoso.CalculatorTests"));
                    testNode.Properties.Add(new TrxCategoriesProperty(["Unit"]));
                    testNode.Properties.Add(new TrxMessagesProperty(
                        [new StandardOutputTrxMessage($"Captured output for {test.Name}.")]));
                    if (failure is not null)
                    {
                        testNode.Properties.Add(
                            new TrxExceptionProperty(failure.Message, failure.StackTrace));
                    }
                }
                // </EnrichTrxResult>
            }

            await context.MessageBus.PublishAsync(
                this, new TestNodeUpdateMessage(request.Session.SessionUid, testNode));
        }

        context.Complete();
    }
}
