'<Snippet1>
Imports System   
Imports System.Runtime.InteropServices   
Imports System.Security   
Imports System.Security.Permissions       

Public NotInheritable Class Cursor           

    Private Sub New()       
    End Sub           
    
    ' Callers do not require Unmanaged permission, however,         
    ' they do require UIPermission.AllWindows       
    Public Shared Sub Hide()                 
        ' Need to demand an appropriate permission                   
        ' in  place of UnmanagedCode permission as                    
        ' ShowCursor is not considered a safe method                   
        Dim permission As New UIPermission(UIPermissionWindow.AllWindows)           
        permission.Demand()           
        UnsafeNativeMethods.ShowCursor(False)                
        
    End Sub       
    
End Class       

<SuppressUnmanagedCodeSecurityAttribute()> _   
Friend NotInheritable Class UnsafeNativeMethods           

    Private Sub New()       
    End Sub           
    
    <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)> _       
    Friend Shared Function ShowCursor(<MarshalAs(UnmanagedType.Bool)> ByVal bShow As Boolean) As Integer       
    End Function       
    
End Class
'</Snippet1>