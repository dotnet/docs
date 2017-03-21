public class Win32
{
    [DllImport("user32.dll", CharSet=CharSet.Unicode,
        ExactSpelling=true)]
    public static extern int MessageBoxW(IntPtr hWnd, String text,
                                String caption, uint type);
}