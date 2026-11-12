// <GlobalUsingConsumer>
namespace MyApp.Services;

class GlobalMessage
{
    public static string CreateMessage()
    {
        StringBuilder message = new();
        message.Append("Hello from a global import!");
        return message.ToString();
    }
}
// </GlobalUsingConsumer>
