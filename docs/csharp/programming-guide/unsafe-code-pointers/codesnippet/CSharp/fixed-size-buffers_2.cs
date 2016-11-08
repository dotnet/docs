namespace FixedSizeBuffers
{
    internal unsafe struct MyBuffer
    {
        public fixed char fixedBuffer[128];
    }

    internal unsafe class MyClass
    {
        public MyBuffer myBuffer = default(MyBuffer);
    }

    internal class Program
    {
        static void Main()
        {
            MyClass myC = new MyClass();

            unsafe
            {
                // Pin the buffer to a fixed location in memory.
                fixed (char* charPtr = myC.myBuffer.fixedBuffer)
                {
                    *charPtr = 'A';
                }
            }
        }
    }
}