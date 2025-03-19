using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Evaluation;
using Microsoft.Extensions.AI.Evaluation.Quality;
using Microsoft.Extensions.Configuration;

namespace TestAI;

[TestClass]
public sealed class MyTests
{
    // <SnippetPrivateMembers>
    private static ChatConfiguration? s_chatConfiguration;
    private static IList<ChatMessage> s_messages = [
        new ChatMessage(
            ChatRole.System,
            """
            You're an AI assistant that can answer questions related to astronomy.
            Keep your responses concise and try to stay under 100 words.
            Use the imperial measurement system for all measurements in your response.
            """),
        new ChatMessage(
            ChatRole.User,
            "How far is the planet Venus from Earth at its closest and furthest points?")];
    private static ChatResponse s_response = new();
    // </SnippetPrivateMembers>

    // <SnippetInitialize>
    [ClassInitialize]
    public static async Task InitializeAsync(TestContext _)
    {
        /// Set up the <see cref="ChatConfiguration"/>,
        /// which includes the <see cref="IChatClient"/> that the
        /// evaluator uses to communicate with the model.
        s_chatConfiguration = GetAzureOpenAIChatConfiguration();

        var chatOptions =
            new ChatOptions
            {
                Temperature = 0.0f,
                ResponseFormat = ChatResponseFormat.Text
            };

        // Fetch the response to be evaluated
        // and store it in a static variable.
        s_response = await s_chatConfiguration.ChatClient.GetResponseAsync(s_messages, chatOptions);
    }
    // </SnippetInitialize>

    // <SnippetGetChatConfig>
    private static ChatConfiguration GetAzureOpenAIChatConfiguration()
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<MyTests>().Build();

        string endpoint = config["AZURE_OPENAI_ENDPOINT"];
        string model = config["AZURE_OPENAI_GPT_NAME"];
        string tenantId = config["AZURE_TENANT_ID"];

        // Get a chat client for the Azure OpenAI endpoint.
        AzureOpenAIClient azureClient =
            new(
                new Uri(endpoint),
                new DefaultAzureCredential(new DefaultAzureCredentialOptions() { TenantId = tenantId }));
        IChatClient client = azureClient.AsChatClient(modelId: model);

        return new ChatConfiguration(client);
    }
    // </SnippetGetChatConfig>

    // <SnippetTestCoherence>
    [TestMethod]
    public async Task TestCoherence()
    {
        IEvaluator coherenceEvaluator = new CoherenceEvaluator();
        EvaluationResult result = await coherenceEvaluator.EvaluateAsync(
            s_messages,
            s_response,
            s_chatConfiguration);

        /// Retrieve the score for coherence from the <see cref="EvaluationResult"/>.
        NumericMetric coherence = result.Get<NumericMetric>(CoherenceEvaluator.CoherenceMetricName);

        // Validate the default interpretation
        // for the returned coherence metric.
        Assert.IsFalse(coherence.Interpretation!.Failed);
        Assert.IsTrue(coherence.Interpretation.Rating is EvaluationRating.Good or EvaluationRating.Exceptional);

        // Validate that no diagnostics are present
        // on the returned coherence metric.
        Assert.IsFalse(coherence.ContainsDiagnostics());
    }
    // </SnippetTestCoherence>
}
