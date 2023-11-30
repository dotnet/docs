using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace simple
{
    // <Snippet1>
    class TestAssemblyLoadContext : AssemblyLoadContext
    {
        public TestAssemblyLoadContext() : base(isCollectible: true)
        {
        }

        protected override Assembly? Load(AssemblyName name)
        {
            return null;
        }
    }
    // </Snippet1>

    class Test
    {
        // <Snippet2>
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void ExecuteAndUnload(string assemblyPath, out WeakReference alcWeakRef)
        {
            // <Snippet3>
            var alc = new TestAssemblyLoadContext();
            Assembly a = alc.LoadFromAssemblyPath(assemblyPath);
            // </Snippet3>

            alcWeakRef = new WeakReference(alc, trackResurrection: true);

            // <Snippet4>
            var args = new object[1] {new string[] {"Hello"}};
            _ = a.EntryPoint?.Invoke(null, args);
            // </Snippet4>

            // <Snippet5>
            alc.Unload();
            // </Snippet5>
        }
        // </Snippet2>

        static void ExecuteAssemblyInUnloadableContext()
        {
            // <Snippet6>
            WeakReference testAlcWeakRef;
            ExecuteAndUnload("absolute/path/to/your/assembly", out testAlcWeakRef);
            // </Snippet6>

            // <Snippet7>
            for (int i = 0; testAlcWeakRef.IsAlive && (i < 10); i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            // </Snippet7>

            bool success = testAlcWeakRef.IsAlive;
        }
    }
}
