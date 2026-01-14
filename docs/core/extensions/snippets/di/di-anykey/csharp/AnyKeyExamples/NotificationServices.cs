namespace AnyKeyExamples;

// <EmailService>
public class EmailService : INotificationService
{
    public Task SendAsync(string message)
    {
        Console.WriteLine($"Email: {message}");
        return Task.CompletedTask;
    }
}
// </EmailService>

// <SmsService>
public class SmsService : INotificationService
{
    public Task SendAsync(string message)
    {
        Console.WriteLine($"SMS: {message}");
        return Task.CompletedTask;
    }
}
// </SmsService>

// <PushService>
public class PushService : INotificationService
{
    public Task SendAsync(string message)
    {
        Console.WriteLine($"Push: {message}");
        return Task.CompletedTask;
    }
}
// </PushService>

// <LoggingService>
public class LoggingService : INotificationService
{
    public Task SendAsync(string message)
    {
        Console.WriteLine($"Log: {message}");
        return Task.CompletedTask;
    }
}
// </LoggingService>
