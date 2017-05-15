using System;
using System.EnterpriseServices;
namespace EnterpriseServices_ActivitySample
{
    //<snippet0>
    class SvcClass: IServiceCall 
    {
        static int callNumber = 0;
        public void OnCall()
        {
            callNumber++;
            System.Guid contextID = ContextUtil.ContextId;
            Console.WriteLine("This is call number "+ callNumber.ToString()); 
            Console.WriteLine(contextID.ToString());
            System.TimeSpan sleepTime = new System.TimeSpan(0,0,0,10); 
            System.Threading.Thread.Sleep(sleepTime);
           
        }
    }
    class EnterpriseServicesActivityClass
    {
        [STAThread]
	static void Main(string[] args)
        {
            ServiceConfig serviceConfig = new ServiceConfig();
            serviceConfig.Synchronization = SynchronizationOption.Required;
            serviceConfig.ThreadPool = ThreadPoolOption.MTA;
            SvcClass serviceCall = new SvcClass();
            //<snippet1>
	    Activity activity = new Activity(serviceConfig); 
            //</snippet1>
            //<snippet2>
            activity.AsynchronousCall(serviceCall); 
            //</snippet2>
            activity.AsynchronousCall(serviceCall);
            Console.WriteLine("Waiting for asynchronous calls to terminate");
            Console.Read();
        }
    }
    //</snippet0>
}
