'Imports System.IO
Imports System.Linq

' How to: Find Files by Extension & How to: Find newest file
' <snippet1>
Module FindFileByExtension
    Sub Main()

        ' Change the drive\path if necessary
        Dim root As String = "C:\Program Files\Microsoft Visual Studio 9.0"

        'Take a snapshot of the folder contents
        Dim dir As New System.IO.DirectoryInfo(root)

        Dim fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        ' This query will produce the full path for all .txt files
        ' under the specified folder including subfolders.
        ' It orders the list according to the file name.
        Dim fileQuery = From file In fileList _
                        Where file.Extension = ".txt" _
                        Order By file.Name _
                        Select file

        For Each file In fileQuery
            Console.WriteLine(file.FullName)
        Next

        ' Create and execute a new query by using
        ' the previous query as a starting point.
        ' fileQuery is not executed again until the
        ' call to Last
        Dim fileQuery2 = From file In fileQuery _
                         Order By file.CreationTime _
                         Select file.Name, file.CreationTime

        ' Execute the query
        Dim newestFile = fileQuery2.Last

        Console.WriteLine("\r\nThe newest .txt file is {0}. Creation time: {1}", _
                newestFile.Name, newestFile.CreationTime)

        ' Keep the console window open in debug mode
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()

    End Sub
End Module
' </snippet1>


' <snippet2>
Module QueryTotalBytes
    Sub Main()

        ' Change the drive\path if necessary.
        Dim root As String = "C:\Program Files\Microsoft Visual Studio 9.0\VB"

        'Take a snapshot of the folder contents.
        ' This method assumes that the application has discovery permissions
        ' for all folders under the specified path.
        Dim fileList = My.Computer.FileSystem.GetFiles _
                  (root, FileIO.SearchOption.SearchAllSubDirectories, "*.*")

        Dim fileQuery = From file In fileList _
                        Select GetFileLength(file)

        ' Force execution and cache the results to avoid multiple trips to the file system.
        Dim fileLengths = fileQuery.ToArray()

        ' Find the largest file
        Dim maxSize = Aggregate aFile In fileLengths Into Max()

        ' Find the total number of bytes
        Dim totalBytes = Aggregate aFile In fileLengths Into Sum()

        Console.WriteLine("The largest file is " & maxSize & " bytes")
        Console.WriteLine("There are " & totalBytes & " total bytes in " & _
                          fileList.Count & " files under " & root)

        ' Keep the console window open in debug mode
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub

    ' This method is used to catch the possible exception
    ' that can be raised when accessing the FileInfo.Length property.
    Function GetFileLength(ByVal filename As String) As Long
        Dim retval As Long
        Try
            Dim fi As New System.IO.FileInfo(filename)
            retval = fi.Length
        Catch ex As System.IO.FileNotFoundException
            ' If a file is no longer present,
            ' just return zero bytes. 
            retval = 0
        End Try

        Return retval
    End Function
End Module
' </snippet2>

'<snippet3>
Module QueryBySize
    Sub Main()

        ' Change the drive\path if necessary
        Dim root As String = "C:\Program Files\Microsoft Visual Studio 9.0"

        'Take a snapshot of the folder contents
        Dim dir As New System.IO.DirectoryInfo(root)
        Dim fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        ' Return the size of the largest file
        Dim maxSize = Aggregate aFile In fileList Into Max(GetFileLength(aFile))

        'Dim maxSize = fileLengths.Max
        Console.WriteLine("The length of the largest file under {0} is {1}", _
                          root, maxSize)

        ' Return the FileInfo object of the largest file
        ' by sorting and selecting from the beginning of the list
        Dim filesByLengDesc = From file In fileList _
                              Let filelength = GetFileLength(file) _
                              Where filelength > 0 _
                              Order By filelength Descending _
                              Select file

        Dim longestFile = filesByLengDesc.First

        Console.WriteLine("The largest file under {0} is {1} with a length of {2} bytes", _
                          root, longestFile.FullName, longestFile.Length)

        Dim smallestFile = filesByLengDesc.Last

        Console.WriteLine("The smallest file under {0} is {1} with a length of {2} bytes", _
                                root, smallestFile.FullName, smallestFile.Length)

        ' Return the FileInfos for the 10 largest files
        ' Based on a previous query, but nothing is executed
        ' until the For Each statement below.
        Dim tenLargest = From file In filesByLengDesc Take 10

        Console.WriteLine("The 10 largest files under {0} are:", root)

        For Each fi As System.IO.FileInfo In tenLargest
            Console.WriteLine("{0}: {1} bytes", fi.FullName, fi.Length)
        Next

        ' Group files according to their size,
        ' leaving out the ones under 200K
        Dim sizeGroups = From file As System.IO.FileInfo In fileList _
                         Where file.Length > 0 _
                         Let groupLength = file.Length / 100000 _
                         Group file By groupLength Into fileGroup = Group _
                         Where groupLength >= 2 _
                         Order By groupLength Descending

        For Each group In sizeGroups
            Console.WriteLine(group.groupLength + "00000")

            For Each item As System.IO.FileInfo In group.fileGroup
                Console.WriteLine("   {0}: {1}", item.Name, item.Length)
            Next
        Next

        ' Keep the console window open in debug mode
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()

    End Sub

    ' This method is used to catch the possible exception
    ' that can be raised when accessing the FileInfo.Length property.
    ' In this particular case, it is safe to ignore the exception.
    Function GetFileLength(ByVal fi As System.IO.FileInfo) As Long
        Dim retval As Long
        Try
            retval = fi.Length
        Catch ex As FileNotFoundException
            ' If a file is no longer present,
            ' just return zero bytes. 
            retval = 0
        End Try

        Return retval
    End Function
End Module
'</snippet3>

'<snippet4>
Module CompareDirs
    Public Sub Main()


        ' Create two identical or different temporary folders 
        ' on a local drive and add files to them.
        ' Then set these file paths accordingly.
        Dim pathA As String = "C:\TestDir"
        Dim pathB As String = "C:\TestDir2"

        ' Take a snapshot of the file system. 
        Dim dir1 As New System.IO.DirectoryInfo(pathA)
        Dim dir2 As New System.IO.DirectoryInfo(pathB)

        Dim list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories)
        Dim list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        ' Create the FileCompare object we'll use in each query
        Dim myFileCompare As New FileCompare

        ' This query determines whether the two folders contain
        ' identical file lists, based on the custom file comparer
        ' that is defined in the FileCompare class.
        ' The query executes immediately because it returns a bool.
        Dim areIdentical As Boolean = list1.SequenceEqual(list2, myFileCompare)
        If areIdentical = True Then
            Console.WriteLine("The two folders are the same.")
        Else
            Console.WriteLine("The two folders are not the same.")
        End If

        ' Find common files in both folders. It produces a sequence and doesn't execute
        ' until the foreach statement.
        Dim queryCommonFiles = list1.Intersect(list2, myFileCompare)

        If queryCommonFiles.Count() > 0 Then


            Console.WriteLine("The following files are in both folders:")
            For Each fi As System.IO.FileInfo In queryCommonFiles
                Console.WriteLine(fi.FullName)
            Next
        Else
            Console.WriteLine("There are no common files in the two folders.")
        End If

        ' Find the set difference between the two folders.
        ' For this example we only check one way.
        Dim queryDirAOnly = list1.Except(list2, myFileCompare)
        Console.WriteLine("The following files are in dirA but not dirB:")
        For Each fi As System.IO.FileInfo In queryDirAOnly
            Console.WriteLine(fi.FullName)
        Next

        ' Keep the console window open in debug mode
        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub

    ' This implementation defines a very simple comparison
    ' between two FileInfo objects. It only compares the name
    ' of the files being compared and their length in bytes.
    Public Class FileCompare
        Implements System.Collections.Generic.IEqualityComparer(Of System.IO.FileInfo)

        Public Function Equals1(ByVal x As System.IO.FileInfo, ByVal y As System.IO.FileInfo) _
            As Boolean Implements System.Collections.Generic.IEqualityComparer(Of System.IO.FileInfo).Equals

            If (x.Name = y.Name) And (x.Length = y.Length) Then
                Return True
            Else
                Return False
            End If
        End Function

        ' Return a hash that reflects the comparison criteria. According to the 
        ' rules for IEqualityComparer(Of T), if Equals is true, then the hash codes must
        ' also be equal. Because equality as defined here is a simple value equality, not
        ' reference identity, it is possible that two or more objects will produce the same
        ' hash code.
        Public Function GetHashCode1(ByVal fi As System.IO.FileInfo) _
            As Integer Implements System.Collections.Generic.IEqualityComparer(Of System.IO.FileInfo).GetHashCode
            Dim s As String = fi.Name & fi.Length
            Return s.GetHashCode()
        End Function
    End Class
End Module
'</snippet4>

'<snippet5>
Module GroupByExtension
    Public Sub Main()

        ' Root folder to query, along with all subfolders.
        Dim startFolder As String = "C:\program files\Microsoft Visual Studio 9.0\VB\"

        ' Used in WriteLine() to skip over startfolder in output lines.
        Dim rootLength As Integer = startFolder.Length

        'Take a snapshot of the folder contents
        Dim dir As New System.IO.DirectoryInfo(startFolder)
        Dim fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        ' Create the query.
        Dim queryGroupByExt = From file In fileList _
                          Group By file.Extension.ToLower() Into fileGroup = Group _
                          Order By ToLower _
                          Select fileGroup

        ' Execute the query. By storing the result we can
        ' page the display with good performance.
        Dim groupByExtList = queryGroupByExt.ToList()

        ' Display one group at a time. If the number of 
        ' entries is greater than the number of lines
        ' in the console window, then page the output.
        Dim trimLength = startFolder.Length
        PageOutput(groupByExtList, trimLength)

    End Sub

    ' Pages console diplay for large query results. No more than one group per page.
    ' This sub specifically works with group queries of FileInfo objects
    ' but can be modified for any type.
    Sub PageOutput(ByVal groupQuery, ByVal charsToSkip)

        ' "3" = 1 line for extension key + 1 for "Press any key" + 1 for input cursor.
        Dim numLines As Integer = Console.WindowHeight - 3
        ' Flag to indicate whether there are more results to diplay
        Dim goAgain As Boolean = True

        For Each fg As IEnumerable(Of System.IO.FileInfo) In groupQuery
            ' Start a new extension at the top of a page.
            Dim currentLine As Integer = 0

            Do While (currentLine < fg.Count())
                Console.Clear()
                Console.WriteLine(fg(0).Extension)

                ' Get the next page of results
                ' No more than one filename per page
                Dim resultPage = From file In fg _
                                Skip currentLine Take numLines

                ' Execute the query. Trim the display output.
                For Each line In resultPage
                    Console.WriteLine(vbTab & line.FullName.Substring(charsToSkip))
                Next

                ' Advance the current position
                currentLine = numLines + currentLine

                ' Give the user a chance to break out of the loop
                Console.WriteLine("Press any key for next page or the 'End' key to exit.")
                Dim key As ConsoleKey = Console.ReadKey().Key
                If key = ConsoleKey.End Then
                    goAgain = False
                    Exit For
                End If
            Loop
        Next
    End Sub
End Module
' </snippet5>

' DouglasR note: re previous snippet
'I() 'd probably refactor the paging code off into it’s own function. 
'Something like GetFiles(pageSize As Integer, currentPage As Integer) As Boolean where the 
' boolean returns true if there’s more data.

'<snippet6>
Module QueryDuplicateFileNames


    Public Sub Main()

        Dim path As String = "C:\Program Files\Microsoft Visual Studio 9.0\Common7"
        QueryDuplicates1(path)
        ' Uncomment to run this query instead
        ' QueryDuplicates2(path)

    End Sub
    Sub QueryDuplicates1(ByVal root As String)
        Dim dir As New System.IO.DirectoryInfo(root)
        Dim duplicates = From aFile In dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories) _
                                 Order By aFile.Name _
                                 Group aFile By aFile.Name Into newGroup = Group _
                                 Where newGroup.Count() >= 2 _
                                 Select newGroup

        ' Page the display so that the results can be read.
        Dim trimLength = root.Length
        PageOutput(duplicates, trimLength)

    End Sub
    Sub QueryDuplicates2(ByVal root As String)

        ' This time a composite key is used. This sub finds all files
        ' that have been copied into multiple subfolders.
        Dim dir As New System.IO.DirectoryInfo(root)

        Dim duplicates = From aFile In Dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories) _
                                 Order By aFile.Name _
                                 Group aFile By aFile.Name, aFile.CreationTime, aFile.Length Into newGroup = Group _
                                 Where newGroup.Count() >= 2 _
                                 Select newGroup

        ' Page the display so that the results can be read.
        Dim trimLength = root.Length
        PageOutput(duplicates, trimLength)

    End Sub
    ' Pages console diplay for large query results. No more than one group per page.
    ' This sub specifically works with group queries of FileInfo objects
    ' but can be modified for any type.
    Sub PageOutput(ByVal groupQuery, ByVal charsToSkip)

        ' "3" = 1 line for extension key + 1 for "Press any key" + 1 for input cursor.
        Dim numLines As Integer = Console.WindowHeight - 3
        ' Flag to indicate whether there are more results to diplay
        Dim goAgain As Boolean = True

        For Each fg As IEnumerable(Of System.IO.FileInfo) In groupQuery
            ' Start a new extension at the top of a page.
            Dim currentLine As Integer = 0

            Do While (currentLine < fg.Count())
                Console.Clear()

                ' Get the next page of results
                ' No more than one filename per page
                Dim resultPage = From file In fg _
                                Skip currentLine Take numLines

                ' Execute the query. Trim the paths in the output.
                For Each line In resultPage
                    Console.WriteLine(vbTab & line.FullName.Substring(charsToSkip))
                Next

                ' Advance the current position
                currentLine = numLines + currentLine

                ' Give the user a chance to break out of the loop
                Console.WriteLine("Press any key for next page or the 'End' key to exit.")
                Dim key As ConsoleKey = Console.ReadKey().Key
                If key = ConsoleKey.End Then
                    goAgain = False
                    Exit For
                End If
            Loop
        Next
    End Sub
End Module
'</snippet6>

'<snippet7>
Module Module1
    'QueryContents
    Public Sub Main()

        ' Modify this path as necessary.
        Dim startFolder = "c:\program files\Microsoft Visual Studio 9.0\VB\"

        'Take a snapshot of the folder contents
        Dim dir As New System.IO.DirectoryInfo(startFolder)
        Dim fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories)

        Dim searchTerm = "Visual Studio"

        ' Search the contents of each file.
        ' A regular expression created with the RegEx class
        ' could be used instead of the Contains method.
        Dim queryMatchingFiles = From file In fileList _
                                 Where file.Extension = ".htm" _
                                 Let fileText = GetFileText(file.FullName) _
                                 Where fileText.Contains(searchTerm) _
                                 Select file.FullName

        Console.WriteLine("The term " & searchTerm & " was found in:")

        ' Execute the query.
        For Each filename In queryMatchingFiles
            Console.WriteLine(filename)
        Next

        ' Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit")
        Console.ReadKey()

    End Sub

    ' Read the contents of the file. This is done in a separate
    ' function in order to handle potential file system errors.
    Function GetFileText(ByVal name As String) As String

        ' If the file has been deleted, the right thing
        ' to do in this case is return an empty string.
        Dim fileContents = String.Empty

        ' If the file has been deleted since we took 
        ' the snapshot, ignore it and return the empty string.
        If System.IO.File.Exists(name) Then
            fileContents = System.IO.File.ReadAllText(name)
        End If

        Return fileContents

    End Function
End Module

'</snippet7>

' unused
'Sub CompareTwoDirs(ByVal dirA As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo), ByVal dirB As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo))
'    Dim myFileCompare As New FileCompare

'    Dim areIdentical As Boolean = dirB.SequenceEqual(dirB, myFileCompare)
'    If areIdentical = True Then
'        Console.WriteLine("The two folders are the same.")
'    Else
'        Console.WriteLine("The two folders are not the same.")
'    End If
'End Sub

'Sub FindCommonFiles(ByVal dirA As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo), ByVal dirB As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo))
'    Dim myFileCompare As New FileCompare
'    Dim queryCommonFiles = dirA.Intersect(dirB, myFileCompare)

'    Console.WriteLine("The following files are in both folders:")
'    For Each fi As System.IO.FileInfo In queryCommonFiles
'        Console.WriteLine(fi.FullName)
'    Next
'End Sub

'Sub SetDifference(ByVal dirA As IEnumerable(Of System.IO.FileInfo), ByVal dirB As IEnumerable(Of System.IO.FileInfo))
'    Dim myFileCompare As New FileCompare
'    Dim queryDirAOnly = dirA.Except(dirB, myFileCompare)

'    Console.WriteLine("The following files are in dirA but not dirB:")
'    For Each fi As System.IO.FileInfo In queryDirAOnly
'        Console.WriteLine(fi.FullName)
'    Next
'End Sub


