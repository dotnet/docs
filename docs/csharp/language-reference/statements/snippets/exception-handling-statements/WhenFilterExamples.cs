using System;
using System.Collections.Generic;
using System.IO;

namespace ExceptionFilterExamples
{
    public static class WhenFilterExamples
    {
        // <ExceptionFilterVsIfElse>
        public static void DemonstrateStackUnwindingDifference()
        {
            var localVariable = "Important debugging info";
            
            try
            {
                ProcessWithExceptionFilter(localVariable);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("filter"))
            {
                // Exception filter: Stack not unwound yet.
                // localVariable is still accessible in debugger.
                // Call stack shows original throwing location.
                Console.WriteLine($"Caught with filter: {ex.Message}");
                Console.WriteLine($"Local variable accessible: {localVariable}");
            }
            
            try
            {
                ProcessWithTraditionalCatch(localVariable);
            }
            catch (InvalidOperationException ex)
            {
                // Traditional catch: Stack already unwound.
                // Some debugging information may be lost.
                if (ex.Message.Contains("traditional"))
                {
                    Console.WriteLine($"Caught with if: {ex.Message}");
                    Console.WriteLine($"Local variable accessible: {localVariable}");
                }
                else
                {
                    throw; // Re-throws and further modifies stack trace.
                }
            }
        }

        private static void ProcessWithExceptionFilter(string context)
        {
            throw new InvalidOperationException($"Exception for filter demo: {context}");
        }

        private static void ProcessWithTraditionalCatch(string context)
        {
            throw new InvalidOperationException($"Exception for traditional demo: {context}");
        }
        // </ExceptionFilterVsIfElse>

        // <MultipleConditionsExample>
        public static void HandleFileOperations(string filePath)
        {
            try
            {
                // Simulate file operation that might fail.
                ProcessFile(filePath);
            }
            catch (IOException ex) when (ex.Message.Contains("access denied"))
            {
                Console.WriteLine("File access denied. Check permissions.");
            }
            catch (IOException ex) when (ex.Message.Contains("not found"))
            {
                Console.WriteLine("File not found. Verify the path.");
            }
            catch (IOException ex) when (IsNetworkPath(filePath))
            {
                Console.WriteLine($"Network file operation failed: {ex.Message}");
            }
            catch (IOException)
            {
                Console.WriteLine("Other I/O error occurred.");
            }
        }

        private static void ProcessFile(string filePath)
        {
            // Simulate different types of file exceptions.
            if (filePath.Contains("denied"))
                throw new IOException("File access denied");
            if (filePath.Contains("missing"))
                throw new IOException("File not found");
            if (IsNetworkPath(filePath))
                throw new IOException("Network timeout occurred");
        }

        private static bool IsNetworkPath(string path)
        {
            return path.StartsWith(@"\\") || path.StartsWith("http");
        }
        // </MultipleConditionsExample>

        // <DebuggingAdvantageExample>
        public static void DemonstrateDebuggingAdvantage()
        {
            var contextData = new Dictionary<string, object>
            {
                ["RequestId"] = Guid.NewGuid(),
                ["UserId"] = "user123",
                ["Timestamp"] = DateTime.Now
            };

            try
            {
                // Simulate a deep call stack.
                Level1Method(contextData);
            }
            catch (Exception ex) when (LogAndFilter(ex, contextData))
            {
                // This catch block may never execute if LogAndFilter returns false.
                // But LogAndFilter can examine the exception while the stack is intact.
                Console.WriteLine("Exception handled after logging");
            }
        }

        private static void Level1Method(Dictionary<string, object> context)
        {
            Level2Method(context);
        }

        private static void Level2Method(Dictionary<string, object> context)
        {
            Level3Method(context);
        }

        private static void Level3Method(Dictionary<string, object> context)
        {
            throw new InvalidOperationException("Error in deep call stack");
        }

        private static bool LogAndFilter(Exception ex, Dictionary<string, object> context)
        {
            // This method runs before stack unwinding.
            // Full call stack and local variables are still available.
            Console.WriteLine($"Exception occurred: {ex.Message}");
            Console.WriteLine($"Request ID: {context["RequestId"]}");
            Console.WriteLine($"Full stack trace preserved: {ex.StackTrace}");
            
            // Return true to handle the exception, false to continue search.
            return ex.Message.Contains("deep call stack");
        }
        // </DebuggingAdvantageExample>
    }
}