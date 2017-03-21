[Synchronization(SynchronizationOption.Required)]
public class ContextUtil_ActivityId : ServicedComponent
{
    public void Example()
    {
        // Display the ActivityID associated with the current COM+ context.
        Console.WriteLine("Activity ID: {0}", ContextUtil.ActivityId);
    }
}