'<Snippet1>
' Example for the OperatingSystem.Clone method.
Imports System
Imports Microsoft.VisualBasic

Module CloneCompareDemo
    
    ' Copy, clone, and duplicate an OperatingSystem object.
    Sub CopyOperatingSystemObjects( )

        ' The Version object does not need to correspond to an 
        ' actual OS version.
        Dim verMMBVer As New Version( 5, 6, 7, 8 )
            
        Dim opCreate1 As New _
            OperatingSystem( PlatformID.Win32NT, verMMBVer )
            
        ' Create another OperatingSystem object with the same 
        ' parameters as opCreate1.
        Dim opCreate2 As New _
            OperatingSystem( PlatformID.Win32NT, verMMBVer )
            
        ' Clone opCreate1 and copy the opCreate1 reference.
        Dim opClone As OperatingSystem = _
            CType( opCreate1.Clone( ), OperatingSystem )
        Dim opCopy As OperatingSystem = opCreate1

        ' Compare the various objects for equality.
        Console.WriteLine( "{0,-50}{1}", _
            "Is the second object the same as the original?", _
            opCreate1.Equals( opCreate2 ) )
        Console.WriteLine( "{0,-50}{1}", _
            "Is the object clone the same as the original?", _
            opCreate1.Equals( opClone ) )
        Console.WriteLine( "{0,-50}{1}", _
            "Is the copied object the same as the original?", _
            opCreate1.Equals( opCopy ) )
    End Sub 
        
    Sub Main( )

        Console.WriteLine( _
            "This example of OperatingSystem.Clone( ) " & _
            "generates the following output." & vbCrLf )
        Console.WriteLine( _
            "Create an OperatingSystem object, and then " & _
            "create another object with the " & vbCrLf & _
            "same parameters. Clone and copy the " & _
            "original object, and then compare " & vbCrLf & _
            "each object with the original using the " & _
            "Equals( ) method. Equals( ) " & vbCrLf & _
            "returns true only when both " & _
            "references refer to the same object." & vbCrLf)
            
        CopyOperatingSystemObjects( )

    End Sub 
End Module 

' This example of OperatingSystem.Clone( ) generates the following output.
' 
' Create an OperatingSystem object, and then create another object with the
' same parameters. Clone and copy the original object, and then compare
' each object with the original using the Equals( ) method. Equals( )
' returns true only when both references refer to the same object.
' 
' Is the second object the same as the original?    False
' Is the object clone the same as the original?     False
' Is the copied object the same as the original?    True
'</Snippet1>
