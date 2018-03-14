using System;
using System.EnterpriseServices;
namespace QueuedComponentClient
{
        public interface IQueuedComponent
        {
            void QueuedTask();
        }
	class QueuedComponentClientClass
	{
		[STAThread]
		static void Main(string[] args)
		{
            for(int counter = 0; counter < 10; counter++)
            {
                // <snippet0>
                // Use BindToMoniker to run the queued moniker, to get an instance of the recorder
                IQueuedComponent qc = 
                    (IQueuedComponent)System.Runtime.InteropServices.Marshal.BindToMoniker("queue:/new:QueuedComponent");
                // Call the method that will be recorded
                qc.QueuedTask();

                // Force the release of the recorder object, to send the message to the queue
                System.Runtime.InteropServices.Marshal.ReleaseComObject(qc);
                // </snippet0>
                
            }
		}
	}
}
