using System.Threading;
using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Collections;
using System.IO;
using System.Text;
using System.Security;

namespace InsertTextClient
{
// This class *MUST* be internal for security purposes
    internal class UnmanagedClass
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr SendMessageTimeout(
                HWND hwnd, int Msg, IntPtr wParam, IntPtr lParam, int flags, int uTimeout, out IntPtr pResult);

            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern IntPtr SendMessageTimeout(
                IntPtr hwnd, int uMsg, IntPtr wParam, StringBuilder lParam, int flags, int uTimeout, out IntPtr result);

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SendMessage(
                HWND hWnd, int nMsg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SendMessage(
                HWND hWnd, int nMsg, IntPtr wParam, StringBuilder lParam);

            [DllImport("user32", ExactSpelling = true)]
            internal static extern bool IsWindowEnabled(IntPtr hWnd);

            //
            // Control style information
            //
            public const int GCL_STYLE = -16;

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowLong(HWND hWnd, int nIndex);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool IsWindowEnabled(HWND hwnd);

            // Editbox styles
            internal const int ES_READONLY = 0x0800;

            // Editbox messages
            internal const int WM_SETTEXT = 0x000C;
            internal const int EM_GETLIMITTEXT = 0x00D5;

            [StructLayout(LayoutKind.Sequential)]
            public struct HWND
            {
                public IntPtr h;

                public static HWND Cast(IntPtr h)
                {
                    HWND hTemp = new HWND();
                    hTemp.h = h;
                    return hTemp;
                }

                public static implicit operator IntPtr(HWND h)
                {
                    return h.h;
                }

                public static HWND NULL
                {
                    get
                    {
                        HWND hTemp = new HWND();
                        hTemp.h = IntPtr.Zero;
                        return hTemp;
                    }
                }

                public static bool operator ==(HWND hl, HWND hr)
                {
                    return hl.h == hr.h;
                }

                public static bool operator !=(HWND hl, HWND hr)
                {
                    return hl.h != hr.h;
                }

                override public bool Equals(object oCompare)
                {
                    HWND hr = Cast((HWND)oCompare);
                    return h == hr.h;
                }

                public override int GetHashCode()
                {
                    return (int)h;
                }
            }
    }
}
