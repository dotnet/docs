using DotNet.CodeAnalysis;
using DotNet.GitHubAction.Analyzers;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.GitHubAction.Extensions
{
    static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddGitHubActionServices(
            this IServiceCollection services)
        {
            // Omitted for brevity
            // https://github.com/dotnet/samples/blob/008f9e197fb5d0ebb3a41216ee5fdde01869368f/github-actions/DotNet.GitHubAction/DotNet.GitHubAction/Extensions/ServiceCollectionExtensions.cs

            return services;
        }
    }
}
