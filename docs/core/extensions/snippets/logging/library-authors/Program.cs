using Logging.LibraryAuthors;
using Microsoft.Extensions.Logging;

LibraryConfiguration.SetLoggerFactory(
    LoggerFactory.Create(
        builder => builder.AddConsole()));

var service = new NonDiExampleService();

service.ProcessProductSale(new(), 7);
