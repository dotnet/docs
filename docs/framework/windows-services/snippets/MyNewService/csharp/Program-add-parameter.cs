using System.ServiceProcess;

public class Class1
{
    // <Snippet1>
    static void Main(string[] args)
    {
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[]
        {
            new MyNewService(args)
        };
        ServiceBase.Run(ServicesToRun);
    }
    // </Snippet1>
}
