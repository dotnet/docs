' <Snippet1>  

' HandleRef.vb

Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

'typedef struct _OVERLAPPED { 
'    ULONG_PTR  Internal; 
'    ULONG_PTR  InternalHigh; 
'    DWORD  Offset; 
'    DWORD  OffsetHigh; 
'    HANDLE hEvent; 
'} OVERLAPPED; 

' declared as structure
<StructLayout(LayoutKind.Sequential)> _
Public Structure Overlapped
    Private intrnal As IntPtr
    Private internalHigh As IntPtr
    Private offset As Integer
    Private offsetHigh As Integer
    Private hEvent As IntPtr
End Structure 'Overlapped

' declared as class
<StructLayout(LayoutKind.Sequential)> _
Public Class Overlapped2
    Private intrnal As IntPtr
    Private internalHigh As IntPtr
    Private offset As Integer
    Private offsetHigh As Integer
    Private hEvent As IntPtr
End Class 'Overlapped2


Public Class LibWrap

    ' to prevent FileStream to be GC-ed before call ends, 
    ' its handle should be wrapped in HandleRef

    ' BOOL ReadFile(HANDLE hFile, LPVOID lpBuffer, DWORD nNumberOfBytesToRead,
    '				LPDWORD lpNumberOfBytesRead, LPOVERLAPPED lpOverlapped);    

    Overloads Declare Unicode Function ReadFile Lib "Kernel32.dll" ( _
     ByVal hndRef As HandleRef, _
     ByVal buffer As StringBuilder, _
     ByVal numberOfBytesToRead As Integer, _
     ByRef numberOfBytesRead As Integer, _
     ByRef flag As Overlapped) _
    As Boolean

    ' since Overlapped is struct, Nothing can't be passed instead, 
    ' we must declare overload method if we will use this

    Overloads Declare Unicode Function ReadFile Lib "Kernel32.dll" ( _
     ByVal hndRef As HandleRef, _
     ByVal buffer As StringBuilder, _
     ByVal numberOfBytesToRead As Integer, _
     ByRef numberOfBytesRead As Integer, _
     ByVal flag As Integer) _
    As Boolean  ' int instead of structure reference

    ' since Overlapped2 is class, we can pass Nothing as parameter  
    ' no overload is needed		

    Declare Unicode Function ReadFile2 Lib "Kernel32.dll" Alias "ReadFile" ( _
     ByVal hndRef As HandleRef, _
     ByVal buffer As StringBuilder, _
     ByVal numberOfBytesToRead As Integer, _
     ByRef numberOfBytesRead As Integer, _
     <[In](), Out()> ByVal flag As Overlapped2) _
    As Boolean

End Class 'LibWrap

Public Class App
    Public Shared Sub Main()
	
	Run()
	
    End Sub 'Main
    
    <SecurityPermissionAttribute(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Public Shared Sub Run()


        Dim fs As New FileStream("HandleRef.txt", FileMode.Open)
        Dim hr As New HandleRef(fs, fs.SafeFileHandle.DangerousGetHandle())
        Dim buffer As New StringBuilder(5)
        Dim read As Integer = 0

        ' platform invoke will hold reference to HandleRef until call ends

        LibWrap.ReadFile(hr, buffer, 5, read, 0)
        Console.WriteLine("Read with struct parameter: {0}", buffer)
        LibWrap.ReadFile2(hr, buffer, 5, read, Nothing)
        Console.WriteLine("Read with class parameter: {0}", buffer)

    End Sub 'Run
End Class 'App
' </Snippet1> 