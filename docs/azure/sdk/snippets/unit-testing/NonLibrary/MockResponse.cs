using Azure.Core;
using Azure;
using System.Diagnostics.CodeAnalysis;

namespace UnitTestingSampleApp.NonLibrary;

public sealed class MockResponse : Response
{
    public override int Status => throw new NotImplementedException();

    public override string ReasonPhrase => throw new NotImplementedException();

    public override Stream? ContentStream
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
    public override string ClientRequestId
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public override void Dispose() =>
        throw new NotImplementedException();
    protected override bool ContainsHeader(string name) =>
        throw new NotImplementedException();
    protected override IEnumerable<HttpHeader> EnumerateHeaders() =>
        throw new NotImplementedException();
    protected override bool TryGetHeader(
        string name,
        [NotNullWhen(true)] out string? value) =>
        throw new NotImplementedException();
    protected override bool TryGetHeaderValues(
        string name,
        [NotNullWhen(true)] out IEnumerable<string>? values) =>
        throw new NotImplementedException();
}
