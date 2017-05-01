'<snippet00>
Imports System
Imports System.IO

Class Test
    Public Shared Sub Main()
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()

        Dim d As DriveInfo
        For Each d In allDrives
            Console.WriteLine("Drive {0}", d.Name)
            Console.WriteLine("  Drive type: {0}", d.DriveType)
            If d.IsReady = True Then
                Console.WriteLine("  Volume label: {0}", d.VolumeLabel)
                Console.WriteLine("  File system: {0}", d.DriveFormat)
                Console.WriteLine( _
                    "  Available space to current user:{0, 15} bytes", _
                    d.AvailableFreeSpace)

                Console.WriteLine( _
                    "  Total available space:          {0, 15} bytes", _
                    d.TotalFreeSpace)

                Console.WriteLine( _
                    "  Total size of drive:            {0, 15} bytes ", _
                    d.TotalSize)
            End If
        Next
    End Sub
End Class
'This code produces output similar to the following:
'
'Drive A:\
'  Drive type: Removable
'Drive C:\
'  Drive type: Fixed
'  Volume label: 
'  File system: FAT32
'  Available space to current user:     4770430976 bytes
'  Total available space:               4770430976 bytes
'  Total size of drive:                10731683840 bytes 
'Drive D:\
'  Drive type: Fixed
'  Volume label: 
'  File system: NTFS
'  Available space to current user:    15114977280 bytes
'  Total available space:              15114977280 bytes
'  Total size of drive:                25958948864 bytes 
'Drive E:\
'  Drive type: CDRom
'
'The actual output of this code will vary based on machine and the permissions
'granted to the user executing it.
'</snippet00>