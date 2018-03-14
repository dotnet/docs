
using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Reflection;

  

[assembly: ApplicationName("Queued Component")]
[assembly: ApplicationID("AC6F4BE6-66E5-4a94-8162-A7F850150F9F")]
[assembly: ApplicationActivation(ActivationOption.Server)]
// Ensure that the example shows how to call the queued component.
// See QueuedComponentClient for example

//<snippet1>
// Mark the COM+ application as queued at compile time by using the 
// ApplicationQueuing attribute. Enable the COM+ listener by 
// setting the QueueListenerEnabled to true
[assembly: ApplicationQueuing(Enabled=true, QueueListenerEnabled=true)]
//</snippet1>

[Guid("9A6233C4-7459-4c1a-808A-905FC648B5A8")]
//<snippet2>
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
//</snippet2>
