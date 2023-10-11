using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.ExceptionSummarization;

// Add exception summarization services.
var services = new ServiceCollection()
    .AddExceptionSummarizer(static builder => builder.AddHttpProvider());

var provider = services.BuildServiceProvider();

// Get the exception summarizer.
var summarizer = provider.GetRequiredService<IExceptionSummarizer>();

foreach (var exception in new Exception[]
    {
        new OperationCanceledException("Operation cancelled..."),
        new TaskCanceledException("Task cancelled..."),
        new SocketException(10_024, "Too many sockets open..."),
        new WebException("Keep alive failure...",
            WebExceptionStatus.KeepAliveFailure)
    })
{
    // Summarize the exception.
    var summary = summarizer.Summarize(exception);

    Console.WriteLine(summary);
}

Console.ReadLine();

// Sample output:
//   OperationCanceledException:TaskTimeout:Unknown
//   TaskCanceledException:TaskTimeout:Unknown
//   SocketException:TooManyOpenSockets:Unknown
//   WebException:KeepAliveFailure:Unknown
