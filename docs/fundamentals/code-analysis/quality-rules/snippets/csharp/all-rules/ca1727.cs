using Microsoft.Extensions.Logging;

namespace ca1727
{
    //<snippet1>
    public class UserService
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public void Create(string firstName, string lastName)
        {
            // This code violates the rule.
            _logger.LogInformation("Creating user {firstName} {lastName}", firstName, lastName);

            // This code satisfies the rule.
            _logger.LogInformation("Creating user {FirstName} {LastName}", firstName, lastName);
        }
    }
    //</snippet1>
}
