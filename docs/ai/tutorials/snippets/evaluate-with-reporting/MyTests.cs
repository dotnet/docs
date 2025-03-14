using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;
using Microsoft.Extensions.Configuration;

namespace TestAIWithReporting;

[TestClass]
public sealed class MyTests
{
    // The value of the TestContext property is populated by MSTest.
    public TestContext? TestContext { get; set; }

    // <SnippetExecutionName>
    private static string? s_executionName;
    public static string ExecutionName
    {
        get
        {
            if (s_executionName is null)
            {
                s_executionName = $"{DateTime.Now:yyyyMMddTHHmmss}";
            }

            return s_executionName;
        }
    }
    // </SnippetExecutionName>

    private string ScenarioName => $"{TestContext!.FullyQualifiedTestClassName}.{TestContext.TestName}";

    private static readonly ReportingConfiguration s_defaultReportingConfiguration =
        DiskBasedReportingConfiguration.Create(
            storageRootPath: "C:\\TestReports",
            evaluators: GetEvaluators(),
            chatConfiguration: GetAzureOpenAIChatConfiguration(),
            enableResponseCaching: true,
            executionName: ExecutionName);

    private static IEnumerable<IEvaluator> GetEvaluators()
    {
        var rtcOptions = new RelevanceTruthAndCompletenessEvaluatorOptions(includeReasoning: true);
        IEvaluator rtcEvaluator = new RelevanceTruthAndCompletenessEvaluator(rtcOptions);
        IEvaluator wordCountEvaluator = new WordCountEvaluator();

        return [rtcEvaluator, wordCountEvaluator];
    }

    private static async Task<(IList<ChatMessage> Messages, ChatMessage ModelResponse)> GetAstronomyConversationAsync(
        IChatClient chatClient,
        string astronomyQuestion)
    {
        const string SystemPrompt =
            """            
            You're an AI assistant that can answer questions related to astronomy.
            Keep your responses concise and try to stay under 100 words.
            Use the imperial measurement system for all measurements in your response.
            """;

        IList<ChatMessage> messages =
            [
                new ChatMessage(ChatRole.System, SystemPrompt),
                new ChatMessage(ChatRole.User, astronomyQuestion)
            ];

        var chatOptions =
            new ChatOptions
            {
                Temperature = 0.0f,
                ResponseFormat = ChatResponseFormat.Text
            };

        ChatResponse completion = await chatClient.GetResponseAsync(messages, chatOptions);
        return (messages, ModelResponse: completion.Message);
    }

    /// <summary>
    /// Runs some basic validation on the supplied <see cref="EvaluationResult"/>.
    /// </summary>
    private static void Validate(EvaluationResult result)
    {
        // Note that since 'includeReasoning' was set to 'true' when creating the
        // <see cref="RelevanceTruthAndCompletenessEvaluator"/> inside <see cref="GetEvaluators"/>, the
        // 'relevance', 'truth', and 'completeness' metrics will each include a single informational diagnostic
        // explaining the reasoning for the score. This diagnostic is included in the generated report and can be
        // viewed by hovering over the corresponding metric's card in the report.

        // Retrieve the score for relevance from the <see cref="EvaluationResult"/>.
        NumericMetric relevance =
            result.Get<NumericMetric>(RelevanceTruthAndCompletenessEvaluator.RelevanceMetricName);
        Assert.IsNotNull(relevance.Interpretation);
        Assert.IsFalse(relevance.Interpretation.Failed);
        Assert.IsTrue(relevance.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        // Retrieve the score for truth from the <see cref="EvaluationResult"/>.
        NumericMetric truth = result.Get<NumericMetric>(RelevanceTruthAndCompletenessEvaluator.TruthMetricName);
        Assert.IsFalse(truth.Interpretation!.Failed);
        Assert.IsTrue(truth.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        // Retrieve the score for completeness from the <see cref="EvaluationResult"/>.
        NumericMetric completeness =
            result.Get<NumericMetric>(RelevanceTruthAndCompletenessEvaluator.CompletenessMetricName);
        Assert.IsFalse(completeness.Interpretation!.Failed);
        Assert.IsTrue(completeness.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        // Retrieve the word count from the <see cref="EvaluationResult"/>.
        NumericMetric wordCount = result.Get<NumericMetric>(WordCountEvaluator.WordCountMetricName);
        Assert.IsFalse(wordCount.Interpretation!.Failed);
        Assert.IsTrue(wordCount.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);
        Assert.IsFalse(wordCount.ContainsDiagnostics());
        Assert.IsTrue(wordCount.Value <= 100);
    }

    // <SnippetGetChatConfig>
    private static ChatConfiguration GetAzureOpenAIChatConfiguration()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<MyTests>().Build();

        string endpoint = config["AZURE_OPENAI_ENDPOINT"];
        string model = config["AZURE_OPENAI_GPT_NAME"];
        string tenantId = config["AZURE_TENANT_ID"];

        // Get an instance of Microsoft.Extensions.AI's <see cref="IChatClient"/>
        // interface for the selected LLM endpoint.
        AzureOpenAIClient azureClient =
            new AzureOpenAIClient(
                new Uri(endpoint),
                new DefaultAzureCredential(new DefaultAzureCredentialOptions() { TenantId = tenantId }));
        IChatClient client = azureClient.AsChatClient(modelId: model);

        // Create an instance of <see cref="ChatConfiguration"/>
        // to communicate with the LLM.
        return new ChatConfiguration(client);
    }
    // </SnippetGetChatConfig>

    [TestMethod]
    public async Task SampleAndEvaluateSingleResponse()
    {
        // Create a <see cref="ScenarioRun"/> with the scenario name
        // set to the fully qualified name of the current test method.
        await using ScenarioRun scenarioRun =
            await s_defaultReportingConfiguration.CreateScenarioRunAsync(this.ScenarioName);

        // Use the <see cref="IChatClient"/> that's included in the
        // <see cref="ScenarioRun.ChatConfiguration"/> to get the LLM response.
        // Since the <see cref="scenarioRun"/> was
        // created using <see cref="s_defaultReportingConfiguration"/>, and since response caching is turned on for
        // <see cref="s_defaultReportingConfiguration"/>, the LLM response will be fetched:
        // - Directly from the LLM endpoint that was configured in
        //   <see cref="s_defaultReportingConfiguration"/> in the very first run of the current test.
        // - From the (disk-based) response cache that was configured in <see cref="s_defaultReportingConfiguration"/>
        //   in every subsequent run of the test, until the cached entry expires (in 14 days by default).
        (IList<ChatMessage> messages, ChatMessage modelResponse) = await GetAstronomyConversationAsync(
            chatClient: scenarioRun.ChatConfiguration!.ChatClient,
            astronomyQuestion: "How far is the Moon from the Earth at its closest and furthest points?");

        // Run the evaluators configured in <see cref="s_defaultReportingConfiguration"/> against the response.
        // Since the <see cref="scenarioRun"/> was created using <see cref="s_defaultReportingConfiguration"/>, and since
        // response caching is turned on for <see cref="s_defaultReportingConfiguration"/>, the evaluation will be:
        // - Performed using the the LLM endpoint that was configured in
        //   <see cref="s_defaultReportingConfiguration"/> in the very first run of the current test.
        // - Fetched from the (disk-based) response cache that was configured in
        //   <see cref="s_defaultReportingConfiguration"/> in every subsequent run of the test, until the cached entry
        //   expires (in 14 days by default).
        EvaluationResult result = await scenarioRun.EvaluateAsync(messages, modelResponse);

        // Run some basic validation on the evaluation result.
        // 
        // Note: This step is optional and mainly for demonstration purposes. In real-world evaluations, you might not
        // want to validate individual results since the LLM responses and evaluation scores can jump around a bit
        // over time as your product (and the models used) evolve. You might not want individual evaluation tests to
        // 'fail' and block builds in your CI/CD pipelines when this happens. Instead, it might be better
        // to rely on the generated report and track the overall trends for evaluation scores across different
        // scenarios over time (and only fail individual builds in your CI/CD pipelines when there is a significant
        // drop in evaluation scores across multiple different tests). That said, there is some nuance here and the
        // choice of whether to validate individual results or not can vary depending on the specific use case.
        Validate(result);

        // At this point, the <see cref="scenarioRun"/> object will be disposed and the evaluation result for the
        // evaluation will be stored to the (disk-based) result store that's configured in
        // <see cref="s_defaultReportingConfiguration"/>.
    }
}
