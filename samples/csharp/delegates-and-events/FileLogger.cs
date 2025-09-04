using System;
using System.IO;

namespace DelegatesAndEvents
{
/// <summary>
/// A logger that writes messages to a file.
/// </summary>
public class FileLogger
{
    private readonly string logPath;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileLogger"/> class.
    /// </summary>
    /// <param name="path">The path to the log file.</param>
    public FileLogger(string path)
    {
        logPath = path;
        Logger.WriteMessage += LogMessage;
    }

    /// <summary>
    /// Detaches the logger from the logging system.
    /// </summary>
    public void DetachLog() => Logger.WriteMessage -= LogMessage;
    // make sure this can't throw.
    private void LogMessage(string msg)
    {
        try {
            using (var log = File.AppendText(logPath))
            {
                log.WriteLine(msg);
                log.Flush();
            }
        } catch (Exception)
        {
            // Hmm. We caught an exception while 
            // logging. We can't really log the 
            // problem (since it's the log that's failing).
            // So, while normally, catching an exception
            // and doing nothing isn't wise, it's really the
            // only reasonable option here.
        }
    }
}
}