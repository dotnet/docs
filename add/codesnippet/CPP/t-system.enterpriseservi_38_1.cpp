public interface class IQueuedComponent
{
   void QueuedTask();
};


// Mark IQueuedComponent interface as queued
// Create the queued component class by inheriting the 
// System.EnterpriseServices.ServicedComponent class and an
// interface that is marked as queued with the InterfaceQueuing attribute

[InterfaceQueuing(true,Interface="IQueuedComponent")]
public ref class QueuedComponent sealed: public ServicedComponent, public IQueuedComponent
{
public:
   virtual void QueuedTask()
   {
      // Perform queued task here
   }

};