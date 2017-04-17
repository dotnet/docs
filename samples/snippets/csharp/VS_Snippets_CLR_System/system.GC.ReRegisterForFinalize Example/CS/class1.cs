//<snippet1>
using System;

namespace ReRegisterForFinalizeExample
{
    class MyMainClass
    {
        static void Main()
        {
            // Create a MyFinalizeObject.
            MyFinalizeObject mfo = new MyFinalizeObject();

            // Release the reference to mfo.
            mfo = null;

            // Force a garbage collection.
            GC.Collect();

            // At this point mfo will have gone through the first Finalize.
            // There should now be a reference to mfo in the static
            // MyFinalizeObject.currentInstance field.  Setting this value
            // to null and forcing another garbage collection will now
            // cause the object to Finalize permanently.
            MyFinalizeObject.currentInstance = null;
            GC.Collect();
        }
    }

    class MyFinalizeObject
    {
        public static MyFinalizeObject currentInstance = null;
        private bool hasFinalized = false;

        ~MyFinalizeObject()
        {
            if(hasFinalized == false)
            {
                Console.WriteLine("First finalization");
            
                // Put this object back into a root by creating
                // a reference to it.
                MyFinalizeObject.currentInstance = this;
            
                // Indicate that this instance has finalized once.
                hasFinalized = true;

                // Place a reference to this object back in the
                // finalization queue.
                GC.ReRegisterForFinalize(this);
            }
            else
            {
                Console.WriteLine("Second finalization");
            }
        }
    }
}
//</snippet1>
