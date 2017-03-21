// Mark the COM+ application as queued at compile time by using the 
// ApplicationQueuing attribute. Enable the COM+ listener by 
// setting the QueueListenerEnabled to true
[assembly: ApplicationQueuing(Enabled=true, QueueListenerEnabled=true)]