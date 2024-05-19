namespace CustomProvider.Example;

public class WidgetOptions
{
    public required Guid EndpointId { get; set; }

    public required string DisplayLabel { get; set; } = null!;

    public required string WidgetRoute { get; set; } = null!;
}
