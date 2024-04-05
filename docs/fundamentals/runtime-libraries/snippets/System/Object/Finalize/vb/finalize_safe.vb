' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports Microsoft.Win32.SafeHandles
Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class FileAssociationInfo : Implements IDisposable
   ' Private variables.
   Private ext As String
   Private openCmd As String
   Private args As String
   Private hExtHandle, hAppIdHandle As SafeRegistryHandle

   ' Windows API calls.
   Private Declare Unicode Function RegOpenKeyEx Lib"advapi32.dll" _
                   Alias "RegOpenKeyExW" (hKey As IntPtr, lpSubKey As String, _
                   ulOptions As Integer, samDesired As Integer, _
                   ByRef phkResult As IntPtr) As Integer
   Private Declare Unicode Function RegQueryValueEx Lib "advapi32.dll" _
                   Alias "RegQueryValueExW" (hKey As IntPtr, _
                   lpValueName As String, lpReserved As Integer, _
                   ByRef lpType As UInteger, lpData As String, _
                   ByRef lpcbData As UInteger) As Integer
   Private Declare Function RegSetValueEx Lib "advapi32.dll" _
                  (hKey As IntPtr, _
                  <MarshalAs(UnmanagedType.LPStr)> lpValueName As String, _
                  reserved As Integer, dwType As UInteger, _
                  <MarshalAs(UnmanagedType.LPStr)> lpData As String, _
                  cpData As Integer) As Integer
   Private Declare Function RegCloseKey Lib "advapi32.dll" _
                  (hKey As IntPtr) As Integer

   ' Windows API constants.
   Private Const HKEY_CLASSES_ROOT As Integer = &h80000000
   Private Const ERROR_SUCCESS As Integer = 0

   Private Const KEY_QUERY_VALUE As Integer = 1
   Private Const KEY_SET_VALUE As Integer = &h2

   Private REG_SZ As UInteger = 1

   Private Const MAX_PATH As Integer  = 260

   Public Sub New(fileExtension As String)
      Dim retVal As Integer = 0
      Dim lpType As UInteger = 0

      If Not fileExtension.StartsWith(".") Then
         fileExtension = "." + fileExtension
      End If
      ext = fileExtension

      Dim hExtension As IntPtr = IntPtr.Zero
      ' Get the file extension value.
      retVal = RegOpenKeyEx(New IntPtr(HKEY_CLASSES_ROOT), fileExtension, 0,
                            KEY_QUERY_VALUE, hExtension)
      if retVal <> ERROR_SUCCESS Then
         Throw New Win32Exception(retVal)
      End If
      ' Instantiate the first SafeRegistryHandle.
      hExtHandle = New SafeRegistryHandle(hExtension, True)

      Dim appId As New String(" "c, MAX_PATH)
      Dim appIdLength As UInteger = CUInt(appId.Length)
      retVal = RegQueryValueEx(hExtHandle.DangerousGetHandle(), String.Empty, _
                               0, lpType, appId, appIdLength)
      if retVal <> ERROR_SUCCESS Then
         Throw New Win32Exception(retVal)
      End If
      ' We no longer need the hExtension handle.
      hExtHandle.Dispose()

      ' Determine the number of characters without the terminating null.
      appId = appId.Substring(0, CInt(appIdLength) \ 2 - 1) + "\shell\open\Command"

      ' Open the application identifier key.
      Dim exeName As New string(" "c, MAX_PATH)
      Dim exeNameLength As UInteger = CUInt(exeName.Length)
      Dim hAppId As IntPtr
      retVal = RegOpenKeyEx(New IntPtr(HKEY_CLASSES_ROOT), appId, 0,
                            KEY_QUERY_VALUE Or KEY_SET_VALUE, hAppId)
      If retVal <> ERROR_SUCCESS Then
         Throw New Win32Exception(retVal)
      End If

      ' Instantiate the second SafeRegistryHandle.
      hAppIdHandle = New SafeRegistryHandle(hAppId, True)

      ' Get the executable name for this file type.
      Dim exePath As New string(" "c, MAX_PATH)
      Dim exePathLength As UInteger = CUInt(exePath.Length)
      retVal = RegQueryValueEx(hAppIdHandle.DangerousGetHandle(), _
                               String.Empty, 0, lpType, exePath, exePathLength)
      If retVal <> ERROR_SUCCESS Then
         Throw New Win32Exception(retVal)
      End If
      ' Determine the number of characters without the terminating null.
      exePath = exePath.Substring(0, CInt(exePathLength) \ 2 - 1)

      exePath = Environment.ExpandEnvironmentVariables(exePath)
      Dim position As Integer = exePath.IndexOf("%"c)
      If position >= 0 Then
         args = exePath.Substring(position)
         ' Remove command line parameters ('%0', etc.).
         exePath = exePath.Substring(0, position).Trim()
      End If
      openCmd = exePath
   End Sub

   Public ReadOnly Property Extension As String
      Get
         Return ext
      End Get
   End Property

   Public Property Open As String
      Get
         Return openCmd
      End Get
      Set
        If hAppIdHandle.IsInvalid Or hAppIdHandle.IsClosed Then
           Throw New InvalidOperationException("Cannot write to registry key.")
        End If
        If Not File.Exists(value) Then
           Dim message As String = String.Format("'{0}' does not exist", value)
           Throw New FileNotFoundException(message)
        End If
        Dim cmd As String = value + " %1"
        Dim retVal As Integer = RegSetValueEx(hAppIdHandle.DangerousGetHandle(), String.Empty, 0,
                                              REG_SZ, value, value.Length + 1)
        If retVal <> ERROR_SUCCESS Then
           Throw New Win32Exception(retVal)
        End If
      End Set
   End Property

   Public Sub Dispose() _
      Implements IDisposable.Dispose
      Dispose(disposing:=True)
      GC.SuppressFinalize(Me)
   End Sub

   Protected Sub Dispose(disposing As Boolean)
      ' Ordinarily, we release unmanaged resources here
      ' but all are wrapped by safe handles.

      ' Release disposable objects.
      If disposing Then
         If hExtHandle IsNot Nothing Then hExtHandle.Dispose()
         If hAppIdHandle IsNot Nothing Then hAppIdHandle.Dispose()
      End If
   End Sub
End Class
' </Snippet2>

Module Example
   Public Sub Main()
      Dim fa As New FileAssociationInfo(".txt")
      Console.WriteLine("{0} files are handled by '{1}'", fa.Extension, fa.Open)
      fa.Dispose()
   End Sub
End Module

