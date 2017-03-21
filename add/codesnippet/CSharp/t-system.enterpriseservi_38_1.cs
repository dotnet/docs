public interface IQueuedComponent
{
    void QueuedTask();
}
// Mark IQueuedComponent interface as queued
[InterfaceQueuing(true, Interface="IQueuedComponent")]
// Create the queued component class by inheriting the 
// System.EnterpriseServices.ServicedComponent class and an
// interface that is marked as queued with the InterfaceQueuing attribute
public class QueuedComponent : ServicedComponent, IQueuedComponent
{
    public void QueuedTask()
    {
        // Perform queued task here
    }
}