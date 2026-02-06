using Azure;
using Azure.AI.OpenAI;
using Microsoft.Agents.AI;
using OpenAI.Chat;

string endpoint = "https://<your-endpoint>.openai.azure.com/";
string apiKey = "<your-api-key>";

AIAgent agent = new AzureOpenAIClient(
    new Uri(endpoint),
    new AzureKeyCredential(apiKey))
        .GetChatClient("gpt-4o")
        .AsAIAgent();

// Create a session to maintain conversation state.
AgentSession session = await agent.GetNewSessionAsync();

while (true)
{
    // Get user prompt.
    Console.WriteLine("Your prompt:");
    string? userInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userInput))
        break;

    // Send prompt to agent and stream response.
    Console.WriteLine("AI response:");
    await foreach (AgentResponseUpdate update in agent.RunStreamingAsync(userInput, session))
    {
        Console.Write(update.Text);
    }
    Console.WriteLine();
}
