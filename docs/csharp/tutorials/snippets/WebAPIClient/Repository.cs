public record class Repository(
    string Name,
    string Description,
    Uri GitHubHomeUrl,
    Uri Homepage,
    int Watchers,
    DateTime LastPushUtc
)
{
    public DateTime LastPush => LastPushUtc.ToLocalTime();
}
