namespace CustomProvider.Example;

public class WidgetOptions
{
    public Guid EndpointId { get; set; }

    public string DisplayLabel { get; set; } = null!;

    public string WidgetRoute { get; set; } = null!;

    public string[] IPAddressRange { get; set; } = null!;

    public FeatureFlags FeatureFlags { get; set; } = null!;
}

public class FeatureFlags
{
    public bool IsTelemetryEnabled { get; set; }
}
