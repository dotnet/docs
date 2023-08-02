using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using ILoggerFactory loggerFactory = LoggerFactory.Create(
    builder =>
    builder.AddJsonConsole(
        options =>
        options.JsonWriterOptions = new JsonWriterOptions()
        {
            Indented = true
        }));

NullLogger nullLogger = NullLogger.Instance;
NullLoggerFactory nullLoggerFactory = NullLoggerFactory.Instance;
NullLoggerProvider nullLoggerProvider = NullLoggerProvider.Instance;
