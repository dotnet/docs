// <snippet2>
using System;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class SNKToAssembly
{
    public static void Main()
    {
        // <snippet3>
        FileStream fs = new FileStream("SomeKeyPair.snk", FileMode.Open);
        StrongNameKeyPair kp = new StrongNameKeyPair(fs);
        fs.Close();
        AssemblyName an = new AssemblyName();
        an.KeyPair = kp;
        AppDomain appDomain = Thread.GetDomain();
        AssemblyBuilder ab = appDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);
        // </snippet3>
    }
}
// </snippet2>
