'<Snippet1>
Imports System   
Imports System.Runtime.InteropServices   
Imports System.Security       

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

<SuppressUnmanagedCodeSecurityAttribute()> _   
Friend NotInheritable Class SafeNativeMethods             

    Private Sub New()       
    End Sub           
    
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)> _       
    Friend Shared Function GetTickCount() As Integer       
    End Function       
    
End Class
'</Snippet1>