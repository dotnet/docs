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
	    Activity activity = new Activity(serviceConfig); 
            activity.AsynchronousCall(serviceCall); 
            activity.AsynchronousCall(serviceCall);
            Console.WriteLine("Waiting for asynchronous calls to terminate");
            Console.Read();
        }
    }