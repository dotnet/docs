//  <SNIPPET1>
using System;
using System.Reflection;
using System.Security.Policy;

class ADMultiDomain
{
   // The following attribute indicates to loader that multiple application 
   // domains are used in this application.
   [LoaderOptimizationAttribute( LoaderOptimization.MultiDomainHost)]
   public static void Main()
   {
      // Create application domain setup information for new application domain.
      AppDomainSetup domaininfo = new AppDomainSetup();
      domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
      domaininfo.ApplicationName = "MyMultiDomain Application";

      //Create evidence for the new appdomain from evidence of current application domain.
      Evidence adevidence = AppDomain.CurrentDomain.Evidence;

      // Create appdomain.
      AppDomain newDomain = AppDomain.CreateDomain("MyMultiDomain", adevidence, domaininfo);

      // Load an assembly into the new application domain.
      Worker w = (Worker) newDomain.CreateInstanceAndUnwrap( 
         typeof(Worker).Assembly.GetName().Name,
         "Worker"
      );
      w.TestLoad();

      //Unload the application domain, which also unloads the assembly.
      AppDomain.Unload(newDomain);
   }
}

class Worker : MarshalByRefObject
{
   internal void TestLoad()
   {
      // You must supply a valid fully qualified assembly name here.
      Assembly.Load("Text assembly name, Culture, PublicKeyToken, Version");
      foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
         Console.WriteLine(assem.FullName);
   }
}
//  </SNIPPET1>