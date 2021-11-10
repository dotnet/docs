using System;
using System.Collections.Generic;

public class ExampleSystem
{
    public static void KeyValuePair()
    {
        // <KeyValuePair>
        Dictionary<string, int> snapshotCommitMap = new(StringComparer.OrdinalIgnoreCase)
        {
            ["https://github.com/dotnet/docs"] = 16_465,
            ["https://github.com/dotnet/runtime"] = 114_223,
            ["https://github.com/dotnet/installer"] = 22_436,
            ["https://github.com/dotnet/roslyn"] = 79_484,
            ["https://github.com/dotnet/aspnetcore"] = 48_386
        };

        foreach (var (repo, commitCount) in snapshotCommitMap)
        {
            Console.WriteLine(
                $"The {repo} repository had {commitCount:N0} commits as of November 10th, 2021.");
        }
        // </KeyValuePair>
    }
}
