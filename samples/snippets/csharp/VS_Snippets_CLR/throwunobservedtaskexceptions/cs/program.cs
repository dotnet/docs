//<Snippet1>
using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

//Use the following config settings to enable the throwing of unobserved exceptions.
//<configuration>
//  <startup>
//    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
//  </startup>
//  <runtime>
//    <ThrowUnobservedTaskExceptions enabled="true"/>
//  </runtime>
//</configuration>

public class Example
{
    static void Main()
    {
        Task.Run(() => { throw new InvalidOperationException("test"); });
        while (true)
        {
            Thread.Sleep(100);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
//</Snippet1>