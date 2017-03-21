    // Demonstrate how to call GlobalAlloc and 
    // GlobalFree using the Marshal class.
    IntPtr hglobal = Marshal::AllocHGlobal(100);
    Marshal::FreeHGlobal(hglobal);