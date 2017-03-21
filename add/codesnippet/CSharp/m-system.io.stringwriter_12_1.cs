        // Use the three overloads of the Write method that are 
        // overridden by the StringWriter class.
        strWriter.Write("file path characters are: ");
        strWriter.Write(
            Path.InvalidPathChars, 0, Path.InvalidPathChars.Length);
        strWriter.Write('.');