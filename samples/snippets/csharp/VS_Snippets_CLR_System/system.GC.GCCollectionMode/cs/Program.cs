//<Snippet1>
using System;

class Program
{
    static void Main(string[] args)
    {
        GC.Collect(2, GCCollectionMode.Optimized);
    }
}
// </Snippet1>
