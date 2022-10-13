static void Main(string[] args)
{
    ServiceBase[] ServicesToRun;
    ServicesToRun = new ServiceBase[]
    {
        new MyNewService(args)
    };
    ServiceBase.Run(ServicesToRun);
}