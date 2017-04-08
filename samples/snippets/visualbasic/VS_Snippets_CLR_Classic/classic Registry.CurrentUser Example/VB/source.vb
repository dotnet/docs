' <Snippet1>
Imports System
Imports Microsoft.Win32

Class Reg
    
    Public Shared Sub Main()
        
        ' Create a RegistryKey, which will access the HKEY_CURRENT_USER
        ' key in the registry of this machine.
        Dim rk As RegistryKey = Registry.CurrentUser
        
        ' Print out the keys.
        PrintKeys(rk)
    End Sub    
    
    Shared Sub PrintKeys(rkey As RegistryKey)
        
        ' Retrieve all the subkeys for the specified key.
        Dim names As String() = rkey.GetSubKeyNames()
        
        Dim icount As Integer = 0
        
        Console.WriteLine("Subkeys of " & rkey.Name)
        Console.WriteLine("-----------------------------------------------")
        
        ' Print the contents of the array to the console.
        Dim s As String
        For Each s In  names
            Console.WriteLine(s)
            
            ' The following code puts a limit on the number
            ' of keys displayed.  Comment it out to print the
            ' complete list.
            icount += 1            
            If icount >= 10 Then
                Exit For
            End If
        Next s
    End Sub
End Class
' </Snippet1>