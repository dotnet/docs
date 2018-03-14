//<Snippet1>
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Build.BuildEngine;

namespace BuildAProjectCS
{
    class Program
    {       
        static void Main(string[] args)
        {
            // Instantiate a new Engine object
            Engine engine = new Engine();

            // Point to the path that contains the .NET Framework 2.0 CLR and tools
            engine.BinPath = @"c:\windows\microsoft.net\framework\v2.0.xxxxx";
            

            // Instantiate a new FileLogger to generate build log
            FileLogger logger = new FileLogger();

            // Set the logfile parameter to indicate the log destination
            logger.Parameters = @"logfile=C:\temp\build.log";

            // Register the logger with the engine
            engine.RegisterLogger(logger);

            // Build a project file
            bool success = engine.BuildProjectFile(@"c:\temp\validate.proj");

            //Unregister all loggers to close the log file
            engine.UnregisterAllLoggers();

            if (success)
                Console.WriteLine("Build succeeded.");
            else
                Console.WriteLine(@"Build failed. View C:\temp\build.log for details");

        }
    }
}
//</Snippet1>