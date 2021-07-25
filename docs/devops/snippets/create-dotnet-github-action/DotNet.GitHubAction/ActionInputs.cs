using System;
using CommandLine;

namespace DotNet.GitHubAction
{
    public class ActionInputs
    {
        string _repositoryName = null!;
        string _branchName = null!;

        public ActionInputs()
        {
            if (Environment.GetEnvironmentVariable("GREETINGS") is { Length: > 0 } greetings)
            {
                Console.WriteLine(greetings);
            }
        }

        [Option('o', "owner",
            Required = true,
            HelpText = "The owner, for example: \"dotnet\". Assign from `github.repository_owner`.")]
        public string Owner { get; set; } = null!;

        [Option('n', "name",
            Required = true,
            HelpText = "The repository name, for example: \"samples\". Assign from `github.repository`.")]
        public string Name
        {
            get => _repositoryName;
            set => ParseAndAssign(value, str => _repositoryName = str);
        }

        [Option('b', "branch",
            Required = true,
            HelpText = "The branch name, for example: \"refs/heads/main\". Assign from `github.ref`.")]
        public string Branch
        {
            get => _branchName;
            set => ParseAndAssign(value, str => _branchName = str);
        }

        [Option('d', "dir",
            Required = true,
            HelpText = "The root directory to start recursive searching from.")]
        public string Directory { get; set; } = null!;

        [Option('w', "workspace",
            Required = true,
            HelpText = "The workspace directory, or repository root directory.")]
        public string WorkspaceDirectory { get; set; } = null!;

        static void ParseAndAssign(string? value, Action<string> assign)
        {
            if (value is { Length: > 0 } && assign is not null)
            {
                assign(value.Split("/")[^1]);
            }
        }
    }
}
