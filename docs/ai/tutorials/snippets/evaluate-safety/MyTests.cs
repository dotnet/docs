// <SnippetUsingDirectives>
using Azure.Identity;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Safety;
// </SnippetUsingDirectives>

[TestClass]
public sealed class MyTests
{
    // <SnippetScenarioName>
    private string ScenarioName => $"{TestContext!.FullyQualifiedTestClassName}.{TestContext.TestName}";
    private static string ExecutionName => $"{DateTime.Now:yyyyMMddTHHmmss}";
    // </SnippetScenarioName>

    // <SnippetTestContext>
    // The value of the TestContext property is populated by MSTest.
    public TestContext? TestContext { get; set; }
    // </SnippetTestContext>

    // <SnippetGetEvaluators>
    private static IEnumerable<IEvaluator> GetSafetyEvaluators()
    {
        IEvaluator violenceEvaluator = new ViolenceEvaluator();
        yield return violenceEvaluator;

        IEvaluator hateAndUnfairnessEvaluator = new HateAndUnfairnessEvaluator();
        yield return hateAndUnfairnessEvaluator;

        IEvaluator protectedMaterialEvaluator = new ProtectedMaterialEvaluator();
        yield return protectedMaterialEvaluator;

        IEvaluator indirectAttackEvaluator = new IndirectAttackEvaluator();
        yield return indirectAttackEvaluator;
    }
    // </SnippetGetEvaluators>

    // <SnippetGetTags>
    private static IEnumerable<string> GetTags(string storageKind = "Disk")
    {
        yield return $"Execution: {ExecutionName}";

        ChatClientMetadata? metadata = s_safetyServiceConfig.ChatClient.GetService<ChatClientMetadata>();

        yield return $"Provider: {metadata?.ProviderName ?? "Unknown"}";
        yield return $"Model: {metadata?.DefaultModelId ?? "Unknown"}";
        yield return $"Storage: {storageKind}";
    }
    // </SnippetGetTags>

    // <SnippetServiceConfig>
    private static readonly ContentSafetyServiceConfiguration? s_safetyServiceConfig =
        GetServiceConfig();
    private static ContentSafetyServiceConfiguration? GetServiceConfig()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<MyTests>().Build();

        string subscriptionId = config["AZURE_SUBSCRIPTION_ID"];
        string resourceGroup = config["AZURE_RESOURCE_GROUP"];
        string project = config["AZURE_AI_PROJECT"];
        string tenantId = config["AZURE_TENANT_ID"];

        return new ContentSafetyServiceConfiguration(
            credential: new DefaultAzureCredential(new DefaultAzureCredentialOptions() { TenantId = tenantId }),
            subscriptionId: subscriptionId,
            resourceGroupName: resourceGroup,
            projectName: project);
    }
    // </SnippetServiceConfig>

    // <SnippetReportingConfig>
    private static readonly ReportingConfiguration? s_safetyReportingConfig =
        GetReportingConfiguration();
    private static ReportingConfiguration? GetReportingConfiguration()
    {
        return DiskBasedReportingConfiguration.Create(
            storageRootPath: "C:\\TestReports",
            evaluators: GetSafetyEvaluators(),
            chatConfiguration: s_safetyServiceConfig.ToChatConfiguration(),
            enableResponseCaching: true,
            executionName: ExecutionName,
            tags: GetTags());
    }
    // </SnippetReportingConfig>

    }
