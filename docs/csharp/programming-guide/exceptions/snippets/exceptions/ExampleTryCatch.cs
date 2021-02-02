using System;

namespace Exceptions
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
            catch (IndexOutOfRangeException e)  // CS0168
            {
                Console.WriteLine(e.Message);
                // Set IndexOutOfRangeException to the new exception's InnerException.
                throw new ArgumentOutOfRangeException("index parameter is out of range.", e);
            }
        }
        // </ExampleTryCatch>
    }
}
