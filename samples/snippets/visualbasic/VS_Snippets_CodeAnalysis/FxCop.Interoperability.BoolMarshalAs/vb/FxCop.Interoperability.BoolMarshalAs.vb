'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<assembly: ComVisible(False)>
Namespace UsageLibrary

   <ComVisible(True)> _
   Class NativeMethods

      Private Sub New()
      End Sub

      <DllImport("user32.dll", SetLastError := True)> _
      Friend Shared Function MessageBeep(uType As UInt32) _
         As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function

      <DllImport("mscoree.dll", SetLastError := True)> _
      Friend Shared Function StrongNameSignatureVerificationEx( _
         <MarshalAs(UnmanagedType.LPWStr)> wszFilePath As String, _
         <MarshalAs(UnmanagedType.U1)> fForceVerification As Boolean, _
         <MarshalAs(UnmanagedType.U1)> ByRef pfWasVerified As Boolean) _
         As <MarshalAs(UnmanagedType.U1)> Boolean
      End Function

   End Class

End Namespace
'</Snippet1>
