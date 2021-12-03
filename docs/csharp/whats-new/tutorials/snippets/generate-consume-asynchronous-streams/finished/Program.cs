using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Octokit;
using System.Runtime.CompilerServices;

namespace GitHubActivityReport
{
    public class GraphQLRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("variables")]
        public IDictionary<string, object> Variables { get; } = new Dictionary<string, object>();

        public string ToJsonText() =>
            JsonConvert.SerializeObject(this);
    }

    class Program
    {
        internal const string PagedIssueQuery =
@"query ($repo_name: String!,  $start_cursor:String) {
  repository(owner: ""dotnet"", name: $repo_name) {
    issues(last: 25, before: $start_cursor)
     {
        totalCount
        pageInfo {
          hasPreviousPage
          startCursor
        }
        nodes {
          title
          number
          createdAt
        }
      }
    }
  }
";

        static async Task Main(string[] args)
        {
            //Follow these steps to create a GitHub Access Token
            // https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/#creating-a-token
            //Select the following permissions for your GitHub Access Token:
            // - repo:status
            // - public_repo
            // Replace the 3rd parameter to the following code with your GitHub access token.
            var key = GetEnvVariable("GitHubKey",
            "You must store your GitHub key in the 'GitHubKey' environment variable",
            "");

            var client = new GitHubClient(new Octokit.ProductHeaderValue("IssueQueryDemo"))
            {
                Credentials = new Octokit.Credentials(key)
            };

            // <SnippetEnumerateAsyncStream>
            int num = 0;
            await foreach (var issue in RunPagedQueryAsync(client, PagedIssueQuery, "docs"))
            {
                Console.WriteLine(issue);
                Console.WriteLine($"Received {++num} issues in total");
            }
            // </SnippetEnumerateAsyncStream>

        }

        // <SnippetEnumerateWithCancellation>
        private static async Task EnumerateWithCancellation(GitHubClient client)
        {
            int num = 0;
            var cancellation = new CancellationTokenSource();
            await foreach (var issue in RunPagedQueryAsync(client, PagedIssueQuery, "docs")
                .WithCancellation(cancellation.Token))
            {
                Console.WriteLine(issue);
                Console.WriteLine($"Received {++num} issues in total");
            }
        }
        // </SnippetEnumerateWithCancellation>

        // <SnippetGenerateAsyncStream>
        // <SnippetUpdateSignature>
        private static async IAsyncEnumerable<JToken> RunPagedQueryAsync(GitHubClient client,
            string queryText, string repoName)
        // </SnippetUpdateSignature>
        {
            var issueAndPRQuery = new GraphQLRequest
            {
                Query = queryText
            };
            issueAndPRQuery.Variables["repo_name"] = repoName;

            bool hasMorePages = true;
            int pagesReturned = 0;
            int issuesReturned = 0;

            // Stop with 10 pages, because these are large repos:
            while (hasMorePages && (pagesReturned++ < 10))
            {
                var postBody = issueAndPRQuery.ToJsonText();
                var response = await client.Connection.Post<string>(new Uri("https://api.github.com/graphql"),
                    postBody, "application/json", "application/json");

                JObject results = JObject.Parse(response.HttpResponse.Body.ToString());

                int totalCount = (int)issues(results)["totalCount"];
                hasMorePages = (bool)pageInfo(results)["hasPreviousPage"];
                issueAndPRQuery.Variables["start_cursor"] = pageInfo(results)["startCursor"].ToString();
                issuesReturned += issues(results)["nodes"].Count();

                // <SnippetYieldReturnPage>
                foreach (JObject issue in issues(results)["nodes"])
                    yield return issue;
                // </SnippetYieldReturnPage>
            }

            JObject issues(JObject result) => (JObject)result["data"]["repository"]["issues"];
            JObject pageInfo(JObject result) => (JObject)issues(result)["pageInfo"];
        }
        // </SnippetGenerateAsyncStream>

        // <SnippetGenerateWithCancellation>
        private static async IAsyncEnumerable<JToken> RunPagedQueryAsync(GitHubClient client,
            string queryText, string repoName, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            var issueAndPRQuery = new GraphQLRequest
            {
                Query = queryText
            };
            issueAndPRQuery.Variables["repo_name"] = repoName;

            bool hasMorePages = true;
            int pagesReturned = 0;
            int issuesReturned = 0;

            // Stop with 10 pages, because these are large repos:
            while (hasMorePages && (pagesReturned++ < 10))
            {
                var postBody = issueAndPRQuery.ToJsonText();
                var response = await client.Connection.Post<string>(new Uri("https://api.github.com/graphql"),
                    postBody, "application/json", "application/json");

                JObject results = JObject.Parse(response.HttpResponse.Body.ToString());

                int totalCount = (int)issues(results)["totalCount"];
                hasMorePages = (bool)pageInfo(results)["hasPreviousPage"];
                issueAndPRQuery.Variables["start_cursor"] = pageInfo(results)["startCursor"].ToString();
                issuesReturned += issues(results)["nodes"].Count();

                // <SnippetYieldReturnPage>
                foreach (JObject issue in issues(results)["nodes"])
                    yield return issue;
                // </SnippetYieldReturnPage>
            }

            JObject issues(JObject result) => (JObject)result["data"]["repository"]["issues"];
            JObject pageInfo(JObject result) => (JObject)issues(result)["pageInfo"];
        }
        // </SnippetGenerateWithCancellation>

        private static string GetEnvVariable(string item, string error, string defaultValue)
        {
            var value = Environment.GetEnvironmentVariable(item);
            if (string.IsNullOrWhiteSpace(value))
            {
                if (!string.IsNullOrWhiteSpace(defaultValue))
                {
                    return defaultValue;
                }

                if (!string.IsNullOrWhiteSpace(error))
                {
                    Console.WriteLine(error);
                    Environment.Exit(0);
                }
            }
            return value;
        }
    }
}
