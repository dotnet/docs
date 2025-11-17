using System;
using System.IO;

namespace ca1031
{
    //<snippet1>
    // Creates two violations of the rule.
    public class GenericExceptionsCaught
    {
        private readonly FileStream? _inStream;
        private readonly FileStream? _outStream;

        public GenericExceptionsCaught(string inFile, string outFile)
        {
            try
            {
                _inStream = File.Open(inFile, FileMode.Open);
            }
            catch (SystemException)
            {
                Console.WriteLine($"Unable to open {inFile}.");
            }

            try
            {
                _outStream = File.Open(outFile, FileMode.Open);
            }
            catch
            {
                Console.WriteLine($"Unable to open {outFile}.");
            }
        }
    }

    public class GenericExceptionsCaughtFixed
    {
        private readonly FileStream? _inStream;
        private readonly FileStream _outStream;

        public GenericExceptionsCaughtFixed(string inFile, string outFile)
        {
            try
            {
                _inStream = File.Open(inFile, FileMode.Open);
            }

            // Fix the first violation by catching a specific exception.
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Unable to open {inFile}.");
            }

            // For functionally equivalent code, also catch 
            // remaining exceptions that may be thrown by File.Open

            try
            {
                _outStream = File.Open(outFile, FileMode.Open);
            }

            // Fix the second violation by rethrowing the generic 
            // exception at the end of the catch block.
            catch
            {
                Console.WriteLine($"Unable to open {outFile}.");
                throw;
            }
        }
    }
    //</snippet1>
}
