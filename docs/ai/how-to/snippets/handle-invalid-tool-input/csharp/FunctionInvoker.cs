using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.Text.Json;

IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

// <BasicInvoker>
IChatClient innerClient = new OpenAIClient(key).GetChatClient(model ?? "gpt-4o").AsIChatClient();

var functionInvokingClient = new FunctionInvokingChatClient(innerClient)
{
    FunctionInvoker = async (context, cancellationToken) =>
    {
        try
        {
            // Invoke the function normally
            return await context.Function.InvokeAsync(context.Arguments, cancellationToken);
        }
        catch (JsonException ex)
        {
            // Catch JSON serialization errors and provide helpful feedback
            return $"Error: Unable to parse the function arguments. {ex.Message}. " +
                   "Please check the parameter types and try again.";
        }
        catch (ArgumentException ex)
        {
            // Catch validation errors and provide specific feedback
            return $"Error: Invalid argument - {ex.Message}";
        }
        catch (Exception ex)
        {
            // Catch all other errors
            return $"Error: Function execution failed - {ex.Message}";
        }
    }
};

IChatClient client = new ChatClientBuilder(functionInvokingClient).Build();

var chatOptions = new ChatOptions
{
    Tools = [AIFunctionFactory.Create((string location, int temperature) =>
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location cannot be empty", nameof(location));
        }
        return $"Recorded temperature of {temperature}°C for {location}";
    },
    "record_temperature",
    "Records the temperature for a location")]
};

List<ChatMessage> chatHistory = [
    new(ChatRole.System, "You are a weather data recorder."),
    new(ChatRole.User, "Record the temperature as 25 degrees for London")
];

ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
Console.WriteLine($"Assistant >>> {response.Text}");
// </BasicInvoker>

// <RetryInvoker>
IChatClient innerClient2 = new OpenAIClient(key).GetChatClient(model ?? "gpt-4o").AsIChatClient();

var retryClient = new FunctionInvokingChatClient(innerClient2)
{
    FunctionInvoker = async (context, cancellationToken) =>
    {
        try
        {
            return await context.Function.InvokeAsync(context.Arguments, cancellationToken);
        }
        catch (RetryableException ex)
        {
            // Return error message to the AI model to help it retry with valid input
            return $"Error: {ex.Message}. Please provide valid input and retry.";
        }
        catch (JsonException ex)
        {
            // Return JSON parsing error to help the AI correct the format
            return $"Error: Invalid JSON format - {ex.Message}. " +
                   "Please check the parameter types match the function signature and retry.";
        }
        catch (ArgumentException ex)
        {
            // Return validation error to help the AI provide correct values
            return $"Error: Invalid argument - {ex.Message}. Please correct the input and retry.";
        }
        catch (Exception ex)
        {
            // Don't provide detailed info for unexpected errors
            return $"Error: Function execution failed - {ex.Message}";
        }
    }
};

IChatClient retryClientBuilt = new ChatClientBuilder(retryClient).Build();

var retryOptions = new ChatOptions
{
    Tools = [AIFunctionFactory.Create((decimal amount, string currency) =>
    {
        // Validate the currency code
        var validCurrencies = new[] { "USD", "EUR", "GBP", "JPY" };
        if (!validCurrencies.Contains(currency.ToUpper()))
        {
            throw new RetryableException(
                $"Invalid currency '{currency}'. Valid currencies are: {string.Join(", ", validCurrencies)}");
        }
        
        if (amount <= 0)
        {
            throw new RetryableException("Amount must be greater than 0");
        }

        return $"Converted {amount} {currency.ToUpper()}";
    },
    "convert_currency",
    "Converts an amount from one currency to another")]
};

List<ChatMessage> retryHistory = [
    new(ChatRole.System, "You are a currency converter assistant."),
    new(ChatRole.User, "Convert 100 dollars to euros")
];

ChatResponse retryResponse = await retryClientBuilt.GetResponseAsync(retryHistory, retryOptions);
Console.WriteLine($"Assistant >>> {retryResponse.Text}");
// </RetryInvoker>

// Custom exception for retry scenarios
class RetryableException : Exception
{
    public RetryableException(string message) : base(message) { }
}
