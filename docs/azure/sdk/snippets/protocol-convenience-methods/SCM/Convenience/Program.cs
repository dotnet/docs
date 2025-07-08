using OpenAI.Chat;

// Create the client
ChatClient client = new(
    model: "gpt-4o-mini",
    credential: Environment.GetEnvironmentVariable("OPENAI_API_KEY")!);

// Call the convenience method
ChatCompletion completion = client.CompleteChat("What is Microsoft Azure?");

// Display the results
Console.WriteLine($"[{completion.Role}]: {completion}");
