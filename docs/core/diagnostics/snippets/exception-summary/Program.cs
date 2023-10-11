using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.ExceptionSummarization;

var services = new ServiceCollection()
    .AddExceptionSummarizer();

var provider = services.BuildServiceProvider();

var summarizer = provider.GetRequiredService<IExceptionSummarizer>();

var exception = new ApplicationException("This is an example exception!");

var summary = summarizer.Summarize(exception);

Console.WriteLine(summary); 
