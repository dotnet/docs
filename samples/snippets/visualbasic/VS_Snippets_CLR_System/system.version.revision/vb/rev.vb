'<snippet1>
' This example demonstrates the Version.Revision,
' MajorRevision, and MinorRevision properties.

Imports System

Class Sample
    Public Shared Sub Main() 
        Dim fmtStd As String = "Standard version:" & vbCrLf & _
                               "  major.minor.build.revision = {0}.{1}.{2}.{3}"
        Dim fmtInt As String = "Interim version:" & vbCrLf & _
                               "  major.minor.build.majRev/minRev = {0}.{1}.{2}.{3}/{4}"
        
        Dim std As New Version(2, 4, 1128, 2)
        Dim interim As New Version(2, 4, 1128, (100 << 16) + 2)
        
        Console.WriteLine(fmtStd, std.Major, std.Minor, std.Build, std.Revision)
        Console.WriteLine(fmtInt, interim.Major, interim.Minor, interim.Build, _
                          interim.MajorRevision, interim.MinorRevision)
    End Sub 'Main
End Class 'Sample

'
'This code example produces the following results:
'
'Standard version:
'  major.minor.build.revision = 2.4.1128.2
'Interim version:
'  major.minor.build.majRev/minRev = 2.4.1128.100/2
'
'</snippet1>