// <UsingDirective>
using System.Text;

namespace MyApp.Services;

class Imports
{
    public static string CreateMessage()
    {
        StringBuilder message = new();
        message.Append("Hello from a file import!");
        return message.ToString();
    }
}
// </UsingDirective>
