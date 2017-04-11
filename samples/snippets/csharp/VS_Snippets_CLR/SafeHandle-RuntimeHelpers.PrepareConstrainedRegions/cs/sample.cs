
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace SafeHandleExample
{
    // <snippet1>
    [StructLayout(LayoutKind.Sequential)]
    struct MyStruct
    {
        public IntPtr m_outputHandle;
    }

    sealed class MySafeHandle : SafeHandle
    {
        // Called by P/Invoke when returning SafeHandles
        public MySafeHandle()
            : base(IntPtr.Zero, true)
        {
        }

        public MySafeHandle AllocateHandle()
        {
            // Allocate SafeHandle first to avoid failure later.
            MySafeHandle sh = new MySafeHandle();

            RuntimeHelpers.PrepareConstrainedRegions();
            try { }
            finally
            {
                MyStruct myStruct = new MyStruct();
                NativeAllocateHandle(ref myStruct);
                sh.SetHandle(myStruct.m_outputHandle);
            }

            return sh;
        }

        // </snippet1>
        // If & only if you need to support user-supplied handles
        internal MySafeHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(preexistingHandle);
        }

        // Do not provide a finalizer - SafeHandle's critical finalizer will
        // call ReleaseHandle for you.

        public override bool IsInvalid
        {

            get { return IsClosed || handle == IntPtr.Zero; }
        }
   
        [DllImport("kernel32")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }

        [DllImport("kernel32")]
        public static extern MySafeHandle CreateHandle(int someState);

        [DllImport("kernel32")]
        public static extern MySafeHandle NativeAllocateHandle(ref MyStruct someState);
    }


    public class Example
    {
        static void Main()
        {
        }
    }

   
}

