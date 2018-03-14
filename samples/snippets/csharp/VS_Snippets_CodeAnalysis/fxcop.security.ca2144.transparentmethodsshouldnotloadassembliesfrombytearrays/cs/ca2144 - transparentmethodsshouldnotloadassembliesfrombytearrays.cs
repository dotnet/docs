//<Snippet1>
using System;
using System.IO;
using System.Reflection;

namespace TransparencyWarningsDemo
{

    public class TransparentMethodsLoadAssembliesFromByteArraysClass
    {
        public void TransparentMethod()
        {
            byte[] assemblyBytes = File.ReadAllBytes("DependentAssembly.dll");

            // CA2144 violation - transparent code loading an assembly via byte array.  The fix here is to
            // either make TransparentMethod critical or safe-critical.
            Assembly dependent = Assembly.Load(assemblyBytes);
        }
    }
}

//</Snippet1>