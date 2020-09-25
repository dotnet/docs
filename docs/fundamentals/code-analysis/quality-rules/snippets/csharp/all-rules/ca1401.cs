using System.Runtime.InteropServices;

namespace ca1401
{
    //<snippet1>
    // Violates rule: PInvokesShouldNotBeVisible.
    public class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool RemoveDirectory(string name);
    }
    //</snippet1>
}
