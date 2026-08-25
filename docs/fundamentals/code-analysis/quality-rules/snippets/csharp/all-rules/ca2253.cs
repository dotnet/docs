using Microsoft.Extensions.Logging;

namespace ca2253
{
    //<snippet1>
    public class UserService
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public void Add(string firstName, string lastName)
        {
            // This code violates the rule.
            _logger.LogInformation("Adding user with first name {0} and last name {1}", firstName, lastName);

            // This code satisfies the rule.
            _logger.LogInformation("Adding user with first name {FirstName} and last name {LastName}", firstName, lastName);

            // ...
        }
    }
    //</snippet1>
}
