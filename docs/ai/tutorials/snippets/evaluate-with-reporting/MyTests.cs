using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using Microsoft.Extensions.AI.Evaluation.Reporting;
using Microsoft.Extensions.AI.Evaluation.Reporting.Storage;

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
            chatConfiguration: GetOllamaChatConfiguration(),
            enableResponseCaching: true,
            executionName: ExecutionName);

    private static IEnumerable<IEvaluator> GetEvaluators()
    {
        var rtcOptions = new RelevanceTruthAndCompletenessEvaluatorOptions(includeReasoning: true);
        IEvaluator rtcEvaluator = new RelevanceTruthAndCompletenessEvaluator(rtcOptions);
        //IEvaluator measurementSystemEvaluator = new MeasurementSystemEvaluator();
        //IEvaluator wordCountEvaluator = new WordCountEvaluator();

        return [rtcEvaluator];
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
        /// Note that since we said 'includeReasoning: true' when creating the
        /// <see cref="RelevanceTruthAndCompletenessEvaluator"/> inside <see cref="GetEvaluators"/> above, the
        /// 'relevance', 'truth' and 'completeness' metrics will will each include a single informational diagnostic
        /// explaining the reasoning for the score. This diagnostic is included in the generated report and can be
        /// viewed by hovering over the corresponding metric's card in the report.

        /// Retrieve the score for relevance from the <see cref="EvaluationResult"/>.
        NumericMetric relevance =
            result.Get<NumericMetric>(RelevanceTruthAndCompletenessEvaluator.RelevanceMetricName);
        Assert.IsFalse(relevance.Interpretation!.Failed);
        Assert.IsTrue(relevance.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        /// Retrieve the score for truth from the <see cref="EvaluationResult"/>.
        NumericMetric truth = result.Get<NumericMetric>(RelevanceTruthAndCompletenessEvaluator.TruthMetricName);
        Assert.IsFalse(truth.Interpretation!.Failed);
        Assert.IsTrue(truth.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        /// Retrieve the score for completeness from the <see cref="EvaluationResult"/>.
        NumericMetric completeness =
            result.Get<NumericMetric>(RelevanceTruthAndCompletenessEvaluator.CompletenessMetricName);
        Assert.IsFalse(completeness.Interpretation!.Failed);
        Assert.IsTrue(completeness.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);
    }

    // <SnippetGetChatConfig>
    private static ChatConfiguration GetOllamaChatConfiguration()
    {
        // Get a chat client for the Ollama endpoint.
        IChatClient client =
            new OllamaChatClient(
                new Uri("http://localhost:11434"),
                modelId: "llama3.1");
        //modelId: "phi3:mini");

        return new ChatConfiguration(client);
    }
    // </SnippetGetChatConfig>

    [TestMethod]
    public async Task SampleAndEvaluateSingleResponse()
    {
        /// Use <see cref="s_defaultReportingConfiguration"/> to create a <see cref="ScenarioRun"/> with
        /// <see cref="ScenarioRun.ScenarioName"/> set to the fully qualified name of the current test method.
        await using ScenarioRun scenarioRun =
            await s_defaultReportingConfiguration.CreateScenarioRunAsync(this.ScenarioName);

        /// Get an LLM response to be evaluated. Note that we use the <see cref="IChatClient"/> that is included in the
        /// <see cref="ScenarioRun.ChatConfiguration"/> to get this response. Since the <see cref="scenarioRun"/> was
        /// created using <see cref="s_defaultReportingConfiguration"/>, and since response caching is turned on for
        /// <see cref="s_defaultReportingConfiguration"/>, the LLM response fetched using the <see cref="IChatClient"/>
        /// included in <see cref="ScenarioRun.ChatConfiguration"/> will be fetched:
        /// - directly from the LLM endpoint that was configured in
        ///   <see cref="s_defaultReportingConfiguration"/> in the very first run of the current test
        /// - from the (disk-based) response cache that was configured in <see cref="s_defaultReportingConfiguration"/>
        ///   in every subsequent run of the test, until the cached entry expires (in 14 days by default) and ends up
        ///   being refreshed
        var (messages, modelResponse) = await GetAstronomyConversationAsync(
            chatClient: scenarioRun.ChatConfiguration!.ChatClient,
            astronomyQuestion: "How far is the Moon from the Earth at its closest and furthest points?");

        /// Run the evaluators configured in <see cref="s_defaultReportingConfiguration"/> against the response. Since
        /// the <see cref="scenarioRun"/> was created using <see cref="s_defaultReportingConfiguration"/>, and since
        /// response caching is turned on for <see cref="s_defaultReportingConfiguration"/>, the evaluation will be:
        /// - performed using the the LLM endpoint that was configured in
        ///   <see cref="s_defaultReportingConfiguration"/> in the very first run of the current test
        /// - fetched from the (disk-based) response cache that was configured in
        ///   <see cref="s_defaultReportingConfiguration"/> in every subsequent run of the test, until the cached entry
        ///   expires (in 14 days by default) and ends up being refreshed
        EvaluationResult result = await scenarioRun.EvaluateAsync(messages, modelResponse);

        /// Run some basic validation on the evaluation result.
        /// 
        /// Note: This step is optional and mainly for demonstration purposes. In real-world evaluations, you may not
        /// want to validate individual results since the LLM responses and evaluation scores can jump around a bit
        /// over time as your product (and the models used) evolve. You may not want individual evaluation tests to
        /// 'fail' and block builds in your CI/CD pipelines when this happens. Instead, in such cases, it may be better
        /// to rely on the generated report and track the overall trends for evaluation scores across different
        /// scenarios over time (and only fail individual builds in your CI/CD pipelines when there is a significant
        /// drop in evaluation scores across multiple different tests). That said, there is some nuance here and the
        /// choice of whether to validate individual results or not can vary depending on the specific use case.
        Validate(result);

        /// At this point, the <see cref="scenarioRun"/> object will be disposed and the evaluation result for the
        /// above evaluation will be stored to the (disk-based) result store that is configured in
        /// <see cref="s_defaultReportingConfiguration"/>. You can inspect how the result is stored by navigating to the
        /// directory that you specified via the 'EVAL_SAMPLE_STORAGE_ROOT_PATH' environment variable.
    }
}
