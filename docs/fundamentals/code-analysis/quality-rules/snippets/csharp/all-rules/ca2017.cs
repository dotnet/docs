using Microsoft.Extensions.Logging;

namespace ca2017
{
    //<snippet1>
    public class LoggingExample
    {
        private readonly ILogger<LoggingExample> _logger;

        public LoggingExample(ILogger<LoggingExample> logger)
        {
            _logger = logger;
        }

        public void ExampleMethod()
        {
            string name = "Alice";
            int age = 30;

            // Violates CA2017: Too few arguments for placeholders
            _logger.LogInformation("User {Name} is {Age} years old and lives in {City}", name, age);

            // Violates CA2017: Too many arguments for placeholders  
            _logger.LogError("Error occurred: {Message}", "Something went wrong", "Extra argument");

            // Correct usage: Matching number of placeholders and arguments
            _logger.LogInformation("User {Name} is {Age} years old", name, age);

            // Correct usage: No placeholders, no arguments
            _logger.LogInformation("Application started");

            // Correct usage: Single placeholder, single argument
            _logger.LogWarning("Failed to process {FileName}", "document.txt");
        }
    }
    //</snippet1>
}