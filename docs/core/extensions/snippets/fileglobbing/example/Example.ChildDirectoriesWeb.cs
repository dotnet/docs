using System;
using Microsoft.Extensions.FileSystemGlobbing;

static partial class Example
{
    internal static void ChildDirectoriesWeb()
    {
        Console.WriteLine("ChildDirectoriesWeb:");

        // <ChildDirectoriesWeb>
        Matcher matcher = new();
        matcher.AddInclude("**/*child/**/*");
        matcher.AddExcludePatterns(
            new[]
            {
                "**/*.md", "**/*.text", "**/*.mtext"
            });

        foreach (string file in matcher.GetResultsInFullPath("parent"))
        {
            Console.WriteLine(file);
        }
        // </ChildDirectoriesWeb>

        Console.WriteLine();
    }
}
