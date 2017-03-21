public class Win32
{
    [DllImport("user32.dll", SetLastError=true)]
    public static extern int MessageBoxA(IntPtr hWnd, String text,
                                String caption, uint type);
}