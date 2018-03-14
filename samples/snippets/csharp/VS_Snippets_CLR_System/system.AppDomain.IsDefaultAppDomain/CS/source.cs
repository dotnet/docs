//<Snippet1>
using System;
using System.Reflection;

public class Example
{
    // The following attribute indicates to the loader that assemblies
    // in the global assembly cache should be shared across multiple 
    // application domains.
    [LoaderOptimizationAttribute( LoaderOptimization.MultiDomainHost)]
    public static void Main()
    {
        // Show information for the default application domain.
        ShowDomainInfo();

        // Create a new application domain and display its information.
        AppDomain newDomain = AppDomain.CreateDomain("MyMultiDomain");
        newDomain.DoCallBack(new CrossAppDomainDelegate(ShowDomainInfo));
    }

    // This method has the same signature as the CrossAppDomainDelegate,
    // so that it can be executed easily in the new application domain.
    // 
    public static void ShowDomainInfo()
    {
        AppDomain ad = AppDomain.CurrentDomain;
        Console.WriteLine();
        Console.WriteLine("FriendlyName: {0}", ad.FriendlyName);
        Console.WriteLine("Id: {0}", ad.Id);
        Console.WriteLine("IsDefaultAppDomain: {0}", ad.IsDefaultAppDomain());
    }
}
//</Snippet1>
