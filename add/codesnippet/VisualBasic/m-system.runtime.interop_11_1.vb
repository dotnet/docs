        ' Demonstrate how to call GlobalAlloc and 
        ' GlobalFree using the Marshal class.
        Dim hglobal As IntPtr = Marshal.AllocHGlobal(100)
        Marshal.FreeHGlobal(hglobal)