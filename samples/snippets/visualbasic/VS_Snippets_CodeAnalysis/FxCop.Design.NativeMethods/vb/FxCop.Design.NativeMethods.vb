'<Snippet1>
Imports System    
Imports System.Runtime.InteropServices    
Imports System.ComponentModel         

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
    
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _        
    Friend Shared Function MessageBeep(ByVal uType As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean        
    End Function  
      
End Class
'</Snippet1>