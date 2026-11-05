// <DiscoverAndRun>
using System.Text.Json;
using Microsoft.Testing.Platform.ServerMode.Client;

namespace TestClientSample;

public static class TestClient
{
    public static async Task<int> DiscoverAndRunAsync(
        string testApplicationPath,
        CancellationToken cancellationToken = default)
    {
        string path = Path.GetFullPath(testApplicationPath);
        var testUids = new HashSet<string>(StringComparer.Ordinal);

        using (IMtpServerClient client = await MtpServerClient.LaunchAsync(
            path, cancellationToken: cancellationToken))
        {
            try
            {
                MtpServerCapabilities capabilities =
                    await client.InitializeAsync(cancellationToken);
                if (capabilities.MultiConnectionProvider)
                {
                    throw new NotSupportedException("A passive controller connection can't discover or run tests.");
                }

                if (!capabilities.SupportsDiscovery)
                {
                    throw new NotSupportedException("The test application doesn't support discovery.");
                }

                client.LogReceived += (_, log) => Console.Error.WriteLine(log.Message);
                client.TestNodesUpdated += (_, update) =>
                {
                    foreach (MtpTestNodeUpdate change in update.Changes)
                    {
                        Console.WriteLine(JsonSerializer.Serialize(change.Node));
                        if (change.NodeType != "group"
                            && change.ExecutionState == "discovered"
                            && change.Uid is string uid)
                        {
                            testUids.Add(uid);
                        }
                    }
                };

                await client.DiscoverTestsAsync(cancellationToken);
                await client.ExitAsync(cancellationToken);
            }
            finally
            {
                await client.ShutdownAsync();
            }
        }

        if (testUids.Count == 0)
        {
            Console.Error.WriteLine("No tests were discovered.");
            return 8;
        }

        var completedUids = new HashSet<string>(StringComparer.Ordinal);
        bool hasUnsuccessfulResult = false;
        using IMtpServerClient runClient = await MtpServerClient.LaunchAsync(
            path, cancellationToken: cancellationToken);
        try
        {
            MtpServerCapabilities capabilities =
                await runClient.InitializeAsync(cancellationToken);
            if (capabilities.MultiConnectionProvider)
            {
                throw new NotSupportedException("A passive controller connection can't discover or run tests.");
            }

            runClient.LogReceived += (_, log) => Console.Error.WriteLine(log.Message);
            runClient.TestNodesUpdated += (_, update) =>
            {
                foreach (MtpTestNodeUpdate change in update.Changes)
                {
                    Console.WriteLine(JsonSerializer.Serialize(change.Node));
                    if (change.Uid is string uid
                        && testUids.Contains(uid)
                        && change.ExecutionState is string state
                        && state is not ("discovered" or "in-progress")
                        && (!change.Node.TryGetValue("retry.is-superseded", out object? superseded)
                            || superseded is not true))
                    {
                        completedUids.Add(uid);
                        hasUnsuccessfulResult |= state is not ("passed" or "skipped");
                    }
                }
            };

            MtpRunResult result = await runClient.RunTestsAsync(testUids, cancellationToken);
            foreach (MtpAttachment artifact in result.Artifacts)
            {
                Console.WriteLine($"Artifact: {artifact.Uri}");
            }

            await runClient.ExitAsync(cancellationToken);

            if (hasUnsuccessfulResult || !testUids.All(completedUids.Contains))
            {
                Console.Error.WriteLine("A selected test failed or didn't report a final result.");
                return 2;
            }

            return 0;
        }
        finally
        {
            await runClient.ShutdownAsync();
        }
    }
}
// </DiscoverAndRun>
