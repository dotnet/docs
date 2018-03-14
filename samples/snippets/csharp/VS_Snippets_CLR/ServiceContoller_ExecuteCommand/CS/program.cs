//<Snippet1>
using System;
using System.ServiceProcess;

namespace test_exec_cmnd
{
    class Program
    {
        private enum SimpleServiceCustomCommands { StopWorker = 128, RestartWorker, CheckWorker };
        static void Main(string[] args)
        {
            ServiceController myService = new ServiceController("SimpleService");
            myService.ExecuteCommand((int)SimpleServiceCustomCommands.StopWorker);
            myService.ExecuteCommand((int)SimpleServiceCustomCommands.RestartWorker);
            myService.ExecuteCommand((int)SimpleServiceCustomCommands.CheckWorker);


        }
    }
}
//</Snippet1>