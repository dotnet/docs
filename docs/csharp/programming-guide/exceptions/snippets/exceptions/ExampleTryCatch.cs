using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptions
{
    class ExampleTryCatch
    {
        // <ExampleTryCatch>
        static int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (System.IndexOutOfRangeException e)  // CS0168
            {
                System.Console.WriteLine(e.Message);
                // Set IndexOutOfRangeException to the new exception's InnerException.
                throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
            }
        }
        // </ExampleTryCatch>
    }
}
