//<snippet1>
using System;

namespace GCCollectIntExample
{
    class MyGCCollectClass
    {
        private const long maxGarbage = 1000;
      
        static void Main()
        {
            MyGCCollectClass myGCCol = new MyGCCollectClass();

            // Determine the maximum number of generations the system
	    // garbage collector currently supports.
            Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);
            
            myGCCol.MakeSomeGarbage();

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            
            // Determine the best available approximation of the number 
	    // of bytes currently allocated in managed memory.
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            
            // Perform a collection of generation 0 only.
            GC.Collect(0);
            
            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            
            // Perform a collection of all generations up to and including 2.
            GC.Collect(2);
            
            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Console.Read();
        }

        void MakeSomeGarbage()
        {
            Version vt;

            for(int i = 0; i < maxGarbage; i++)
            {
                // Create objects and release them to fill up memory
		// with unused objects.
                vt = new Version();
            }
        }
    }
}
//</snippet1>
