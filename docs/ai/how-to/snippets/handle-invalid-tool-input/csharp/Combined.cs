using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.Text.Json;

IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

// <CombinedStrategies>
IChatClient innerClient = new OpenAIClient(key).GetChatClient(model ?? "gpt-4o-2024-08-06").AsIChatClient();

// Strategy 1: Custom error handling with retry logic
var functionInvokingClient = new FunctionInvokingChatClient(innerClient)
{
    // Strategy 2: Include detailed errors in development
    IncludeDetailedErrors = true,
    
    FunctionInvoker = async (context, cancellationToken) =>
    {
        try
        {
            return await context.Function.InvokeAsync(context.Arguments, cancellationToken);
        }
        catch (JsonException ex)
        {
            return $"JSON parsing error: {ex.Message}. " +
                   "Ensure all parameters match the expected types and retry.";
        }
        catch (ArgumentException ex)
        {
            return $"Validation error: {ex.Message}. Please correct the input and retry.";
        }
        catch (Exception ex)
        {
            return $"Unexpected error: {ex.Message}";
        }
    }
};

IChatClient client = new ChatClientBuilder(functionInvokingClient).Build();

// Strategy 3: Use strict schema mode for OpenAI
var bookingFunction = AIFunctionFactory.Create(
    (string hotelName, DateTime checkIn, DateTime checkOut, int guests) =>
    {
        if (checkOut <= checkIn)
        {
            throw new ArgumentException("Check-out date must be after check-in date");
        }
        if (guests < 1 || guests > 10)
        {
            throw new ArgumentException("Number of guests must be between 1 and 10");
        }
        
        int nights = (checkOut - checkIn).Days;
        return $"Booking confirmed at {hotelName} for {guests} guest(s), " +
               $"{nights} night(s) from {checkIn:yyyy-MM-dd} to {checkOut:yyyy-MM-dd}";
    },
    new AIFunctionFactoryOptions
    {
        Name = "book_hotel",
        Description = "Books a hotel room with check-in/out dates and number of guests",
        // Enable strict schema mode
        AdditionalProperties = new Dictionary<string, object?>
        {
            { "Strict", true }
        }
    });

var chatOptions = new ChatOptions
{
    Tools = [bookingFunction]
};

List<ChatMessage> chatHistory = [
    new(ChatRole.System, "You are a hotel booking assistant. " +
        "Always confirm all details before booking."),
    new(ChatRole.User, "Book a room at Grand Hotel for 2 guests, " +
        "checking in on January 15, 2026 and checking out on January 18, 2026")
];

ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);
Console.WriteLine($"Assistant >>> {response.Text}");
// </CombinedStrategies>
