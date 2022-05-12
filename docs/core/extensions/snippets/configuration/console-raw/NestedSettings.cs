public sealed class NestedSettings
{
    public string Message { get; set; } = null!;

    public Dictionary<string, Version> SupportedVersions { get; set; } = null!;
}
