[EventTrackingEnabled(false)]
public class EventTrackingEnabledAttribute_Value : ServicedComponent
{
    public void ValueExample()
    {
        // Get the EventTrackingEnabledAttribute applied to the class.
        EventTrackingEnabledAttribute attribute =
            (EventTrackingEnabledAttribute)Attribute.GetCustomAttribute(
            this.GetType(),
            typeof(EventTrackingEnabledAttribute),
            false);

        // Display the value of the attribute's Value property.
        Console.WriteLine("EventTrackingEnabledAttribute.Value: {0}",
            attribute.Value);
    }
}