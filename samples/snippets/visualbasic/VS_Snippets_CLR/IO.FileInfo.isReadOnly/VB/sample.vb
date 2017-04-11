'<SNIPPET1>
Imports System
Imports System.IO



Module FileExample

    Sub Main()

        Dim FileName As String = "c:\test.xml"

        ' Get the read-only value for a file.
        Dim isReadOnly As Boolean = IsFileReadOnly(FileName)

        ' Display wether the file is read-only.
        Console.WriteLine("The file read-only value for " & FileName & " is: " & isReadOnly)

        Console.WriteLine("Changing the read-only value for " & FileName & " to true.")

        ' Set the file to read-only.
        SetFileReadAccess(FileName, True)

        ' Get the read-only value for a file.
        isReadOnly = IsFileReadOnly(FileName)

        ' Display that the file is read-only.
        Console.WriteLine("The file read-only value for " & FileName & " is: " & isReadOnly)

    End Sub


    ' Sets the read-only value of a file.
    Sub SetFileReadAccess(ByVal FileName As String, ByVal SetReadOnly As Boolean)
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(FileName)

        ' Set the IsReadOnly property.
        fInfo.IsReadOnly = SetReadOnly

    End Sub


    ' Returns wether a file is read-only.
    Function IsFileReadOnly(ByVal FileName As String) As Boolean
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(FileName)

        ' Return the IsReadOnly property value.
        Return fInfo.IsReadOnly

    End Function
End Module
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'The file read-only value for c:\test.xml is: True
'Changing the read-only value for c:\test.xml to true.
'The file read-only value for c:\test.xml is: True
'</SNIPPET1>