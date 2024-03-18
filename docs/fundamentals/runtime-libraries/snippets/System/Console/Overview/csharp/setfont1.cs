// <Snippet3>
using System;
using System.Runtime.InteropServices;

public class Example2
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern bool GetCurrentConsoleFontEx(
           IntPtr consoleOutput,
           bool maximumWindow,
           ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetCurrentConsoleFontEx(
           IntPtr consoleOutput,
           bool maximumWindow,
           CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

    private const int STD_OUTPUT_HANDLE = -11;
    private const int TMPF_TRUETYPE = 4;
    private const int LF_FACESIZE = 32;
    private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

    public static unsafe void Main()
    {
        string fontName = "Lucida Console";
        IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
        if (hnd != INVALID_HANDLE_VALUE)
        {
            CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
            info.cbSize = (uint)Marshal.SizeOf(info);
            bool tt = false;
            // First determine whether there's already a TrueType font.
            if (GetCurrentConsoleFontEx(hnd, false, ref info))
            {
                tt = (info.FontFamily & TMPF_TRUETYPE) == TMPF_TRUETYPE;
                if (tt)
                {
                    Console.WriteLine("The console already is using a TrueType font.");
                    return;
                }
                // Set console font to Lucida Console.
                CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                newInfo.FontFamily = TMPF_TRUETYPE;
                IntPtr ptr = new IntPtr(newInfo.FaceName);
                Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);
                // Get some settings from current font.
                newInfo.dwFontSize = new COORD(info.dwFontSize.X, info.dwFontSize.Y);
                newInfo.FontWeight = info.FontWeight;
                SetCurrentConsoleFontEx(hnd, false, newInfo);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct COORD
    {
        internal short X;
        internal short Y;

        internal COORD(short x, short y)
        {
            X = x;
            Y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct CONSOLE_FONT_INFO_EX
    {
        internal uint cbSize;
        internal uint nFont;
        internal COORD dwFontSize;
        internal int FontFamily;
        internal int FontWeight;
        internal fixed char FaceName[LF_FACESIZE];
    }
}
// </Snippet3>
