#Region "Using directives"

Imports System.Drawing
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Interop
Imports System.Runtime.InteropServices

#End Region

Namespace WPF_Hosting_Win32_Control
'<SnippetControlHostClass>
  Public Class ControlHost
	  Inherits HwndHost
	Private hwndControl As IntPtr
	Private hwndHost As IntPtr
	Private hostHeight, hostWidth As Integer

	Public Sub New(ByVal height As Double, ByVal width As Double)
            hostHeight = CInt(height)
            hostWidth = CInt(width)
	End Sub
'</SnippetControlHostClass>
'<SnippetBuildWindowCore>
	Protected Overrides Function BuildWindowCore(ByVal hwndParent As HandleRef) As HandleRef
	  hwndControl = IntPtr.Zero
	  hwndHost = IntPtr.Zero

	  hwndHost = CreateWindowEx(0, "static", "", WS_CHILD Or WS_VISIBLE, 0, 0, hostWidth, hostHeight, hwndParent.Handle, New IntPtr(HOST_ID), IntPtr.Zero, 0)

	  hwndControl = CreateWindowEx(0, "listbox", "", WS_CHILD Or WS_VISIBLE Or LBS_NOTIFY Or WS_VSCROLL Or WS_BORDER, 0, 0, hostWidth, hostHeight, hwndHost, New IntPtr(LISTBOX_ID), IntPtr.Zero, 0)

	  Return New HandleRef(Me, hwndHost)
	End Function
'</SnippetBuildWindowCore>
'<SnippetWndProcDestroy>
	Protected Overrides Function WndProc(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, ByRef handled As Boolean) As IntPtr
	  handled = False
	  Return IntPtr.Zero
	End Function

	Protected Overrides Sub DestroyWindowCore(ByVal hwnd As HandleRef)
	  DestroyWindow(hwnd.Handle)
	End Sub
'</SnippetWndProcDestroy>
'<SnippetIntPtrProperty>
	Public ReadOnly Property hwndListBox() As IntPtr
	  Get
		  Return hwndControl
	  End Get
	End Property
'</SnippetIntPtrProperty>
'<SnippetBuildWindowCoreHelper>
	'PInvoke declarations
	<DllImport("user32.dll", EntryPoint := "CreateWindowEx", CharSet := CharSet.Unicode)>
	Friend Shared Function CreateWindowEx(ByVal dwExStyle As Integer, ByVal lpszClassName As String, ByVal lpszWindowName As String, ByVal style As Integer, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal hwndParent As IntPtr, ByVal hMenu As IntPtr, ByVal hInst As IntPtr, <MarshalAs(UnmanagedType.AsAny)> ByVal pvParam As Object) As IntPtr
	End Function
'</SnippetBuildWindowCoreHelper>
'<SnippetWndProcDestroyHelper>
	<DllImport("user32.dll", EntryPoint := "DestroyWindow", CharSet := CharSet.Unicode)>
	Friend Shared Function DestroyWindow(ByVal hwnd As IntPtr) As Boolean
	End Function
'</SnippetWndProcDestroyHelper>
'<SnippetControlHostConstants>
	Friend Const WS_CHILD As Integer = &H40000000, WS_VISIBLE As Integer = &H10000000, LBS_NOTIFY As Integer = &H00000001, HOST_ID As Integer = &H00000002, LISTBOX_ID As Integer = &H00000001, WS_VSCROLL As Integer = &H00200000, WS_BORDER As Integer = &H00800000
'</SnippetControlHostConstants>
  End Class
End Namespace
