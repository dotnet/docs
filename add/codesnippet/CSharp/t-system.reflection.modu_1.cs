using System;
using System.IO;
using System.Reflection;

class MySample
{
    public static int Main(String[] args)
    {
        Assembly asm1 = typeof(MySample).Assembly;
        asm1.ModuleResolve += new ModuleResolveEventHandler(evModuleResolve);
        Console.WriteLine("Calling MySample.Test...");
        Test();
        return 0;
    }
    private static Module evModuleResolve(object sender, ResolveEventArgs e)
    {
        Console.WriteLine();
        Console.WriteLine("******************************************************");
        Console.WriteLine("* MySample.evModuleResolve() in module: {0:s} *",
            Type.GetType("MySample").Module.ScopeName);
        Console.WriteLine("******************************************************");
        FileStream fs = File.Open("subfolder\\Server1.netmodule", FileMode.Open);
        long len = fs.Length;
        byte[] rgFileBytes = new byte[len];
        fs.Read(rgFileBytes, 0, (int)len);
        Assembly a = typeof(MySample).Assembly;
        Module m = a.LoadModule("Server1.netmodule", rgFileBytes);
        return m;
    }
    private static void Test()
    {
        Console.WriteLine("Instantiating Server1...");
        Server1 s = new Server1();
        Console.WriteLine("Calling Server1.trivial...");
        s.trivial();
    }
}