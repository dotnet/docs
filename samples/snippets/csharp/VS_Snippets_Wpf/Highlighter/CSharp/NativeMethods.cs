/*******************************************************************************
 * File: NativeMethods.cs
 *
 * Description:
 * Contains definitions for Win32 API elements used by the application for
 * customizing the forms that make up the highlight rectangle.
 *
 * See ClientForm.cs for a full description of the sample.
 *
 *
 *  This file is part of the Microsoft Windows SDK Code Samples.
 *
 *  Copyright (C) Microsoft Corporation.  All rights reserved.
 *
 * This source code is intended only as a supplement to Microsoft
 * Development Tools and/or on-line documentation.  See these other
 * materials for detailed information regarding Microsoft code samples.
 *
 * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 *
 ******************************************************************************/
using System;

namespace Highlighter
{
    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool SetWindowPos(
            IntPtr hWnd, IntPtr hwndAfter, int x, int y,
            int width, int height, int flags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex,
            int dwNewLong);
// <Snippet101>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();
// </Snippet101>
        internal const int GWL_EXSTYLE = -20;

        internal const int SW_SHOWNA = 8;
        internal const int WS_EX_TOOLWINDOW = 0x00000080;

        // SetWindowPos constants (used by highlight rect)
        internal const int SWP_NOACTIVATE = 0x0010;
        internal static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    }
}
