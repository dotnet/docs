Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions

Namespace ca1060
    '<snippet1>
    ' Violates rule: MovePInvokesToNativeMethodsClass.
    Friend Class UnmanagedApi
        Friend Declare Function RemoveDirectory Lib "kernel32" (
       ByVal Name As String) As Boolean
    End Class
    '</snippet1>

    '<snippet2>
    Public NotInheritable Class Interaction

        Private Sub New()
        End Sub

        ' Callers require Unmanaged permission        
        Public Shared Sub Beep()
            ' No need to demand a permission as callers of Interaction.Beep                     
            ' will require UnmanagedCode permission                     
            If Not NativeMethods.MessageBeep(-1) Then
                Throw New Win32Exception()
            End If

        End Sub

    End Class

    Friend NotInheritable Class NativeMethods

        Private Sub New()
        End Sub

        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Friend Shared Function MessageBeep(ByVal uType As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

    End Class
    '</snippet2>

    '<snippet3>
    Public NotInheritable Class Environment

        Private Sub New()
        End Sub

        ' Callers do not require Unmanaged permission       
        Public Shared ReadOnly Property TickCount() As Integer
            Get
                ' No need to demand a permission in place of               
                ' UnmanagedCode as GetTickCount is considered               
                ' a safe method               
                Return SafeNativeMethods.GetTickCount()
            End Get
        End Property

    End Class

    <SuppressUnmanagedCodeSecurityAttribute()>
    Friend NotInheritable Class SafeNativeMethods

        Private Sub New()
        End Sub

        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)>
        Friend Shared Function GetTickCount() As Integer
        End Function

    End Class
    '</snippet3>

    '<snippet4>
    Public NotInheritable Class Cursor

        Private Sub New()
        End Sub

        Public Shared Sub Hide()
            UnsafeNativeMethods.ShowCursor(False)
        End Sub

    End Class

    <SuppressUnmanagedCodeSecurityAttribute()>
    Friend NotInheritable Class UnsafeNativeMethods

        Private Sub New()
        End Sub

        <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)>
        Friend Shared Function ShowCursor(<MarshalAs(UnmanagedType.Bool)> ByVal bShow As Boolean) As Integer
        End Function

    End Class
    '</snippet4>
End Namespace
