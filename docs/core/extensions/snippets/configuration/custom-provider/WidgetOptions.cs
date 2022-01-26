namespace CustomProvider.Example;

public class WidgetOptions
{
    public Guid EndpointId { get; set; }

    public string DisplayLabel { get; set; } = null!;

    public string WidgetRoute { get; set; } = null!;
}
