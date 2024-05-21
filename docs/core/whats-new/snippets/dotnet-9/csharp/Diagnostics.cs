
using System.Diagnostics;

internal class Diagnostics
{
    public static void RunIt()
    {
        // <AddLink>
        ActivityContext activityContext = new(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None);
        ActivityLink activityLink = new(activityContext);

        Activity activity = new("LinkTest");
        activity.AddLink(activityLink);
        // </AddLink>
    }
}
