// <SnippetUsingDirectives>
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Quality;
// </SnippetUsingDirectives>

namespace TestAIWithReporting;

[TestClass]
public sealed class MyTests
{
    // <SnippetTestContext>
    // The value of the TestContext property is populated by MSTest.
    public TestContext? TestContext { get; set; }
    // </SnippetTestContext>

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
            new(
                new Uri(endpoint),
                new DefaultAzureCredential(new DefaultAzureCredentialOptions() { TenantId = tenantId }));
        IChatClient client = azureClient.GetChatClient(deploymentName: model).AsIChatClient();

        // Create an instance of <see cref="ChatConfiguration"/>
        // to communicate with the LLM.
        return new ChatConfiguration(client);
    }
    // </SnippetGetChatConfig>

    // <SnippetReportingSetup>
    private string ScenarioName => $"{TestContext!.FullyQualifiedTestClassName}.{TestContext.TestName}";

    private static string ExecutionName => $"{DateTime.Now:yyyyMMddTHHmmss}";

    private static readonly ReportingConfiguration s_defaultReportingConfiguration =
        DiskBasedReportingConfiguration.Create(
            storageRootPath: "C:\\TestReports",
            evaluators: GetEvaluators(),
            chatConfiguration: GetAzureOpenAIChatConfiguration(),
            enableResponseCaching: true,
            executionName: ExecutionName);
    // </SnippetReportingSetup>

    // <SnippetGetEvaluators>
    private static IEnumerable<IEvaluator> GetEvaluators()
    {
        IEvaluator relevanceEvaluator = new RelevanceEvaluator();
        IEvaluator coherenceEvaluator = new CoherenceEvaluator();
        IEvaluator wordCountEvaluator = new WordCountEvaluator();

        return [relevanceEvaluator, coherenceEvaluator, wordCountEvaluator];
    }
    // </SnippetGetEvaluators>

    // <SnippetGetResponse>
    private static async Task<(IList<ChatMessage> Messages, ChatResponse ModelResponse)> GetAstronomyConversationAsync(
        IChatClient chatClient,
        string astronomyQuestion)
    {
        const string SystemPrompt =
            """
            You're an AI assistant that can answer questions related to astronomy.
            Keep your responses concise and under 100 words.
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

        ChatResponse response = await chatClient.GetResponseAsync(messages, chatOptions);
        return (messages, response);
    }
    // </SnippetGetResponse>

    // <SnippetValidate>
    /// <summary>
    /// Runs basic validation on the supplied <see cref="EvaluationResult"/>.
    /// </summary>
    private static void Validate(EvaluationResult result)
    {
        // Retrieve the score for relevance from the <see cref="EvaluationResult"/>.
        NumericMetric relevance =
            result.Get<NumericMetric>(RelevanceEvaluator.RelevanceMetricName);
        Assert.IsFalse(relevance.Interpretation!.Failed, relevance.Reason);
        Assert.IsTrue(relevance.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        // Retrieve the score for coherence from the <see cref="EvaluationResult"/>.
        NumericMetric coherence =
            result.Get<NumericMetric>(CoherenceEvaluator.CoherenceMetricName);
        Assert.IsFalse(coherence.Interpretation!.Failed, coherence.Reason);
        Assert.IsTrue(coherence.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        // Retrieve the word count from the <see cref="EvaluationResult"/>.
        NumericMetric wordCount = result.Get<NumericMetric>(WordCountEvaluator.WordCountMetricName);
        Assert.IsFalse(wordCount.Interpretation!.Failed, wordCount.Reason);
        Assert.IsTrue(wordCount.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);
        Assert.IsFalse(wordCount.ContainsDiagnostics());
        Assert.IsTrue(wordCount.Value > 5 && wordCount.Value <= 100);
    }
    // </SnippetValidate>

    // <SnippetTestMethod>
    [TestMethod]
    public async Task SampleAndEvaluateResponse()
    {
        // Create a <see cref="ScenarioRun"/> with the scenario name
        // set to the fully qualified name of the current test method.
        await using ScenarioRun scenarioRun =
            await s_defaultReportingConfiguration.CreateScenarioRunAsync(
                ScenarioName,
                additionalTags: ["Moon"]);

        // Use the <see cref="IChatClient"/> that's included in the
        // <see cref="ScenarioRun.ChatConfiguration"/> to get the LLM response.
        (IList<ChatMessage> messages, ChatResponse modelResponse) = await GetAstronomyConversationAsync(
            chatClient: scenarioRun.ChatConfiguration!.ChatClient,
            astronomyQuestion: "How far is the Moon from the Earth at its closest and furthest points?");

        // Run the evaluators configured in <see cref="s_defaultReportingConfiguration"/> against the response.
        EvaluationResult result = await scenarioRun.EvaluateAsync(messages, modelResponse);

        // Run some basic validation on the evaluation result.
        Validate(result);
    }
    // </SnippetTestMethod>
}
