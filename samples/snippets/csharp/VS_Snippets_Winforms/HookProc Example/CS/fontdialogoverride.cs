using System;
using System.Windows.Forms;

namespace FontDialogOverride_cs
{
	/// <summary>
	/// Summary description for FontDialogOverride.
	/// </summary>
	public class FontDialogOverride:FontDialog
	{
//<snippet1>

// Defines the constants for Windows messages.

const int WM_SETFOCUS = 0x0007;
const int WM_INITDIALOG = 0x0110;
const int WM_LBUTTONDOWN = 0x0201;
const int WM_RBUTTONDOWN = 0x0204;
const int WM_MOVE = 0x0003;

// Overrides the base class hook procedure...
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
{

	// Evaluates the message parameter to determine the user action.

	switch(msg)
	{

		case WM_INITDIALOG:
			System.Diagnostics.Trace.Write("The WM_INITDIALOG message was received.");
			break;
		case WM_SETFOCUS:
			System.Diagnostics.Trace.Write("The WM_SETFOCUS message was received.");
			break;
		case WM_LBUTTONDOWN:
			System.Diagnostics.Trace.Write("The WM_LBUTTONDOWN message was received.");
			break;
		case WM_RBUTTONDOWN:
			System.Diagnostics.Trace.Write("The WM_RBUTTONDOWN message was received.");
			break;
		case WM_MOVE:
			System.Diagnostics.Trace.Write("The WM_MOVE message was received.");
			break;

	}

	// Always call the base class hook procedure.

	return base.HookProc(hWnd, msg, wParam, lParam);

}
//</snippet1>

		

		public FontDialogOverride()
		{
			//
			// TODO: Add constructor logic here
			//
		}

	}
}
