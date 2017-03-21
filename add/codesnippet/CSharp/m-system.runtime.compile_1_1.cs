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
