As the .NET ecosystem continues to evolve, there might be slight behavioral differences in one platform implementation as compared to another. For example, the .NET Framework <xref:System.AppDomain?displayProperty=nameWithType> exposes functionality for remoting and assembly isolation, however; in .NET Core there are differences. Alternatives are, [gRPC](../docs/architecture/cloud-native/grpc.md) for remoting and [`AssemblyLoadContext`](https://github.com/dotnet/runtime/blob/master/docs/design/features/assemblyloadcontext.md) for assembly isolation.

It is impractical to enumerate the behavioral differences as they continue to evolve and differ by severity. As a convenience for observing discrepancies, look to GitHub. The `breaking-change` label is applied to pull requests and issues that introduce breaking API or functional change over a prerelease.

- [.NET CoreCLR pull requests with `breaking-change` label](https://github.com/dotnet/coreclr/pulls?q=label%3Abreaking-change)
- [.NET Runtime pull requests with `breaking-change` label](https://github.com/dotnet/runtime/pulls?q=label%3Abreaking-change)

Additionally, the [APIs of .NET](https://apisof.net) website is a great resource for quickly verifying API platform coverage.
