'<snippet33>
Imports System.Runtime.InteropServices

'<snippet34>
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
Public Structure DsBrowseInfo
    Public Const MAX_PATH As Integer = 256

    Public Size As Integer
    Public OwnerHandle As IntPtr
    Public Caption As String
    Public Title As String
    Public Root As String
    Public Path As String
    Public PathSize As Integer
    Public Flags As Integer
    Public Callback As IntPtr
    Public Param As Integer
    Public ReturnFormat As Integer
    Public UserName As String
    Public Password As String
    Public ObjectClass As String
    Public ObjectClassSize As Integer
End Structure

Friend Class NativeMethods
    ' Declares a managed prototype for the unmanaged function.
    Friend Declare Unicode Function DsBrowseForContainerW Lib "dsuiext.dll" (
        ByRef info As DsBrowseInfo) As Integer

    Friend Const DSBI_ENTIREDIRECTORY As Integer = &H90000
    Friend Const ADS_FORMAT_WINDOWS As Integer = 1
    Friend Enum BrowseStatus
        BrowseError = -1
        BrowseOk = 1
        BrowseCancel = 2
    End Enum
End Class
'</snippet34>

'<snippet35>
Public Class App
    ' Must be marked as STA because the default is MTA.
    ' DsBrowseForContainerW calls CoInitialize, which initializes the
    ' COM library as STA.
    <STAThread>
    Public Shared Sub Main()
        Dim dsbi As New DsBrowseInfo()

        dsbi.Size = Marshal.SizeOf(GetType(DsBrowseInfo))
        dsbi.PathSize = DsBrowseInfo.MAX_PATH
        dsbi.Caption = "Container Selection Example"
        dsbi.Title = "Select a container from the list."
        dsbi.ReturnFormat = NativeMethods.ADS_FORMAT_WINDOWS
        dsbi.Flags = NativeMethods.DSBI_ENTIREDIRECTORY
        dsbi.Root = "LDAP:"
        dsbi.Path = New String(New Char(DsBrowseInfo.MAX_PATH) {})

        ' Initialize remaining members...
        Dim status As Integer = NativeMethods.DsBrowseForContainerW(dsbi)
        If CType(status, NativeMethods.BrowseStatus) = NativeMethods.BrowseStatus.BrowseOk Then
            Console.WriteLine(dsbi.Path)
        Else
            Console.WriteLine("No path returned.")
        End If
    End Sub
End Class
'</snippet35>
'</snippet33>
