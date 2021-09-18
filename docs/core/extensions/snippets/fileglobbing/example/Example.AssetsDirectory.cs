using System;
using Microsoft.Extensions.FileSystemGlobbing;

static partial class Example
{
    internal static void AssetsDirectory()
    {
        Console.WriteLine("AssetsDirectory:");

        // <AssetsDirectory>
        Matcher matcher = new();
        matcher.AddInclude("**/assets/**/*");

        foreach (string file in matcher.GetResultsInFullPath("parent"))
        {
            Console.WriteLine(file);
        }
        // </AssetsDirectory>

        Console.WriteLine();
    }
}
